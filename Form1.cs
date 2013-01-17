using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Net;
using System.Threading;
using System.Web;
using System.Reflection;
using System.Diagnostics;

using PCGPS.Manager;
using PCGPS.Plugin;
using PCGPS.OAuth;

using EbiSoft.Library.PluginFramework;

using Newtonsoft.Json;
using Newtonsoft.Json.Utilities;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;
using System.Xml;

// Location API
using System.Device.Location;


namespace PCGPS
{
    public partial class Form1 : Form
    {
        public string[] args = null;

        /// <summary>
        /// 近接ユーザー情報のキー：ユーザーID
        /// </summary>
        public readonly string USER = "user";
        /// <summary>
        /// 近接ユーザー情報のキー：ニックネーム
        /// </summary>
        public readonly string NICK = "nickname";
        /// <summary>
        /// 近接ユーザー情報のキー：現在の自分との距離
        /// </summary>
        public readonly string DIST = "dist";
        /// <summary>
        /// 近接ユーザー情報のキー：前回の自分との距離
        /// </summary>
        public readonly string PREVDIST = "prev_dist";
        /// <summary>
        /// 近接ユーザー情報のキー：対象ユーザーの向き
        /// </summary>
        public readonly string HEADING = "dir";
        /// <summary>
        /// 近接ユーザー情報のキー：自分から見た対象ユーザーの方向（ヘッドアップ）
        /// </summary>
        public readonly string DIRECTION = "direction";
        /// <summary>
        /// 近接ユーザー情報のキー：自分から見た対象ユーザーの方向(ノースアップ)
        /// </summary>
        public readonly string N_DIRECTION = "n_direction";
        /// <summary>
        /// 近接ユーザー情報のキー：緯度
        /// </summary>
        public readonly string LATI = "lat";
        /// <summary>
        /// 近接ユーザー情報のキー：経度
        /// </summary>
        public readonly string LONG = "lon";

        /*
#if DEBUG
        const string AddressURI = "http://localhost:8080/api/getaddress";
        const string PostURI = "http://localhost:8080/api/post";
        const string DelPostURI = "http://localhost:8080/api/delpost";
#else
        const string AddressURI = "http://imakoko-gps.appspot.com/api/getaddress";
        const string PostURI = "http://imakoko-gps.appspot.com/api/post";
        const string DelPostURI = "http://imakoko-gps.appspot.com/api/delpost";
#endif
        */
        const string AddressURI = "http://imakoko-gps.appspot.com/api/getaddress";
        const string PostURI = "http://imakoko-gps.appspot.com/api/post";
        const string DelPostURI = "http://imakoko-gps.appspot.com/api/delpost";

        
        //GPSデータ出力用ストリームライター
        StreamWriter swCommLog;

        // タイマー受信モード時のタイマー間隔(ms)
        const int ReceiveTimerInterval = 500;

        // 自動イマココの間隔(s)
        const int AutoImakokoInterval = 600;

        // 最低POST間隔(サーバのタイムアウト時間5分の半分よりちょっと少ない程度)
        const int MaximumPostInterval = 120;

        // GPSからのNMEAデータ取得回数
        int nmeaCount = 0;
        // NMEAセンテンスがエラーになった回数
        int sentenseErrorCount = 0;


        string version;

        //データ送信間隔
        int PostDataInterval;

        DateTime lastPostTime;
        DateTime lastImakoko;
        string prevAddress = "";

        List<GPSPoint> noPostPoint;
        bool inNoPost;
        int noPostPointIndex = 0;

        static string[] gpsMode = { "---", "GPS", "DGPS", "PPS", "RTK", "FRTK", "est", "man", "sim" };

        //送信間隔種別
        int IntervalType;
        const int INTERVAL_TIME = 1;
        const int INTERVAL_DISTANCE = 2;
        
        // GPS情報
        string gpsStatus, gpsLat, gpsLon, gpsH, gpsTime, gpsC, valid, gpsV, gpsD, gpsHDOP, gpsDate;
        Double Lat, Lon, Velocity;
        Double prevLat, prevLon, prevVelocity;
        Double hdop;
        Double distance, acc, totalDistance;
        string latNS, lonEW;
        DateTime prevDateTime;
        DateTime lastNMEATime;

        string icon;
        int iconIndex;

        Random rnd;

        Double debugLat = 35.658634;
        Double debugLon = 139.745411;
        Double debugDir = 0;

        bool nmea_received = false;
        bool mode_initial = true;

        // Location API is selected flag
        bool location_api_used = false;
        GeoCoordinateWatcher LocationAPI_watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.Default);
        int location_drop_count = 3;

        GPSTrackPoint lastPosition;
        GPSTrackPoint lastValidPosition = null;
        //SortedList<DateTime, GPSTrackPoint> trackPoints = new SortedList<DateTime, GPSTrackPoint>();

        // ワーカースレッド
        Thread t, t2, t3;

        // nmeaセンテンスをワーカースレッドに渡すためのキュー
        Queue<string> nmeaQueue = new Queue<string>();
        // キューを同期処理するためのロック
        ReaderWriterLock rwl = new ReaderWriterLock();
        // ワーカースレッドをおこすイベント
        AutoResetEvent autoEvent = new AutoResetEvent(false);
        AutoResetEvent autoPostEvent = new AutoResetEvent(false);
        AutoResetEvent autoTwitEvent = new AutoResetEvent(false);

        public bool ExitFlag = false;
        bool formLoaded = false;

        // コントロールのテキストを別スレッドから変更するためのdelegate定義
        delegate string GetTextCallback();
        delegate void SetTextCallback(string text);
        delegate void SetDataCallback();
        delegate void SetDoubleCallback(double d);
        delegate void SetIntCallback(int i);
        delegate void SetControlStatusCallback(Control c, bool enabled);

        // FLASHスピードメータ用
        /// <summary>
        /// TCP サーバ
        /// </summary>
        TcpServerSpeed tcpServerSpeed = new TcpServerSpeed();

        /// <summary>
        /// ポリシーファイルを送信するサーバ
        /// </summary>
        PolicyFileServer policyFileServer = new PolicyFileServer();

        /// <summary>
        /// Taxi変数
        /// </summary>

        enum TaxiStatus : int { Kuusha = 0, Jissha = 1, Kosoku=2, Shiharai = 3 };
        TaxiStatus mTaxiStatus = TaxiStatus.Kuusha;

        TcpServerTaxi tcpServerTaxi = new TcpServerTaxi();

        static Double TaxiHatsunoriMeter       = 2000;     // 初乗り料金で走れる距離[m]
        static Double TaxiHatsunoriMeter_Night = 1666.66;  // 初乗り料金で深夜走れる距離[m]
        static int    TaxiHatsunoriFare        = 710;      // 初乗り料金[円]
        static int    TaxiMeterPer90yen        = 288;      // 通常90円で走れる距離[m]
        static int    TaxiMeterPer90yen_Night  = 240;      // 深夜で90円で走れる距離[m]
        static int    TaxiLongDistanceDiscount = 9000;     // 長距離割引の開始金額
        static Double TaxiTimePer90yen         = 105;      // 90円で乗れる秒数[s]
        static Double TaxiTimePer90yen_Night   = 87.5;     // 深夜で90円で乗れる秒数[s]
        static int    TaxiFareUnit             = 90;       // タクシー料金の単位

        public DateTime mTaxiTime;
        public Double   mTaxiDistance = TaxiHatsunoriMeter;
        public int      fare = TaxiHatsunoriFare;
        public int      lastFare = 0;

        //
        // 位置サーバ
        //
        TcpServerPos tcpServerPos = new TcpServerPos();

        #region 初期化
        public Form1()
        {
            InitializeComponent();
        }

        private void loadSettings()
        {
            Properties.Settings.Default.CheckConfigFile();
            if (!Properties.Settings.Default.Saved)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.Saved = true;
                Properties.Settings.Default.Save();
            }

            // 前回終了時のデータを復帰する
            cbBaud.Text = Properties.Settings.Default.Baud;
            cbSerial.Text = Properties.Settings.Default.Port;
            txtUsername.Text = Properties.Settings.Default.User;
            txtPassword.Text = Properties.Settings.Default.Password;
            
            // txtTwitterID.Text = Properties.Settings.Default.TwitterID;
            // txtTwitterPassword.Text = Properties.Settings.Default.TwitterPW;
            if (Properties.Settings.Default.TwitterID != "" &&
                Properties.Settings.Default.TwitterPW != "")
            {
                if (MessageBox.Show("xAuth認証に切り替えます。\n保存されたTwitterのID/パスワードは削除されます。", "Twitter認証", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    try
                    {
                        Properties.Settings.Default.OAuthToken = "";
                        Properties.Settings.Default.OAuthTokenSecret = "";
                        TwitterOAuth.getInstance().getAccessToken(Properties.Settings.Default.TwitterID, Properties.Settings.Default.TwitterPW);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("xAuth認証に失敗しました。\n設定タブから認証をやり直してください。", "Twitter認証", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("設定タブから認証を行ってください。", "Twitter認証", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                Properties.Settings.Default.TwitterID = "";
                Properties.Settings.Default.TwitterPW = "";
            }


            IntervalType = Properties.Settings.Default.IntervalType;
            PostDataInterval = Properties.Settings.Default.PostDataInterval;
            chkSaveServer.Checked = Properties.Settings.Default.ServerSave;
            chkSpeedFilter.Checked = Properties.Settings.Default.SpeedFilter;
            chkHashTag.Checked = Properties.Settings.Default.HashTag;
            chkSound.Checked = Properties.Settings.Default.UseSound;
            chkYomiage.Checked = Properties.Settings.Default.UseYomiage;
            cbNoSameAddress.Checked = Properties.Settings.Default.NoSameAddress;
            string r = Properties.Settings.Default.Radius;
            if (r == "")
            {
                r = "500";
            }
            bool f = false;
            foreach (object o in cbRadius.Items)
            {
                if ((string)o == r)
                {
                    f = true;
                    break;
                }
            }
            if (!f)
            {
                cbRadius.Items.Add(r);
            }
            cbRadius.Text = r;
            txtTinyURL.Text = Properties.Settings.Default.TinyURL;
            txtMapURL.Text = Properties.Settings.Default.MapURL;
            chkLatLon.Checked = Properties.Settings.Default.AddLatLon;
            chkMapURL.Checked = Properties.Settings.Default.AddMapURL;
            txtImakoko.Text = Properties.Settings.Default.ImakokoHeader;
            chkSaveLog.Checked = Properties.Settings.Default.SaveFile;
            try
            {
                cbRaderRange.SelectedItem = Properties.Settings.Default.RaderRange.ToString();
            }
            catch (Exception)
            {
                cbRaderRange.SelectedIndex = 0;
            }
            try
            {
                cbAlertCheckInterval.SelectedItem = Properties.Settings.Default.CheckAlertInterval.ToString();
            }
            catch (Exception)
            {
                cbAlertCheckInterval.SelectedIndex = 0;
            }

            try
            {
                cbNoPost.Items.Clear();
                foreach (Object p in Properties.Settings.Default.PrivatePoint)
                {
                    cbNoPost.Items.Add(p);
                }
            }
            catch (Exception /*e */)
            {
            }
            setupNoListPoint();

            string s = PostDataInterval.ToString() + (IntervalType == INTERVAL_TIME ? "秒" : "m");
            cbPostInterval.Text = s;
            btnTinyURL.Enabled = false;

            txtRaderIn.Text = Properties.Settings.Default.RaderInText;
            txtRaderOut.Text = Properties.Settings.Default.RaderOutText;
            txtSoftalk.Text = Properties.Settings.Default.SoftalkPath;
            if (Properties.Settings.Default.YomiageTool == "Softalk")
            {
                rbYomiageSoftalk.Checked = true;
            }
            else if (Properties.Settings.Default.YomiageTool == "Bouyomi")
            {
                rbBouyomi.Checked = true;
            }
            else
            {
                rbYomiageSoftalk.Checked = true;
            }

            chkSend.Checked = Properties.Settings.Default.SendError;
            chkRestart.Checked = Properties.Settings.Default.RestartOnError;
            chkNeverShow.Checked = Properties.Settings.Default.NeverDisplayErrorDialog;

            chkUseNearAlert.Checked = Properties.Settings.Default.UseNearAlert;
            txtProxyPort.Text = Properties.Settings.Default.ProxyPort.ToString();
            txtProxyServer.Text = Properties.Settings.Default.ProxyServer;

            txtSoundPost.Text = Properties.Settings.Default.SoundPost;
            txtSoundTwit.Text = Properties.Settings.Default.SoundTwit;
            txtSoundRaderIn.Text = Properties.Settings.Default.SoundRaderIn;
            txtSoundRaderOut.Text = Properties.Settings.Default.SoundRaderOut;

            chkTwitLocation.CheckedChanged -= new EventHandler(chkTwitLocation_CheckedChanged);
            chkTwitLocation.Checked = Properties.Settings.Default.LocationTwit;
            chkTwitLocation.CheckedChanged += new EventHandler(chkTwitLocation_CheckedChanged);

            iconIndex = Properties.Settings.Default.IconIndex;
            if (iconIndex < 0)
            {
                iconIndex = 0;
            }
            cbIcon.SelectedIndex = iconIndex;

            txtLogDirectory.Text = Properties.Settings.Default.LogDirectory;

            if (Properties.Settings.Default.OAuthToken != "" && Properties.Settings.Default.OAuthTokenSecret != "")
            {
                lblOAuth.Text = "認証済み";
            }
            else
            {
                lblOAuth.Text = "未認証";
            }

            chkSaveWinPos.Checked = Properties.Settings.Default.SaveWindowLocation;
        }

        #endregion

        #region データ送信
        // HTTPでサーバにデータを送信する
        private void LocationPost()
        {
            try
            {
                string result = ImacocoNowManager.PostLocation(lastPosition, icon);
                SetStatusText(result);
                //trackPoints.Clear();
            }
            catch (Exception e)
            {
                SetStatusText("LocationPost: " + e.Message);
            }
        }

        // マーカーをけす
        private void DeleteLocation()
        {
            try
            {
                string result = ImacocoNowManager.DeleteLocation();
            }
            catch (Exception e)
            {
                SetStatusText(e.Message);
            }
        }

        // 現在地の住所を取得する
        private string GetAddress()
        {
            try
            {
                // HTTP用WebRequestの作成
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(AddressURI + "?lat=" + lastPosition.Latitude.ToString() + "&lon=" + lastPosition.Longitude.ToString() + "&acc=4");
                req.Method = WebRequestMethods.Http.Get;
                if (txtUsername.Text.Length != 0)
                {
                    req.Credentials = new NetworkCredential(txtUsername.Text, txtPassword.Text);
                    req.PreAuthenticate = true;
                }
                req.UserAgent = version + " " + txtUsername.Text;
                req.Timeout = 8000;
                if (Properties.Settings.Default.ProxyServer.Length > 0)
                {
                    req.Proxy = new WebProxy(string.Format("http://{0}:{1}", Properties.Settings.Default.ProxyServer, Properties.Settings.Default.ProxyPort));
                }

                // レスポンスを取得
                using (WebResponse res = req.GetResponse())
                {
                    using (StreamReader sr = new StreamReader(res.GetResponseStream()))
                    {
                        string r = sr.ReadLine();
                        if (r != null)
                        {
                            r = r.Replace(" ", "").Replace("　", "").Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace("\x00A0", "");
                        }
                        if (r != null && r != "")
                        {
                            SetStatusText("住所を取得しました(" + Encoding.UTF8.GetBytes(r).Length + "バイト)");

                            // プラグインの呼び出し
                            foreach (PluginBase p in pluginManager.LoadedPlugins)
                            {
                                ImacocoNowPlugin plugin = (ImacocoNowPlugin)p;
                                ThreadStart ts = () =>
                                {
                                    plugin.OnGetAddress(r);
                                };
                                Thread t = new Thread(ts);
                                t.IsBackground = true;
                                t.Start();
                            }

                            return r;
                        }
                        else
                        {
                            SetStatusText("住所が取得できませんでした");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SetStatusText("GetAddress: " + ex.Message);
            }
            return "";
        }

        // TwitterにPOSTする
        private void SendTwitter(bool addHeaderFooter)
        {
            /*
            if (!chkDebug.Checked)
            { */
                string r = txtAddress.Text;
                if (addHeaderFooter)
                {
                    if (txtImakoko.Text.Length == 0)
                    {
                        r = "ｲﾏｺｺ! L:" + r;
                    }
                    else
                    {
                        r = txtImakoko.Text + r;
                    }
                    if (chkHashTag.Checked)
                    {
                        r = r + " #imacoconow ";
                    }

                    if ((chkLatLon.Checked && txtGpsLat.Text.Length > 0 && txtGpsLon.Text.Length > 0) ||
                        (chkMapURL.Checked && txtTinyURL.Text.Length != 0))
                    {
                        r += " [";
                        if (chkLatLon.Checked)
                        {
                            r += txtGpsLat.Text + (txtGpsLat.Text[0] == '-' ? "S," : "N,") + txtGpsLon.Text + (txtGpsLon.Text[0] == '-' ? "W" : "E");
                            if (chkMapURL.Checked && txtTinyURL.Text.Length != 0)
                            {
                                r += ",";
                            }
                        }
                        if (chkMapURL.Checked && txtTinyURL.Text.Length != 0)
                        {
                            r += txtTinyURL.Text;
                        }
                        r += "]";
                    }
                }

                try
                {
                    string result = TwitterManager.Tweet(r, lastPosition);
                    SetStatusText("TwitterへPOSTしました");
                    SetAddressText("");
                    SetControlStatus(btnTwitterPost, false);
                    if (Properties.Settings.Default.SoundTwit != "")
                    {
                        Util.PlaySEFromFile(Properties.Settings.Default.SoundTwit);
                    }
                    else
                    {
                        Util.PlaySE("PCGPS.Resources.b_046.wav");
                    }
                }
                catch (Exception ex)
                {
                    SetStatusText("SendTwitter:" + ex.Message);
                }
            //}
        }
        #endregion

        #region タクシー深夜割増判定
        private bool IsShinya()
        {
            int iHour = DateTime.Now.Hour;
            return (iHour >= 22 || iHour < 5);
        }

        private void updateTaxiTime()
        {
            if (IsShinya())
            {
                mTaxiTime = DateTime.Now + TimeSpan.FromSeconds(TaxiTimePer90yen_Night);
            }
            else
            {
                mTaxiTime = DateTime.Now + TimeSpan.FromSeconds(TaxiTimePer90yen);
            }
        }

        private void updateTaxiDistance()
        {
            if (IsShinya())
            {
                mTaxiDistance += TaxiMeterPer90yen_Night;
            }
            else
            {
                mTaxiDistance += TaxiMeterPer90yen;
            }
        }

        //
        //  タクシーメータの表示の更新
        //
        private void updateMaxiMeter()
        {
            // 長距離割引の適用チェック
            if (fare <= TaxiLongDistanceDiscount || mTaxiStatus != TaxiStatus.Shiharai)
            {
                tcpServerTaxi.SendMessageAll(((int)fare).ToString() + "," + ((int)mTaxiStatus).ToString() + (IsShinya() ? ",1" : ",0"));
            }
            else
            {
                int new_fare = fare - ((int)Math.Truncate((fare - TaxiLongDistanceDiscount) * 0.01)) * 10;
                tcpServerTaxi.SendMessageAll(new_fare.ToString() + "," + ((int)mTaxiStatus).ToString() + (IsShinya() ? ",1" : ",0"));
            }
        }

        #endregion
        #region NMEAセンテンス解釈

        public void ThreadEntry()
        {
            while (true)
            {
                // キューにNMEAセンテンスが入るまで待つ
                autoEvent.WaitOne();
                // キューにあるだけまわす
                while (nmeaQueue.Count > 0)
                {
                    string nmea;
                    lock (nmeaQueue)
                    {
                        // キューからNMEAセンテンスを取得
                        nmea = nmeaQueue.Dequeue();
                    }
                    // NMEAセンテンスを処理する
                    parseNMEA(nmea);
                }
                // 速度の通知
                tcpServerSpeed.SendMessageAll(((int)Velocity).ToString());

                //料金の更新

                // 時間による加算
                if (Velocity > 10 || mTaxiStatus != TaxiStatus.Jissha)
                {
                    updateTaxiTime();
                }
                else
                {
                    if (DateTime.Now > mTaxiTime)
                    {
                        fare += TaxiFareUnit;
                        updateTaxiTime();
                    }
                }

                // 距離による加算
                while (totalDistance > mTaxiDistance && (mTaxiStatus == TaxiStatus.Jissha||mTaxiStatus==TaxiStatus.Kosoku))
                {
                    if (mTaxiStatus != TaxiStatus.Kuusha) fare += TaxiFareUnit;
                    updateTaxiDistance();
                }
                if (lastFare != fare)
                {
                    lastFare = fare;
                    updateMaxiMeter();
                }
            }
        }

        public void AutoPostThreadEntry()
        {
            while (true)
            {
                autoPostEvent.WaitOne();
                if (lastPosition == null)
                {
                    continue;
                }
                LocationPost();
            }
        }

        public void AutoTwitThreadEntry()
        {
            while (true)
            {
                autoTwitEvent.WaitOne();
                if (lastPosition == null)
                {
                    continue;
                }
                try
                {
                    // 現在地の住所を取得する
                    string r = GetAddress();
                    if (r != "")
                    {
                        SetAddressText(r);
                        if (Properties.Settings.Default.NoSameAddress)
                        {
                            // 同一住所判定をしないで住所POSTする
                            lastImakoko = DateTime.Now;
                            SendTwitter(true);
                        }
                        else
                        {
                            string r2 = Util.GetPrefCity(r);
                            if (r2 != "")
                            {
                                if (prevAddress != r2)
                                {
                                    lastImakoko = DateTime.Now;
                                    SendTwitter(true);
                                    prevAddress = r2;
                                }
                                else
                                {
                                    // 住所が同じだったら2分後にチェックする
                                    lastImakoko = DateTime.Now.AddSeconds(-AutoImakokoInterval + 120);
                                }
                            }
                            else
                            {
                                // 住所が取得できなかったら1分後にチェックする
                                lastImakoko = DateTime.Now.AddSeconds(-AutoImakokoInterval + 60);
                            }
                        }
                    }
                    else
                    {
                        lastImakoko = DateTime.Now.AddSeconds(-AutoImakokoInterval + 60);
                    }
                }
                catch (Exception e)
                {
                    SetStatusText("AutoTwitThreadEntry: " + e.Message);
                    lastImakoko = DateTime.Now.AddSeconds(-AutoImakokoInterval + 60);
                }
            }
        }

        private bool CheckValidPoint(GPSTrackPoint point)
        {
            if (point.GPSfix != 1 && point.GPSfix != 2)
            {
                SetStatusText("GPS not fixed.");
                point.SoftError = true;
                return false;
            }

            double L = Util.CalcDistance(prevLat, prevLon, point.Latitude, point.Longitude);
            if (L > 3000 && prevLat == 0 && prevLon == 0)
            {
                // 初期値
                L = 0;
                prevDateTime = point.time;
                prevLat = point.Latitude;
                prevLon = point.Longitude;
            }
//            if ((L / (point.time - prevDateTime).TotalSeconds) > Util.GetMaxVelocity(cbIcon.SelectedIndex))
            if (point.Velocity > Util.GetMaxVelocity(iconIndex))
            {
                SetStatusText("速度が速すぎます");
                point.SoftError = true;
            }
            else
            {
                if (point.Latitude != 0 && point.Longitude != 0 && L >= 10)
                {
                    // 移動距離10m以上のデータなら移動中とみなして、累積移動距離を加算する
                    distance += L;
                    totalDistance += L;
                    prevLat = point.Latitude;
                    prevLon = point.Longitude;
                    SetStatusText("");
                }
            }

            return !point.SoftError;
        }

        private void CheckInNoPostArea(GPSTrackPoint point)
        {
            inNoPost = false;
            noPostPointIndex = 0;
            if (point.Velocity >= 50)
            {
                // 時速50km以上なら非送信地帯無視
                return;
            }
            
            Double radius;
            try
            {
                radius = Double.Parse(GetRadius());
            }
            catch (Exception /* e */)
            {
                // 安全装置。非送信半径がおかしかったら1kmに設定する
                radius = 1000;
            }

            foreach (GPSPoint p in noPostPoint)
            {
                if (Util.CalcDistance(p.Latitude, p.Longitude, point.Latitude, point.Longitude) < radius)
                {
                    inNoPost = true;
                    break;
                }
                noPostPointIndex++;
            }
        }

        private GPSTrackPoint SetupGpsData()
        {
            try
            {
                int idx = gpsLat.IndexOf(".");
                string min = gpsLat.Substring(idx - 2);
                string deg = gpsLat.Substring(0, idx - 2);
                Lat = Double.Parse(min) / 60 + Double.Parse(deg);
            }
            catch (Exception /*e*/)
            {
                Lat = 0;
            }
            if (latNS == "S")
            {
                Lat = -Lat;
            }
            try
            {
                int idx = gpsLon.IndexOf(".");
                Lon = Double.Parse(gpsLon.Substring(idx - 2)) / 60 + Double.Parse(gpsLon.Substring(0, idx - 2));
            }
            catch (Exception /*e*/)
            {
                Lon = 0;
            }
            if (lonEW == "W")
            {
                Lon = -Lon;
            }
            Double.TryParse(gpsHDOP, out hdop);

            if (chkDebug.Checked)
            {
                // デバッグモード時、データを上書き
                valid = "A";
                gpsLat = GetRandomGPSLat();
                gpsLon = GetGPSLon();
                Double.TryParse(gpsLat, out Lat);
                Double.TryParse(gpsLon, out Lon);
                gpsD = GetGPSDirection();
                gpsStatus = "1";
            }

            DateTime datetime;
            try
            {
                int dd = int.Parse(gpsDate.Substring(0, 2));
                int mm = int.Parse(gpsDate.Substring(2, 2));
                int yy = 2000 + int.Parse(gpsDate.Substring(4, 2));
                int hh = int.Parse(gpsTime.Substring(0, 2));
                int mi = int.Parse(gpsTime.Substring(2, 2));
                int ss = int.Parse(gpsTime.Substring(4, 2));
                int msec = int.Parse(gpsTime.Substring(7, 3));

                datetime = new DateTime(yy, mm, dd, hh, mi, ss, msec, DateTimeKind.Utc).ToLocalTime();
            }
            catch (Exception /*e*/)
            {
                datetime = DateTime.Now;
            }
            gpsTime = datetime.ToString("yyyy-MM-dd'T'HH:mm:ss.Fzzz");

            Double.TryParse(gpsV, out Velocity);
            Velocity = Math.Round(Velocity * 1.852, 1); // 1knot = 1.852km/h

            GPSTrackPoint position = new GPSTrackPoint();
            position.Latitude = Lat;
            position.Longitude = Lon;
            Double.TryParse(gpsH, out position.Height);
            position.time = datetime;
            position.Velocity = Velocity;
            int.TryParse(gpsStatus, out position.GPSfix);
            int.TryParse(gpsC, out position.SateliteCount);
            Double.TryParse(gpsD, out position.Direction);
            position.Valid = valid;
            position.SoftError = false;

            if (lastNMEATime == new DateTime())
            {
                acc = 0.0D;
            }
            else
            {
                acc = (position.Velocity - prevVelocity) / (lastNMEATime - position.time).TotalSeconds;
            }
            lastNMEATime = position.time;
            prevVelocity = position.Velocity;

            return position;
        }

        private void AutoSend()
        {
            // 自動Post
            if (chkAutoPost.Checked)
            {
                // 180秒経過 もしくは 自動POST条件かつ速度フィルターありなら時速1km以上
                if (
                    (lastPostTime.AddSeconds(MaximumPostInterval) < DateTime.Now) ||
                    (
                        (
                            (IntervalType == INTERVAL_TIME && lastPostTime.AddSeconds(PostDataInterval) < DateTime.Now) ||
                            (IntervalType == INTERVAL_DISTANCE && distance > PostDataInterval)
                        ) &&
                        (!chkSpeedFilter.Checked || Velocity > 1)
                    )
                )
                {
                    autoPostEvent.Set();
                    lastPostTime = DateTime.Now;
                    distance = 0;
                }
            }

            // 自動イマココ
            if (chkAutoTwit.Checked)
            {
                if (lastImakoko.AddSeconds(AutoImakokoInterval) < DateTime.Now)
                {
                    autoTwitEvent.Set();
                    lastImakoko = DateTime.Now;
                }
            }
            SetProgressBar();
        }        
        private void parseNMEA(string TextRcv)
        {
            try
            {
                ++nmeaCount;
                if (!Util.IsValidSentense(TextRcv))
                {
                    // チェックサムが合わなかったらエラー
                    SetStatusText("NMEA sentense CheckSum error");
                    ++sentenseErrorCount;
                    SetCounterText();
                    return;
                }
                if (chkSaveLog.Checked)
                {
                    swCommLog.WriteLine(TextRcv);
                }

                string data_tmp = TextRcv.Substring(0, 7); // 2009.09.19 Added by y3sei
                if (data_tmp == "$GPRMC," || data_tmp == "$GPGGA,") // 2009.09.19 Added by y3sei
                { // 2009.09.19 Added by y3sei
                    string[] data = TextRcv.Split(',');
                    if (data[0] == "$GPGGA")
                    {
                        gpsTime = data[1];
                        gpsLat = data[2];
                        latNS = data[3];
                        gpsLon = data[4];
                        lonEW = data[5];
                        gpsStatus = data[6];
                        gpsC = data[7];
                        gpsHDOP = data[8];
                        gpsH = data[9];
                        // data[10] = 高度の単位(M)
                        // data[11] = WGS-84楕円体から平均海水面の高度差
                        // data[12] = 高度の単位(M)
                        // data[13] = DGPSデータのエイジ
                        // data[14] = DGPS基準局のID
                        // data[15] = チェックサム
                    }
                    else if (data[0] == "$GPRMC")
                    {
                        // data[1] = 測位時刻
                        valid = data[2];
                        // data[3] = 緯度
                        // data[4] = 北緯(N)/南緯(S)
                        // data[5] = 経度
                        // data[6] = 東経(E)/西経(W)
                        gpsV = data[7]; // 対地速度(knot)
                        gpsD = data[8]; // 進行方向(度)
                        gpsDate = data[9];  // 測位日付ddmmyy
                        // data[10] = 磁気偏差量
                        // data[11] = 磁気偏差方向
                        // data[12] = チェックサム

                        GPSTrackPoint position = SetupGpsData();
                        SetGPSText();

                        if (!CheckValidPoint(position))
                        {
                            // 無効データ
                            // SetStatusText("無効データ");
                            if (chkAutoPost.Checked && lastPostTime.AddSeconds(MaximumPostInterval) < DateTime.Now && !inNoPost)
                            {
                                if (lastValidPosition != null)
                                {
                                    lastPosition = lastValidPosition;
                                    // 位置を維持
                                    autoPostEvent.Set();
                                }
                                lastPostTime = DateTime.Now;
                                distance = 0;
                            }
                        }
                        else
                        {
                            //trackPoints.Add(position.time, position);
                            CheckInNoPostArea(position);

                            //各パラメータを表示
                            lastPosition = position;
                            SetStLblNoPost();

                            if (!inNoPost)
                            {
                                lastValidPosition = position;
                                AutoSend();
                            }

                            // プラグインの呼び出し
                            foreach (PluginBase p in pluginManager.LoadedPlugins)
                            {
                                ImacocoNowPlugin plugin = (ImacocoNowPlugin)p;
                                ThreadStart ts = () =>
                                {
                                    plugin.OnLocationChanged(position);
                                };
                                Thread t = new Thread(ts);
                                t.IsBackground = true;
                                t.Start();
                            }
                        }

                    } // 2009.09.19 Added by y3sei
                    else // 2009.09.19 Added by y3sei
                    { // 2009.09.19 Added by y3sei
                        SetStatusText("other error"); // 2009.09.19 Added by y3sei
                        ++sentenseErrorCount; // 2009.09.19 Added by y3sei
                        SetCounterText(); // 2009.09.19 Added by y3sei
                        return; // 2009.09.19 Added by y3sei
                    } // 2009.09.19 Added by y3sei
                }
                SetCounterText();
            }
            catch (Exception Ex)
            {
                SetStatusText("parseNMEA: " + Ex.Message);
                // MessageBox.Show(Ex.Message, "Error");
                ++sentenseErrorCount; // 2009.09.19 Added by y3sei
                SetCounterText(); // 2009.09.19 Added by y3sei
            }
        }

        #endregion

        #region Utils
        private void setupNoListPoint()
        {
            Properties.Settings.Default.PrivatePoint = new System.Collections.Specialized.StringCollection();
            noPostPoint.Clear();
            foreach (string item in cbNoPost.Items)
            {
                try
                {
                    noPostPoint.Add(GPSPoint.Parse(item));
                    Properties.Settings.Default.PrivatePoint.Add(item);
                }
                catch (Exception /*ex*/)
                {
                }
            }
            Properties.Settings.Default.Save();
        }

        private void AddNoPostArea(Double Lat, Double Lon, string name)
        {
            GPSPoint p2 = new GPSPoint(Lat, Lon, name);
            noPostPoint.Add(p2);
            cbNoPost.Items.Add(p2.ToString());

            SetStatusText("非通知エリアを登録しました");
        }

        // ログファイルを開く
        void OpenLogFile()
        {
            if (swCommLog != null) return;
            string dir = Properties.Settings.Default.LogDirectory;
            if (!dir.EndsWith(@"\"))
            {
                dir += @"\";
            }

            swCommLog = new StreamWriter(
                new FileStream(
                    dir + "GPSLog" + DateTime.Now.ToString("yyyyMMdd-hhmm") + ".nme",
                    FileMode.Create,
                    FileAccess.Write
                ),
                Encoding.Default
            );
        }

        // ログファイルを閉じる
        void CloseLogFile()
        {
            try
            {
                swCommLog.Close();
            }
            catch (Exception /*e*/)
            {
            }
            swCommLog = null;
        }

        #endregion

        #region Location API
        // Position を $GPGGA フォーマットに直して、nmeaQueue に加える
        private void EnqueueLocation(GeoPosition<GeoCoordinate> pos)
        {
            if (!pos.Location.IsUnknown)
            {
                string sentence1;
                string sentence2;
                double lat = pos.Location.Latitude; ;
                double lat_abs = Math.Abs(lat); ;
                double lat_m = (lat_abs - Math.Truncate(lat_abs)) * 60.0f;
                double lon = pos.Location.Longitude;
                double lon_abs = Math.Abs(lon); ;
                double lon_m = (lon_abs - Math.Truncate(lon_abs)) * 60.0f; ;

                sentence1 = ("$GPGGA," +
                    pos.Timestamp.Hour.ToString("00") + pos.Timestamp.Minute.ToString("00") + pos.Timestamp.Second.ToString("00") + "." + pos.Timestamp.Millisecond.ToString("000") + "," +
                    ((int)Math.Truncate(lat_abs)).ToString("00") + lat_m.ToString("00.0000") + "," + (lat > 0 ? "N" : "S") + "," +
                    ((int)Math.Truncate(lon_abs)).ToString("000") + lon_m.ToString("00.0000") + "," + (lon > 0 ? "E" : "W") + "," +
                    "1,5,00.00," +
                    pos.Location.Altitude.ToString("0.0") + ",M," +
                    pos.Location.Altitude.ToString("0.0") + ",M,,*");
                sentence1 = sentence1 + Util.GetChecksum(sentence1);

                sentence2 = ("$GPRMC,"+
                    pos.Timestamp.Hour.ToString("00") + pos.Timestamp.Minute.ToString("00") + pos.Timestamp.Second.ToString("00") + "." + pos.Timestamp.Millisecond.ToString("000") + "," +
                    "A,"+
                    ((int)Math.Truncate(lat_abs)).ToString("00") + lat_m.ToString("00.0000") + "," + (lat > 0 ? "N" : "S") + "," +
                    ((int)Math.Truncate(lon_abs)).ToString("000") + lon_m.ToString("00.0000") + "," + (lon > 0 ? "E" : "W") + "," +
                    (Double.IsNaN(pos.Location.Speed)?"0.0":(0.514444f*pos.Location.Speed).ToString("0.000"))+","+
                    (Double.IsNaN(pos.Location.Course)?"000.0":pos.Location.Course.ToString("000.0"))+","+
                    pos.Timestamp.Day.ToString("00")+pos.Timestamp.Month.ToString("00")+(pos.Timestamp.Year%100).ToString("00")+","+
                    ",,A*");

                sentence2 = sentence2 + Util.GetChecksum(sentence2);

                lock (nmeaQueue)
                {
                    nmeaQueue.Enqueue(sentence1);
                    nmeaQueue.Enqueue(sentence2);
                    autoEvent.Set();
                }
            }
        }

        // Location API で場所が変化したときのハンドラ
        private void LocationAPI_watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            if (location_drop_count > 0)
            {
                location_drop_count--;
            }
            else
            {
                EnqueueLocation(e.Position);
            }
        }

        #region ボタン
        //手動Postボタン
        private void btnFTPPost_Click(object sender, EventArgs e)
        {
            if (lastPosition != null)
            {
                LocationPost();
            }
           
        }
        #endregion

        private void CommOpen()
        {
            //ログ保存チェックされていたら
            if (chkSaveLog.Checked)
            {
                OpenLogFile();
            }
            if (cbSerial.Text.CompareTo("API") != 0)
            {
                // Serial Port を使用する
                location_api_used = false;

                serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
                if (Properties.Settings.Default.ReceiveMode == "Timer")
                {
                    mode_initial = false;
                    timer1.Interval = ReceiveTimerInterval;
                }
                else
                {
                    mode_initial = true;
                    timer1.Interval = 5000;
                }
                timer1.Enabled = true;

                //ポート設定
                serialPort1.PortName = cbSerial.Text;
                SetStatusText("SerialPort: " + cbSerial.Text);

                int Baudrate;
                //通信速度を文字列から整数に変換
                int.TryParse(cbBaud.Text, out Baudrate);
                SetStatusText(cbBaud.Text + "bps");

                //通信速度設定
                serialPort1.BaudRate = Baudrate;
                //接続
                serialPort1.Open();
                serialPort1.DiscardInBuffer();
            }
            else
            {
                // Location API を使用する
                location_api_used = true;

                // 最初の５点は捨てる
                location_drop_count = 5;

                // ロケーションサービスへのイベント追加
                LocationAPI_watcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(LocationAPI_watcher_PositionChanged);

                // ロケーションサービスへアクセス開始
                LocationAPI_watcher.Start();

            }

            // ボタンやチェックボックスの状態を設定
            btnFTPPost.Enabled = true;
            btnNoPostArea.Enabled = true;
            lblIndicator.ForeColor = Color.Yellow;

            inNoPost = false;
            lastPostTime = new DateTime();
            lastNMEATime = new DateTime();
            distance = 0;
            totalDistance = 0;
            nmeaCount = 0;
            sentenseErrorCount = 0;
            SetStLblSave();
            SetStLblGPSPost();
            SetStLblNoPost();
            SetCounterText();
            btnCommOpenClose.Text = "GPS切断";
        }

        private void CommClose()
        {
            CloseLogFile();

            if (!location_api_used)
            {
                timer1.Enabled = false;
                try
                {
                    serialPort1.DataReceived -= new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
                }
                catch (Exception /*e*/)
                {
                }
                serialPort1.Close();
            }
            else
            {
                // ロケーションサービスへのイベント削除
                LocationAPI_watcher.PositionChanged -= new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(LocationAPI_watcher_PositionChanged);

                // ロケーションサービスへアクセス停止
                LocationAPI_watcher.Stop();

                // ロケーションサービス停止
                location_api_used = false;
            }

            btnFTPPost.Enabled = false;
            btnNoPostArea.Enabled = false;
            lblIndicator.ForeColor = Color.Red;
            btnCommOpenClose.Text = "GPS接続";
            SetStLblSave();
            SetStLblGPSPost();
        }

        DateTime prevCheckAlert;

        //接続ボタン
        private void btnCommOpenClose_Click(object sender, EventArgs e)
        {
            btnFTPPost.Enabled = false;
            btnNoPostArea.Enabled = false;
            btnGetAddress.Enabled = false;

            if (btnCommOpenClose.Text == "GPS接続")
            {
                try
                {
                    CommOpen();
                    prevCheckAlert = DateTime.Now.AddSeconds(10);
                    timer2.Interval = Properties.Settings.Default.CheckAlertInterval * 1000;
                    timer2.Enabled = true;
                }
                catch (Exception Ex)
                {
                    CommClose();
                    SetStatusText("btnCommOpenClose:" + Ex.Message);
                }
            }
            else
            {
                timer2.Enabled = false;
                CommClose();
            }
        }

        // 住所取得ボタン
        private void btnGetAddress_Click(object sender, EventArgs e)
        {
            SetAddressText(GetAddress());
        }

        // twitterへのPostボタン
        private void btnTwitterPost_Click(object sender, EventArgs e)
        {
            SendTwitter(false);
        }

        // 非送信エリアボタン
        private void btnNoPostArea_Click(object sender, EventArgs e)
        {
            if (txtGpsMode.Text == "0")
            {
                MessageBox.Show("GPS精度が十分ではありません");
                return;
            }
            /*
            Double radius;
            Double.TryParse(cbRadius.Text, out radius);
            if (radius == 0.0) { radius = 250; }
            foreach (Point p in noPostPoint)
            {
                Double L = calcDistance(p.Latitude, p.Longitude, Lat, Lon);
                if (L < radius)
                {
                    MessageBox.Show("既に登録されている範囲内です");
                    return;
                }
            }
             */
            Form2 fm = new Form2();
            fm.Lon = Lon;
            fm.Lat = Lat;
            fm.PosName = "名称非設定";
            if (fm.ShowDialog() == DialogResult.OK)
            {
                AddNoPostArea(fm.Lat, fm.Lon, fm.PosName);
                setupNoListPoint();
            }
        }

        // 削除ボタン
        private void btnDeleteNoPost_Click(object sender, EventArgs e)
        {
            if (cbNoPost.Text != "")
            {
                cbNoPost.Items.Remove(cbNoPost.Text);
                setupNoListPoint();
                SetStatusText("非通知エリアを１箇所削除しました");
            }
        }

        // 追加ボタン
        private void btnAddNoPost_Click(object sender, EventArgs e)
        {
            Form2 fm2 = new Form2();
            if (fm2.ShowDialog() == DialogResult.OK)
            {
                AddNoPostArea(fm2.Lat, fm2.Lon, fm2.Name);
                setupNoListPoint();
            }
        }

        // 編集ボタン
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (cbNoPost.Text == "")
            {
                return;
            }

            string[] data = cbNoPost.Text.Split(',');
            Form2 fm = new Form2();
            Double lat, lon;
            Double.TryParse(data[0], out lat);
            Double.TryParse(data[1], out lon);
            fm.Lat = lat;
            fm.Lon = lon;
            fm.PosName = data[2];
            if (fm.ShowDialog() == DialogResult.OK)
            {
                cbNoPost.Items.Remove(cbNoPost.Text);
                AddNoPostArea(fm.Lat, fm.Lon, fm.PosName);
                setupNoListPoint();
            }
        }

        private void btnTinyURL_Click(object sender, EventArgs e)
        {
            try
            {
                // HTTP用WebRequestの作成
                WebRequest req = WebRequest.Create("http://tinyurl.com/api-create.php?url=" + HttpUtility.UrlEncode(txtMapURL.Text));
                req.Method = WebRequestMethods.Http.Get;
                req.Timeout = 2000;

                // レスポンスを取得
                using (WebResponse res = req.GetResponse())
                {
                    using (StreamReader sr = new StreamReader(res.GetResponseStream()))
                    {
                        txtTinyURL.Text = sr.ReadToEnd();
                        btnTinyURL.Enabled = false;
                    }
                }
            }
            catch (Exception /*e */)
            {
                txtTinyURL.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string rgeoUrl = "http://imacoco.fujita-lab.com/api/rgeocode.php";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(rgeoUrl +
                "?lat=" + Math.Round(35.4, 6).ToString() +
                "&lon=" + Math.Round(137.4, 6).ToString());
            req.Method = WebRequestMethods.Http.Get;
            req.Timeout = 8000;

            // レスポンスを取得
            try
            {
                using (HttpWebResponse res = (HttpWebResponse)req.GetResponse())
                {
                    using (StreamReader sr = new StreamReader(res.GetResponseStream()))
                    {
                        string r = sr.ReadToEnd();
                        if (res.StatusCode == HttpStatusCode.OK)
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(r);

                            XmlNodeList prefNodes = doc.GetElementsByTagName("pname");
                            if (prefNodes != null && prefNodes.Count > 0)
                            {
                                BouyomiChanClient.Talk( prefNodes.Item(0).ChildNodes[0].Value + "に入りました");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SetStatusText(ex.Message);
            }
        }
        #endregion

        Assembly mainAssembly;
        System.Resources.ResourceManager rm;

        PluginManager pluginManager;

        #region イベント
        // Form1がロードされたときに実行される
        private void Form1_Load(object sender, EventArgs e)
        {
            // バージョン名（AssemblyInformationalVersion属性）を取得
            string appVersion = Application.ProductVersion;
            // 製品名（AssemblyProduct属性）を取得
            string appProductName = Application.ProductName;
            // 会社名（AssemblyCompany属性）を取得
            string appCompanyName = Application.CompanyName;

            mainAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            rm = new System.Resources.ResourceManager(mainAssembly.GetName().Name, mainAssembly);
            // コピーライト情報を取得
            string appCopyright = "-";
            object[] CopyrightArray = mainAssembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
            if ((CopyrightArray != null) && (CopyrightArray.Length > 0))
            {
                appCopyright = ((AssemblyCopyrightAttribute)CopyrightArray[0]).Copyright;
            }

            // 詳細情報を取得
            string appDescription = "-";
            object[] DescriptionArray =
              mainAssembly.GetCustomAttributes(
                typeof(AssemblyDescriptionAttribute), false);
            if ((DescriptionArray != null) && (DescriptionArray.Length > 0))
            {
                appDescription = ((AssemblyDescriptionAttribute)DescriptionArray[0]).Description;
            }

            // lblProductName.Text = appProductName;
            lblCopyright.Text = appCopyright;
            lblVersion.Text = "Version " + appVersion;

            version = "ImacocoNow/" + appVersion + " .NET Framework 4.0";
            ImacocoNowManager.version = version;

            noPostPoint = new List<GPSPoint>();

            // 使えるシリアルポートをリストアップする
            string[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            foreach (string port in ports)
            {
                if (cbSerial.Items.IndexOf(port) == -1)
                {
                    cbSerial.Items.Add(port);
                }
            }
            // Location API をポートとしてリストアップ
            cbSerial.Items.Add("API");

            rnd = new Random();

            loadSettings();

            SetStatusText("");
            SetGPSText();
            SetCounterText();
            stLblImakoko.Text = "";
            stLblNoPost.Text = "";
            stLblSave.Text = "";
            stLblGPSPost.Text = "";
            cbIcon.Text = "三角形";

            // ListViewコントロールのプロパティを設定
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.View = View.Details;

            // 列（コラム）ヘッダの作成
            ColumnHeader columnData = new ColumnHeader();
            columnData.TextAlign = HorizontalAlignment.Right;
            columnData.Text = "距離(km)";
            columnData.Width = 120;

            ColumnHeader columnName = new ColumnHeader();
            columnName.Text = "ID";
            columnName.Width = 180;

            ColumnHeader columnType = new ColumnHeader();
            columnType.Text = "ニックネーム";
            columnType.Width = 180;

            //ColumnHeader columnDetail = new ColumnHeader();
            //columnDetail.Text = "移動";
            //columnDetail.Width = 30;

            ColumnHeader[] colHeaderRegValue = { columnData, columnName, columnType /*, columnDetail*/ };
            listView1.Columns.AddRange(colHeaderRegValue);

            listView1.SmallImageList = new ImageList();
            for (int i = 0; i < 360; i++)
            {
                string resource = string.Format("PCGPS.Resources.dir-{0}.png", i);
                listView1.SmallImageList.Images.Add(new Bitmap(mainAssembly.GetManifestResourceStream(resource)));
            }

            // プラグインの読み込み
            try
            {
                pluginManager = new PluginManager(typeof(ImacocoNowPlugin));

                Assembly myAssembly = Assembly.GetEntryAssembly();
                string path = Path.GetDirectoryName(myAssembly.Location);
                pluginManager.SearchPlugin(path);
                pluginManager.SearchPlugin(path + @"\plugin");

                cbPlugin.Items.Clear();
                foreach (PluginBase p in pluginManager.LoadedPlugins)
                {
                    ImacocoNowPlugin plugin = (ImacocoNowPlugin)p;
                    cbPlugin.Items.Add(plugin.PluginName());
                }
                if (cbPlugin.Items.Count > 0)
                {
                    cbPlugin.SelectedIndex = 0;
                }
            }
            catch (Exception)
            {
            }

            Microsoft.Win32.SystemEvents.PowerModeChanged += new Microsoft.Win32.PowerModeChangedEventHandler(SystemEvents_PowerModeChanged);

            t = new Thread(this.ThreadEntry);
            t.IsBackground = true;
            t.Start();
            t2 = new Thread(this.AutoPostThreadEntry);
            t2.IsBackground = true;
            t2.Start();
            t3 = new Thread(this.AutoTwitThreadEntry);
            t3.IsBackground = true;
            t3.Start();

            if (Properties.Settings.Default.SaveWindowLocation)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = Properties.Settings.Default.WindowLocation;
            }

            if (args != null)
            {
                bool connect = false;
                foreach (string s in args)
                {
                    switch (s)
                    {
                        case "/ap":
                            chkAutoPost.Checked = true;
                            break;
                        case "/at":
                            chkAutoTwit.Checked = true;
                            break;
                        case "/connect":
                            connect = true;
                            break;
                        default:
                            break;
                    }
                }
                if (connect)
                {
                    btnCommOpenClose.PerformClick();
                }

            }

            //
            // FLASHのスピードメータ用
            //
            //tcpServer.RegisterTcpServerEvent(TcpServerEvent);
            tcpServerSpeed.Start();

            //
            // FLASHのタクシーメータ用
            //
            tcpServerTaxi.Start();

            //
            // FLASHの位置計測用
            //
            tcpServerPos.Start();
            mPosServerTimer.Start();

            //policyFileServer.RegisterTcpServerEvent(TcpServerEvent2);
            policyFileServer.Start();

            mSpeedTimer.Interval = 5000;
            mSpeedTimer.Start();

            mTaxiTimeFareTimer.Interval = 1000;
            mTaxiTimeFareTimer.Start();

            //
            // タクシーメータ初期化用
            //
            updateTaxiTime();

            //
            // タクシー料金再設定
            //
            mTaxiStatus = (TaxiStatus)Properties.Settings.Default.TaxiStatus;

            if (mTaxiStatus == TaxiStatus.Kuusha)
            {
                if (IsShinya())
                {
                    mTaxiDistance = totalDistance + TaxiHatsunoriMeter_Night;
                }
                else
                {
                    mTaxiDistance = totalDistance + TaxiHatsunoriMeter;
                }
            }
            else
            {
                fare = Properties.Settings.Default.TaxiFare;
                if (fare == TaxiHatsunoriFare)
                {
                    if (Properties.Settings.Default.TaxiRestDistance <= TaxiHatsunoriMeter)
                    {
                        mTaxiDistance = totalDistance + Properties.Settings.Default.TaxiRestDistance;
                    }
                    else
                    {
                        updateTaxiDistance();
                    }
                }
                else if (Properties.Settings.Default.TaxiRestDistance <= TaxiMeterPer90yen)
                {
                    mTaxiDistance = totalDistance + Properties.Settings.Default.TaxiRestDistance;
                }
                else
                {
                    updateTaxiDistance();
                }

                switch (mTaxiStatus)
                {
                    case TaxiStatus.Kuusha:
                        mBtnKuusha.Checked = true;
                        break;
                    case TaxiStatus.Jissha:
                        mBtnJissha.Checked = true;
                        break;
                    case TaxiStatus.Kosoku:
                        mBtnKosoku.Checked = true;
                        break;
                    case TaxiStatus.Shiharai:
                        mBtnShiharai.Checked = true;
                        break;
                }
            }

            formLoaded = true;
        }

        void SystemEvents_PowerModeChanged(object sender, Microsoft.Win32.PowerModeChangedEventArgs e)
        {
            switch (e.Mode)
            {
                case Microsoft.Win32.PowerModes.StatusChange:
                case Microsoft.Win32.PowerModes.Suspend:
                    break;
                case Microsoft.Win32.PowerModes.Resume:
                    lastPosition = null;
                    lastValidPosition = null;
                    userLocation = null;
                    prevLocation = null;
                    myLocation = null;
                    lastPostTime = new DateTime();
                    lastNMEATime = new DateTime();
                    break;
            }
        }

        Form3 fm = null;

        // 終了するときに呼び出される
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.TaxiFare = fare;
            Properties.Settings.Default.TaxiStatus = (int)mTaxiStatus;
            Properties.Settings.Default.TaxiRestDistance = mTaxiDistance-totalDistance;
            try
            {
                timer1.Enabled = false;
                serialPort1.Close();
                pluginManager.Dispose();
            }
            catch (Exception Ex)
            {
                if (debugLog != null)
                {
                    debugLog.WriteLine(Ex.Message);
                }
            }
            if (debugLog != null)
            {
                debugLog.Close();
            }
            try
            {
                tcpServerSpeed.Stop();
                tcpServerTaxi.Stop();
                tcpServerPos.Stop();
                policyFileServer.Stop();

            }
            catch (Exception Ex)
            {
            }
        }

        byte[] buf = new byte[4096];
        Encoding encoding = ASCIIEncoding.GetEncoding(1252);
        string prev_serial = "";

        private void readSerial()
        {
#if false
            lock (serialPort1)
            {
                try
                {
                    while (serialPort1.BytesToRead > 0)
                    {
                        string line = serialPort1.ReadLine();
                        line = line.Replace("\r", "").Replace("\n", "");
                        lock (nmeaQueue)
                        {
                            nmeaQueue.Enqueue(line);
                            autoEvent.Set();
                        }
                        nmea_received = true;
                    }
                }
                catch (Exception)
                {
                }
            }
#else
            try
            {
                while (serialPort1.BytesToRead != 0)
                {
                    Thread.Sleep(0);
                    int read = serialPort1.Read(buf, 0, buf.Length);

                    string s = (prev_serial + encoding.GetString(buf, 0, read)).Replace("\r", "");
                    string[] lines = s.Split('\n');
                    foreach (string line in lines)
                    {
                        if (line.Length == 0)
                        {
                            continue;
                        }
                        if (line.Length > 3 && line[line.Length - 3] == '*')
                        {
                            lock (nmeaQueue)
                            {
                                nmeaQueue.Enqueue(line);
                                autoEvent.Set();
                            }
                            prev_serial = "";
                            nmea_received = true;
                        }
                        else
                        {
                            prev_serial = line;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SetStatusText("readSerial:" + ex.Message);
            }
#endif
        }


        // シリアルポートからデータが取得したら呼ばれるイベント
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            readSerial();
        }

        // タイマーが起きたとき
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (mode_initial)
            {
                if (nmea_received)
                {
                    SetStatusText("SerialPort1.DataReceived ok.");
                    timer1.Enabled = false;
                    Properties.Settings.Default.ReceiveMode = "Event";
                }
                else
                {
                    SetStatusText("SerialPort1.DataReceived not work. Switch to timer mode.");
                    timer1.Interval = ReceiveTimerInterval;
                    Properties.Settings.Default.ReceiveMode = "Timer";
                }
            }
            else
            {
                timer1.Enabled = false;
                readSerial();
                timer1.Enabled = true;
            }

        }

        bool inProcess = false;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (!Properties.Settings.Default.UseNearAlert)
                return;

            ThreadStart ts = () =>
            {
                if (inProcess)
                    return;
                inProcess = true;
                try
                {
                    if (getImakoko())
                    {
                        checkWarning();
                    }
                }
                catch (Exception ex)
                {
                }
                inProcess = false;
            };
            Thread t = new Thread(ts);
            t.IsBackground = true;
            t.Start();
        }

        // シリアルポートが変更された
        private void cbSerial_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Port = cbSerial.Text;
        }

        // 通信速度が変更された
        private void cbBaud_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Baud = cbBaud.Text;
        }

        // ユーザー名が変更された
        private void txtFtpUSER_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.User = txtUsername.Text;
        }

        // パスワードが変更された
        private void txtFtpPASS_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Password = txtPassword.Text;
        }

        // 半径が変更された
        private void cbRadius_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Radius = cbRadius.Text;
        }

        // 自動送信間隔が変更された
        private void cbPostInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            string t = cbPostInterval.Text;
            if (t.EndsWith("秒"))
            {
                IntervalType = INTERVAL_TIME;
                int.TryParse(t.Substring(0, t.IndexOf("秒")), out PostDataInterval);
            }
            else if (t.EndsWith("m"))
            {
                IntervalType = INTERVAL_DISTANCE;
                int.TryParse(t.Substring(0, t.Length - 1), out PostDataInterval);
            }
            Properties.Settings.Default.IntervalType = IntervalType;
            Properties.Settings.Default.PostDataInterval = PostDataInterval;
        }

        // 自動送信チェックボックスが変更された
        private void chkAutoPost_CheckedChanged(object sender, EventArgs e)
        {
            SetStLblGPSPost();
            SetControlStatus(prgAutoPost, chkAutoPost.Checked);
        }

        // デバッグチェックボックスが変更された
        private void cbDebug_CheckedChanged(object sender, EventArgs e)
        {
            // 乱数発生
            debugDir = rnd.NextDouble() * 360;
            debugLon = 137.4 + rnd.NextDouble() * 2;
            debugLat = 35.4 + rnd.NextDouble() * 1.4;
        }

        private void chkSaveLog_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SaveFile = chkSaveLog.Checked;
        }

        private void txtMapURL_TextChanged(object sender, EventArgs e)
        {
            btnTinyURL.Enabled = true;
            Properties.Settings.Default.MapURL = txtMapURL.Text;
        }

        private void cbLatLon_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AddLatLon = chkLatLon.Checked;
        }

        private void cbMapURL_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AddMapURL = chkMapURL.Checked;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkLabel1.Text);
        }

        private void txtImakoko_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ImakokoHeader = txtImakoko.Text;
        }

        private void txtTinyURL_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.TinyURL = txtTinyURL.Text;
        }

        private void chkSaveServer_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ServerSave = chkSaveServer.Checked;
        }

        private void chkSpeedFilter_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SpeedFilter = chkSpeedFilter.Checked;
        }

        private void chkHashTag_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.HashTag = chkHashTag.Checked;
        }


        private void chkSound_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.UseSound = chkSound.Checked;
        }

        private void chkYomiage_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.UseYomiage = chkYomiage.Checked;
        }

        private void chkNeverShow_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.NeverDisplayErrorDialog = chkNeverShow.Checked;
        }

        private void chkRestart_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.RestartOnError = chkRestart.Checked;
        }

        private void chkSend_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SendError = chkSend.Checked;
        }


        private void txtProxyServer_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ProxyServer = txtProxyServer.Text;
        }

        private void txtProxyPort_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.ProxyPort = ushort.Parse(txtProxyPort.Text);
            }
            catch (Exception)
            {
            }
        }

        private void chkUseNearAlert_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.UseNearAlert = chkUseNearAlert.Checked;
        }


        private void cbNoSameAddress_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.NoSameAddress = cbNoSameAddress.Checked;
        }

        private void cbRaderRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.RaderRange = int.Parse(cbRaderRange.SelectedItem.ToString());
            }
            catch (Exception)
            {
            }
        }
        private void cbAlertCheckInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.CheckAlertInterval = int.Parse(cbAlertCheckInterval.SelectedItem.ToString());
            }
            catch (Exception)
            {
            }
        }

        private void rbYomiageSoftalk_CheckedChanged(object sender, EventArgs e)
        {
            if (rbYomiageSoftalk.Checked)
            {
                Properties.Settings.Default.YomiageTool = "Softalk";
                txtSoftalk.Enabled = true;
                btnSoftalkSetting.Enabled = true;
            }
        }

        private void rbBouyomi_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBouyomi.Checked)
            {
                Properties.Settings.Default.YomiageTool = "Bouyomi";
                txtSoftalk.Enabled = false;
                btnSoftalkSetting.Enabled = false;
            }
        }


        #endregion

        #region コントロールへデータ設定
        // errTxtコントロールに文字列を表示する
        private void SetStatusText(string text)
        {
            if (this.statusStrip1.InvokeRequired)
            {
                SetTextCallback c = new SetTextCallback(SetStatusText);
                Invoke(c, new object[] { text });
            }
            else
            {
                txtErr.Text = text;
                if (debugLog != null)
                {
                    debugLog.WriteLine(text);
                }
            }

        }

        // カウンタ文字列を表示する
        private void SetCounterText()
        {
            if (this.statusStrip1.InvokeRequired)
            {
                SetDataCallback c = new SetDataCallback(SetCounterText);
                Invoke(c);
            }
            else
            {
                stLblNMEACount.Text = string.Format("{0:D}", nmeaCount) + "/" + string.Format("{0:D}", sentenseErrorCount);
            }
        }

        private void SetStLblNoPost()
        {
            if (statusStrip1.InvokeRequired)
            {
                SetDataCallback c = new SetDataCallback(SetStLblNoPost);
                Invoke(c);
            }
            else
            {
                stLblNoPost.Text = inNoPost ? "非通知" : "";
            }
        }

        private void SetStLblSave()
        {
            if (statusStrip1.InvokeRequired)
            {
                SetDataCallback c = new SetDataCallback(SetStLblNoPost);
                Invoke(c);
            }
            else
            {
                stLblSave.Text = chkSaveLog.Checked ? "保存中" : "";
            }
        }

        private void SetStLblGPSPost()
        {
            if (statusStrip1.InvokeRequired)
            {
                SetDataCallback c = new SetDataCallback(SetStLblNoPost);
                Invoke(c);
            }
            else
            {
                stLblGPSPost.Text = chkAutoPost.Checked ? "自動送信" : "";
                stLblImakoko.Text = chkAutoTwit.Checked ? "自動ｲﾏｺｺ" : "";
            }
        }


        // GPS情報を表示する
        private void SetGPSText()
        {
            if (this.txtGpsLat.InvokeRequired)
            {
                SetDataCallback c = new SetDataCallback(SetGPSText);
                Invoke(c);
            }
            else
            {
                // gpsTime, Lat.ToString(), Lon.ToString(), gpsStatus.ToString(), gpsC, gpsH
                txtGpsLat.Text = txtGpsLat2.Text = Math.Round(Lat, 6).ToString();
                txtGpsLon.Text = txtGpsLon2.Text = Math.Round(Lon, 6).ToString();
                txtGpsH.Text = gpsH;
                txtGpsTime.Text = gpsTime;
                txtGpsCount.Text = gpsC;
                txtGpsMode.Text = gpsStatus;
                int idx;
                int.TryParse(gpsStatus, out idx);
                stLblGPSMode.Text = gpsMode[idx];
                txtDOP.Text = gpsHDOP;
                txtGpsMode.Text = gpsStatus;
                txtGpsDirection.Text = gpsD;
                txtGpsVelocity.Text = txtGpsVelocity2.Text = string.Format("{0:F}", Velocity);
                txtDistance.Text = txtDistance2.Text = string.Format("{0:F1}", distance);
                txtAcc.Text = string.Format("{0:F3}", acc);

                if (!serialPort1.IsOpen && !location_api_used)
                {
                    lblIndicator.ForeColor = Color.Red;
                    btnFTPPost.Enabled = false;
                    btnNoPostArea.Enabled = false;
                    btnGetAddress.Enabled = false;
                }
                else
                {
                    if (valid != "V")
                    {
                        // GPSステータスが受信状態なら緑
                        lblIndicator.ForeColor = Color.Green;
                        btnFTPPost.Enabled = true;
                        btnNoPostArea.Enabled = true;
                        btnGetAddress.Enabled = true;
                    }
                    else
                    {
                        // GPSステータスが受信状態でないなら黄
                        lblIndicator.ForeColor = Color.Yellow;
                        btnFTPPost.Enabled = false;
                        btnNoPostArea.Enabled = false;
                        btnGetAddress.Enabled = false;
                    }
                }

                if (updateAlert)
                {
                    ShowAlertList();
                    updateAlert = false;
                }
            }
        }

        DateTime debugPrevTime = new DateTime(2000,1,1);
        // 経度を取得する
        private string GetRandomGPSLat()
        {
            if (this.txtGpsLat.InvokeRequired)
            {
                GetTextCallback c = new GetTextCallback(GetRandomGPSLat);
                return (string)Invoke(c);
            }
            else
            {
                string lat;
                if (chkDebug.Checked)
                {
                    DateTime now = DateTime.Now;
                    if (debugPrevTime != new DateTime(2000, 1, 1))
                    {
                        // 角度を10度の範囲で変化
                        debugDir = (debugDir + (rnd.Next(20) - 10) + 360D) % 360D;
                        Double radian = debugDir * (Math.PI / 180);

                        TimeSpan ts = now - debugPrevTime;
                        // 移動距離
                        Double dist = (0.00005 + rnd.NextDouble() / 1000) * (ts.TotalMilliseconds / 1000);
                        debugLon += Math.Cos(Math.PI / 180 * 90 - radian) * dist;
                        debugLat += Math.Sin(Math.PI / 180 * 90 - radian) * dist;
                    }
                    txtGpsLat.Text = lat = Math.Round(debugLat, 6).ToString();
                    txtGpsLon.Text = Math.Round(debugLon, 6).ToString();
                    txtGpsDirection.Text = Math.Round(debugDir, 6).ToString();
                    debugPrevTime = now;
                }
                else
                {
                    lat = txtGpsLat.Text;
                }
                return lat;
            }
        }

        // 経度を取得する
        private string GetGPSLon()
        {
            if (this.txtGpsLon.InvokeRequired)
            {
                GetTextCallback c = new GetTextCallback(GetGPSLon);
                return (string)Invoke(c);
            }
            else
            {
                return txtGpsLon.Text;
            }
        }

        // 方位を取得する
        private string GetGPSDirection()
        {
            if (this.txtGpsDirection.InvokeRequired)
            {
                GetTextCallback c = new GetTextCallback(GetGPSDirection);
                return (string)Invoke(c);
            }
            else
            {
                return txtGpsDirection.Text;
            }
        }


        private string GetRadius()
        {
            if (this.cbRadius.InvokeRequired)
            {
                GetTextCallback c = new GetTextCallback(GetRadius);
                return (string)Invoke(c);
            }
            else
            {
                return cbRadius.Text;
            }
        }

        private void SetAddressText(string r)
        {
            if (this.txtAddress.InvokeRequired) {
                SetTextCallback c = new SetTextCallback(SetAddressText);
                Invoke(c, new Object[] { r });
            } else {
                txtAddress.Text = r;
            }
        }
        #endregion

        bool checkReceive()
        {
            if (serialPort1.BytesToRead < 50)
            {
                Thread.Sleep(1000);
            }

            int sz = serialPort1.Read(buf, 0, 1024);
            string s = Encoding.GetEncoding(0).GetString(buf);
            string[] lines = s.Split('\n');
            foreach (string line in lines)
            {
                string tmp = line.Replace("\r", "");

                if (tmp[0] != '$')
                {
                    continue;
                }
                if (tmp[tmp.Length - 3] == '*')
                {
                    if (Util.IsValidSentense(tmp))
                    {
                        SetStatusText(cbSerial.Text + ": " + cbBaud.Text + "bps OK");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        private void scan()
        {
            cbSerial.Enabled = false;
            cbBaud.Enabled = false;
            btnScan.Enabled = false;

            Form5 fm = new Form5();
            fm.Show(this);

            string[] ports = new string[cbSerial.Items.Count];
            cbSerial.Items.CopyTo(ports, 0);
            string[] speeds = new string[cbBaud.Items.Count];
            cbBaud.Items.CopyTo(speeds, 0);
            string s_speed = "";
            string s_port = "";

            Thread t = new Thread(
                delegate()
                {
                    bool ok = false;
                    foreach (string port in ports)
                    {
                        s_port = port;
                        foreach (string speed in speeds)
                        {
                            s_speed = speed;
                            fm.Label = port + ": " + speed + "bps";
                            try
                            {
                                serialPort1.BaudRate = int.Parse(speed);
                                serialPort1.PortName = port;
                                serialPort1.Open();
                                serialPort1.DiscardInBuffer();

                                try
                                {
                                    ok = checkReceive();
                                }
                                catch (Exception /*e2*/)
                                {
                                    //SetStatusText(e2.Message);
                                }
                            }
                            catch (Exception /*e1*/)
                            {
                                //SetStatusText(e1.Message);
                            }
                            if (serialPort1.IsOpen)
                            {
                                serialPort1.Close();
                            }
                            Thread.Sleep(10);
                            if (ok)
                                break;
                            if (fm.DialogResult == DialogResult.Abort)
                            {
                                return;
                            }
                        }
                        if (ok)
                            break;
                    }
                    if (ok)
                    {
                        if (serialPort1.IsOpen)
                        {
                            serialPort1.Close();
                        }
                    }
                    else
                    {
                        SetStatusText("Cannot find GPS Receiver/Logger.");
                    }
                }
            );
            t.Start();
            while (t.IsAlive)
            {
                fm.SetLabel();
                Application.DoEvents();
                Thread.Sleep(100);
            }
            fm.Hide();
            cbBaud.Text = s_speed;
            cbSerial.Text = s_port;
            cbSerial.Enabled = true;
            cbBaud.Enabled = true;
            btnScan.Enabled = true;
        }

        private void SetProgressBar()
        {
            if (prgAutoImakoko.InvokeRequired)
            {
                SetDataCallback c = new SetDataCallback(SetProgressBar);
                Invoke(c);
            }
            else
            {
                // 自動イマココ
                if (prgAutoImakoko.Enabled)
                {
                    Double left = (DateTime.Now - lastImakoko).TotalSeconds;
                    int val = (int)(left / AutoImakokoInterval * 100);
                    if (val < 0) val = 0;
                    if (val > 100) val = 100;
                    prgAutoImakoko.Value = val;
                }
                else
                {
                    prgAutoImakoko.Value = 0;
                }

                if (prgAutoPost.Enabled)
                {
                    int val;
                    if (IntervalType == INTERVAL_TIME)
                    {
                        Double left = (DateTime.Now - lastPostTime).TotalSeconds;
                        if (left < PostDataInterval)
                        {
                            val = (int)(left / PostDataInterval * 100);
                        }
                        else
                        {
                            val = (int)(left / MaximumPostInterval * 100);
                        }
                    }
                    else
                    {
                        val = (int)(distance / PostDataInterval * 100);
                    }
                    if (val < 0) val = 0;
                    if (val > 100) val = 100;
                    prgAutoPost.Value = val;
                }
                else
                {
                    prgAutoPost.Value = 0;
                }            
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            scan();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fm = new Form3();
            fm.Show();
        }

        private void SetControlStatus(Control c, bool enabled)
        {
            if (c.InvokeRequired)
            {
                SetControlStatusCallback d = new SetControlStatusCallback(SetControlStatus);
                Invoke(d, new Object[] { c, enabled });
            }
            else
            {
                c.Enabled = enabled;
            }
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            btnTwitterPost.Enabled = txtAddress.Text.Length != 0;
        }

        private void chkAutoTwit_CheckedChanged(object sender, EventArgs e)
        {
            SetStLblGPSPost();
            SetControlStatus(prgAutoImakoko, chkAutoTwit.Checked);
        }

        private void cbIcon_SelectedIndexChanged(object sender, EventArgs e)
        {
            icon = cbIcon.Text;
            iconIndex = cbIcon.SelectedIndex;
            Properties.Settings.Default.IconIndex = iconIndex;
        }


        bool updateAlert = false;
        /*
        private double _dLati = 0;
        private double _dLong = 0;
        private double _dDir = 0;
        
        Dictionary<string, Dictionary<string, string>> userInfo = new Dictionary<string,Dictionary<string,string>>();
        Dictionary<string, Dictionary<string, string>> prevInfo = null;
        */
        LatestPoints userLocation = null;
        LatestPoints prevLocation = null;
        ImakokoPoint myLocation = null;

        private bool getImakoko()
        {
            WebRequest req = WebRequest.Create("http://imakoko-gps.appspot.com/api/latest?user=all");
            try
            {
                WebResponse res = req.GetResponse();
                Encoding enc = Encoding.GetEncoding("UTF-8");

                using (Stream st = res.GetResponseStream())
                using (StreamReader sr = new StreamReader(st, enc))
                {
                    myLocation = null;
                    Dictionary<string, Dictionary<string, string>> userInfo = new Dictionary<string, Dictionary<string, string>>();

                    string ret = sr.ReadToEnd();
                    if (ret.StartsWith("("))
                    {
                        ret = ret.Substring(1);
                    }
                    if (ret.EndsWith(")"))
                    {
                        ret = ret.Substring(0, ret.Length - 1);
                    }

                    prevLocation = userLocation;
                    userLocation = JsonConvert.DeserializeObject<LatestPoints>(ret);

                    if (userLocation.result == 1)
                    {
                        myLocation = findUser(userLocation.points, Properties.Settings.Default.User);
                        //myLocation = userLocation.points[0];
#if DEBUG
                        myLocation = new ImakokoPoint();
                        myLocation.lat = 35.65722;
                        myLocation.lon = 139.27204;
                        myLocation.dir = 0.0;
#endif
                        if (myLocation != null)
                        {
                            // 近接情報から自分を取り除く
                            List<ImakokoPoint> list = new List<ImakokoPoint>(userLocation.points);
                            list.Remove(myLocation);
                            userLocation.points = list.ToArray();

                            foreach (ImakokoPoint p in userLocation.points)
                            {
                                Util.GetKyoriHoui(myLocation.lon, myLocation.lat, p.lon, p.lat, out p.distance, out p.direction);
                                p.n_direction = (p.direction - p.dir + 360.0) % 360.0;

                                Dictionary<string, string> GPSData = new Dictionary<string, string>();
                                GPSData.Add(USER, p.user);
                                GPSData.Add(LATI, p.lat.HasValue ? p.lat.ToString() : "0.0");
                                GPSData.Add(LONG, p.lon.HasValue ? p.lon.ToString() : "0.0");
                                GPSData.Add(HEADING, p.dir.HasValue ? p.dir.ToString() : "0.0");
                                GPSData.Add(DIST, p.distance.ToString());
                                GPSData.Add(N_DIRECTION, p.direction.ToString());
                                GPSData.Add(DIRECTION, p.n_direction.ToString());
                                userInfo.Add(p.user, GPSData);
                            }

                            foreach (PluginBase p in pluginManager.LoadedPlugins)
                            {
                                ImacocoNowPlugin plugin = (ImacocoNowPlugin)p;
                                ThreadStart ts = () =>
                                {
                                    plugin.OnGetUserLocation(userInfo);
                                };
                                Thread t = new Thread(ts);
                                t.IsBackground = true;
                                t.Start();
                            }
                            SetStatusText("近接ユーザーの情報を取得しました");
                            updateAlert = true;
                            return true;
                        }
                    }
                    
                }
            }
            catch (Exception e)
            {
                SetStatusText("近接ユーザー情報の取得に失敗しました");
            }
            return false;
        }

        private ImakokoPoint findUser(ImakokoPoint[] points, string user)
        {
            try {
            foreach (ImakokoPoint p in points)
            {
                if (p.user == user)
                    return p;
            }
            } catch(Exception e) {
            }
            return null;
        }

        private void checkWarning()
        {
            if (prevLocation == null)
                return;

            double raderRange = Properties.Settings.Default.RaderRange * 1000;

            bool raderIn = false;
            foreach (ImakokoPoint p in userLocation.points)
            {
                double prevDist = -1;
                ImakokoPoint prevUserLocation = findUser(prevLocation.points, p.user);
                if (prevUserLocation != null && prevUserLocation.distance.HasValue)
                    prevDist = (double)prevUserLocation.distance;

                // 一つ前のリストにない or レーダー範囲内に入ったデータ
                if (p.distance <= raderRange && p.distance > 0)
                {
                    if (prevDist < 0 || prevDist > raderRange)
                    {
                        if (!raderIn)
                        {
                            raderIn = true;
                            if (Properties.Settings.Default.SoundRaderIn != "")
                            {
                                Util.PlaySEFromFile(Properties.Settings.Default.SoundRaderIn);
                            }
                            else
                            {
                                Util.PlaySE("PCGPS.Resources.b_013.wav");
                            }
                            Thread.Sleep(1000);
                        }
                        Util.Talk(Properties.Settings.Default.RaderInText
                            .Replace("%USER%", p.nickname)
                            .Replace("%DIST%", p.distance.ToString()));
                    }
                }
            }

            bool raderOut = false;
            // 一つ前のリストにはあるが今のリストにはない or レーダー範囲外に出たデータ
            foreach (ImakokoPoint p in prevLocation.points)
            {
                ImakokoPoint cp = findUser(userLocation.points, p.user);
                double prevDist = raderRange * 2;
                if (p.distance.HasValue)
                {
                    prevDist = (double)p.distance;
                    if (cp != null)
                        cp.prev_distance = p.distance;
                }

                if (prevDist <= raderRange && (cp == null || cp.distance > raderRange))
                {
                    if (!raderOut)
                    {
                        raderOut = true;
                        if (Properties.Settings.Default.SoundRaderOut != "")
                        {
                            Util.PlaySEFromFile(Properties.Settings.Default.SoundRaderOut);
                        }
                        else
                        {
                            Util.PlaySE("PCGPS.Resources.b_018.wav");
                        }
                        Thread.Sleep(1000);
                    }
                    Util.Talk(Properties.Settings.Default.RaderOutText.Replace("%USER%", p.nickname));
                }
            }

        }
            

        delegate void GenericCallback();

        void ShowAlertList()
        {
            string resource = string.Format("PCGPS.Resources.compass-{0}.png", (int)myLocation.dir);
            using (Stream st = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
            {
                Image img = new Bitmap(st);
                picMyDirection.Image = img;
            }

            listView1.Items.Clear();
            List<ImakokoPoint> list = new List<ImakokoPoint>(userLocation.points);
            list.Sort(
                delegate(ImakokoPoint left, ImakokoPoint right)
                {
                    if (!left.distance.HasValue)
                        return -1;
                    if (!right.distance.HasValue)
                        return 1;
                    return (int)(left.distance - right.distance);
                }
            );

            int idx = 0;
            foreach (ImakokoPoint p in list)
            {
                if (!p.distance.HasValue || p.distance < 0)
                    continue;

                double dPrevDist = p.prev_distance.HasValue ? (double)p.prev_distance : -1;
                string s = "";
                if (p.prev_distance >= 0)
                {
                    double diff = (double)(p.prev_distance - p.distance);

                    if (Math.Abs(diff) > 0.05)
                    {
                        s = diff < 0 ? "△" : "▼" ;
                    }
                }

                string[] items = new string[]{
                        ((double)p.distance / 1000d).ToString("0.00") + " " + s,
                        p.user,
                        p.nickname,
                        /*""*/
                };
                ListViewItem data = new ListViewItem(items);
                data.ImageIndex = (int)p.direction;

                if (p.distance < Properties.Settings.Default.RaderRange * 1000)
                {
                    data.ForeColor = Color.Red;
                }

                listView1.Items.Add(data);
                if (idx < 2)
                {

                    resource = string.Format("PCGPS.Resources.dir-{0}.png", (int)p.direction);
                    using (Stream st = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
                    {
                        string txt = ((double)p.distance / 1000d).ToString("0.00") + " " + p.nickname;
                        Image img = new Bitmap(st);
                        if (idx == 0)
                        {
                            picNear1.Image = img;
                            lblNear1.Text = txt;
                            if (p.distance < Properties.Settings.Default.RaderRange * 1000)
                            {
                                lblNear1.ForeColor = Color.Red;
                            }
                            else
                            {
                                lblNear1.ForeColor = SystemColors.ControlText;
                            }
                        }
                        else
                        {
                            picNear2.Image = img;
                            lblNear2.Text = txt;
                            if (p.distance < Properties.Settings.Default.RaderRange * 1000)
                            {
                                lblNear2.ForeColor = Color.Red;
                            }
                            else
                            {
                                lblNear1.ForeColor = SystemColors.ControlText;
                            }
                        }
                    }
                    idx++;
                }
            }
        }

        private void btnSoftalkSetting_Click(object sender, EventArgs e)
        {
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.FileName = "Softalk.exe";
            openFileDialog1.Filter = "All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtSoftalk.Text = openFileDialog1.FileName;
                Properties.Settings.Default.SoftalkPath = txtSoftalk.Text;
            }
        }

        private void txtRaderOut_Leave(object sender, EventArgs e)
        {
            Properties.Settings.Default.RaderOutText = txtRaderOut.Text;
        }

        private void txtRaderIn_Leave(object sender, EventArgs e)
        {
            Properties.Settings.Default.RaderInText = txtRaderIn.Text;
        }

        private void picMyDirection_Click(object sender, EventArgs e)
        {
//            throw new Exception("Test Exception", new NotImplementedException("This function is not implemented"));
        }

        private void btnSoundPost_Click(object sender, EventArgs e)
        {
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Wave files(*.wav)|*.wav|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtSoundPost.Text = openFileDialog1.FileName;
                Properties.Settings.Default.SoundPost = txtSoundPost.Text;
            }
        }

        private void btnSoundTwit_Click(object sender, EventArgs e)
        {
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Wave files(*.wav)|*.wav|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtSoundTwit.Text = openFileDialog1.FileName;
                Properties.Settings.Default.SoundTwit = txtSoundTwit.Text;
            }
        }

        private void btnSoundRaderOut_Click(object sender, EventArgs e)
        {
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Wave files(*.wav)|*.wav|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtSoundRaderOut.Text = openFileDialog1.FileName;
                Properties.Settings.Default.SoundRaderOut = txtSoundRaderOut.Text;
            }
        }

        private void btnSoundRaderIn_Click(object sender, EventArgs e)
        {
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Wave files(*.wav)|*.wav|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtSoundRaderIn.Text = openFileDialog1.FileName;
                Properties.Settings.Default.SoundRaderIn = txtSoundRaderIn.Text;
            }
        }

        private void btnSoundReset_Click(object sender, EventArgs e)
        {
            txtSoundPost.Text = "";
            txtSoundRaderIn.Text = "";
            txtSoundRaderOut.Text = "";
            txtSoundTwit.Text = "";
            Properties.Settings.Default.SoundPost = "";
            Properties.Settings.Default.SoundRaderIn = "";
            Properties.Settings.Default.SoundRaderOut = "";
            Properties.Settings.Default.SoundTwit = "";
        }

        private void chkTwitLocation_CheckedChanged(object sender, EventArgs e)
        {
            if (!Properties.Settings.Default.AcceptLocationTwit)
            {
                bool geoEnabled = false;
                try
                {
                    geoEnabled = TwitterManager.GeoEnabled();
                }
                catch
                {
                    MessageBox.Show("GeoTaggingの状態を確認できませんでした");
                    chkTwitLocation.CheckedChanged -= new EventHandler(chkTwitLocation_CheckedChanged);
                    chkTwitLocation.Checked = false;
                    chkTwitLocation.CheckedChanged += new EventHandler(chkTwitLocation_CheckedChanged);
                    return;
                }

                if (!geoEnabled)
                {
                    EnableGeoTaggingDialog dialog = new EnableGeoTaggingDialog();
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        Process.Start("http://twitter.com/account/settings");
                    }
                    chkTwitLocation.CheckedChanged -= new EventHandler(chkTwitLocation_CheckedChanged);
                    chkTwitLocation.Checked = false;
                    chkTwitLocation.CheckedChanged += new EventHandler(chkTwitLocation_CheckedChanged);
                }
                else
                {
                    Properties.Settings.Default.AcceptLocationTwit = true;
                }
            }
            Properties.Settings.Default.LocationTwit = chkTwitLocation.Checked;
        }

        private void cbPlugin_SelectedIndexChanged(object sender, EventArgs e)
        {
            ImacocoNowPlugin p = (ImacocoNowPlugin)pluginManager.LoadedPlugins[cbPlugin.SelectedIndex];
            btnPluginConfig.Enabled = p.HasConfigDialog();
        }

        private void btnPluginConfig_Click(object sender, EventArgs e)
        {
            ImacocoNowPlugin p = (ImacocoNowPlugin)pluginManager.LoadedPlugins[cbPlugin.SelectedIndex];
            p.OpenConfigDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkLabel2.Text);
        }

        private void btnLogDirectory_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = txtLogDirectory.Text;
            folderBrowserDialog1.ShowNewFolderButton = true;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.LogDirectory = folderBrowserDialog1.SelectedPath;
                txtLogDirectory.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnXAuth_Click(object sender, EventArgs e)
        {
            xAuthForm form = new xAuthForm();
            form.ShowDialog();
            if (Properties.Settings.Default.OAuthToken != "" && Properties.Settings.Default.OAuthTokenSecret != "")
            {
                lblOAuth.Text = "認証済み";
            }
            else
            {
                lblOAuth.Text = "未認証";
            }
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            if (formLoaded)
            {
                Properties.Settings.Default.WindowLocation = this.Location;
                Properties.Settings.Default.Save();
            }
        }

        private void chkSaveWinPos_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SaveWindowLocation = chkSaveWinPos.Checked;
            if (formLoaded)
            {
                Properties.Settings.Default.WindowLocation = this.Location;
            }
        }

        StreamWriter debugLog = null;

        private void chkDebugLog_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDebugLog.Checked)
            {
                string dir = Properties.Settings.Default.LogDirectory;
                if (!dir.EndsWith(@"\"))
                {
                    dir += @"\";
                }

                debugLog = new StreamWriter(
                     new FileStream(
                         dir + "imacoconow.log",
                         FileMode.Append,
                         FileAccess.Write
                     ),
                     Encoding.UTF8
                 );
                if (debugLog == null)
                {
                    MessageBox.Show("debug log open failed.");
                }
            }
            else
            {
                if (debugLog != null)
                {
                    debugLog.Close();
                }
                debugLog = null;
            }
        }

        private void mSpeedTimer_Tick(object sender, EventArgs e)
        {
            // 速度の更新
            if (Velocity < 0)
            {
                tcpServerSpeed.SendMessageAll("0");
            }
            else if (Velocity<1000)
            {
                tcpServerSpeed.SendMessageAll(((int)Velocity).ToString());
            }

            // 料金の更新
            updateMaxiMeter();

            // 距離計算の異常を修正
            if ((fare == TaxiHatsunoriFare && totalDistance + TaxiHatsunoriMeter < mTaxiDistance) ||
                (fare > TaxiHatsunoriFare && totalDistance + TaxiMeterPer90yen < mTaxiDistance))
            {
                updateTaxiDistance();
            }
        }





        private void mTaxiTimeFareTimer_Tick(object sender, EventArgs e)
        {
            //時間制の料金の更新
            if (Velocity > 10 || mTaxiStatus != TaxiStatus.Jissha)
            {
                updateTaxiTime();
            }
            else
            {
                if (DateTime.Now > mTaxiTime)
                {
                    fare += TaxiFareUnit;
                    updateTaxiTime();
                    updateMaxiMeter();
                }
            }
        }

        private void mBtnKuusha_CheckedChanged(object sender, EventArgs e)
        {
            if (mBtnKuusha.Checked)
            {
                mBtnKuusha.Enabled = false;
                mBtnJissha.Checked = false;
                mBtnKosoku.Checked = false;
                mBtnShiharai.Checked = false;
                mBtnKuusha.BackColor = Color.Red;
            }
            else
            {
                mBtnKuusha.Enabled = true;
                mBtnKuusha.BackColor = Color.DarkRed;
            }

            mTaxiStatus = TaxiStatus.Kuusha;
            updateTaxiTime();
            if (IsShinya())
            {
                mTaxiDistance = totalDistance + TaxiHatsunoriMeter_Night;
            }
            else
            {
                mTaxiDistance = totalDistance + TaxiHatsunoriMeter;
            }
            fare = TaxiHatsunoriFare;
            lastFare = TaxiHatsunoriFare;
            updateMaxiMeter();
        }

        private void mBtnJissha_CheckedChanged(object sender, EventArgs e)
        {
            if (mBtnJissha.Checked)
            {
                mBtnJissha.Enabled = false;
                mBtnKuusha.Checked = false;
                mBtnKosoku.Checked = false;
                mBtnShiharai.Checked = false;
                mBtnJissha.BackColor = Color.Cyan;
            }
            else
            {
                mBtnJissha.Enabled = true;
                mBtnJissha.BackColor = Color.CadetBlue;
            }

            mTaxiStatus = TaxiStatus.Jissha;

            // 時間制の開始をリセット
            updateTaxiTime();

            // 距離制の設定をリセット
            if (IsShinya())
            {
                mTaxiDistance = totalDistance + TaxiHatsunoriMeter_Night;
            }
            else
            {
                mTaxiDistance = totalDistance + TaxiHatsunoriMeter;
            }

            updateMaxiMeter();
        }

        private void mBtnShiharai_CheckedChanged(object sender, EventArgs e)
        {
            if (mBtnShiharai.Checked)
            {
                mBtnShiharai.Enabled = false;
                mBtnKuusha.Checked = false;
                mBtnJissha.Checked = false;
                mBtnKosoku.Checked = false;
                mBtnShiharai.BackColor = Color.Yellow;
            }
            else
            {
                mBtnShiharai.Enabled = true;
                mBtnShiharai.BackColor = Color.Olive;
            }

            mTaxiStatus = TaxiStatus.Shiharai;

            updateMaxiMeter();
        }

        private void mBtnKosoku_CheckedChanged(object sender, EventArgs e)
        {
            if (mBtnKosoku.Checked)
            {
                mBtnKosoku.Enabled = false;
                mBtnKuusha.Checked = false;
                mBtnJissha.Checked = false;
                mBtnShiharai.Checked = false;
                mBtnKosoku.BackColor = Color.Lime;
            }
            else
            {
                mBtnKosoku.Enabled = true;
                mBtnKosoku.BackColor = Color.Green;
            }

            mTaxiStatus = TaxiStatus.Kosoku;

            updateMaxiMeter();
        }

        private void mPosServerTimer_Tick(object sender, EventArgs e)
        {
            if (lastValidPosition != null)
            {
                tcpServerPos.SendMessageAll(lastValidPosition.Latitude.ToString() + "," + lastValidPosition.Longitude.ToString());
            }
        }
    }
}
