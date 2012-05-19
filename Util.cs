using System;
using System.Collections.Generic;
using System.Text;
using System.Media;
using System.Reflection;
using System.Diagnostics;

namespace PCGPS
{
    class Util
    {
        static string[] scity = { "札幌市","仙台市","さいたま市","千葉市","横浜市","川崎市","新潟市","静岡市","浜松市","名古屋市",
                                    "京都市","大阪市","堺市","神戸市","岡山市","広島市","北九州市","福岡市"
                                    ,"相模原市"//, "熊本市"
                                };

        static string[] icons = { "標準", "携帯電話", "飛行機", "列車", "新幹線", "バス", "自転車", "徒歩", "バイク", "ヘリコプター", "船" };
        static double[] maxVelocity = { 600, 60, 1800, 240, 450, 200, 150, 50, 400, 800, 120 };

        // ２点間の距離を計算する
        public static Double CalcDistance(Double Lat1, Double Lon1, Double Lat2, Double Lon2)
        {
            Double dy = 6378137.0D * (Lat2 - Lat1) * Math.PI / 180.0D;
            Double dx = 6378137.0D * (Lon2 - Lon1) * Math.PI / 180.0D * Math.Cos(Lat1 * Math.PI / 180.0D);
            return Math.Sqrt(Math.Pow(dx, 2.0D) + Math.Pow(dy, 2.0D));
        }

        public static string URLEncode(string text)
        {
            return URLEncode(Encoding.UTF8.GetBytes(text));
        }

        public static string URLEncode(byte[] text)
        {
            var sb = new StringBuilder();
            foreach (char ch in text)
            {
                if (ch < 128 && char.IsLetterOrDigit(ch))
                    sb.Append(ch);
                else
                {
                    switch (ch)
                    {
                        case '-':
                        case '_':
                        case '.':
                        case '~':
                            sb.Append(ch);
                            break;
                        default:
                            sb.Append(string.Format("%{0:X2}", (int)ch));
                            break;
                    }
                }
            }
            return sb.ToString();
        }

        public static string GetPrefCity(string r)
        {
            string s_pref = "";
            int city = -1;
            string r2;
            int pref = r.IndexOf("県");
            if (pref == -1)
            {
                pref = r.IndexOf("府");
            }
            if (pref == -1)
            {
                pref = r.IndexOf("都");
            }
            if (pref == -1)
            {
                pref = r.IndexOf("道");
            }
            if (pref == -1)
            {
                throw new Exception("都道府県が判断できませんでした: [" + r + "]");
            }
            else
            {
                s_pref = r.Substring(0, pref + 1);
                r2 = r.Substring(pref + 1);
                if (s_pref == "東京都")
                {
                    city = r2.IndexOf("区");
                }
                if (city == -1 || city >= 4)
                {
                    city = r2.IndexOf("市");
                    if (city != -1)
                    {
                        string s_city = r2.Substring(0, city + 1);
                        if (Array.IndexOf(scity, s_city) != -1)
                        {
                            // 政令指定都市
                            int ku = r2.IndexOf("区", city + 1);
                            if (ku != -1)
                            {
                                city = ku;
                            }
                        }
                    }
                }
                if (city == -1)
                {
                    city = r2.IndexOf("町");
                }
                if (city == -1)
                {
                    city = r2.IndexOf("村");
                }
                if (city == -1)
                {
                    throw new Exception("市区町村が判断できませんでした: [" + r + "]");
                }
            }
            return s_pref + r2.Substring(0, city + 1);
        }

        // Returns True if a sentence's checksum matches the 
        // calculated checksum
        public  static bool IsValidSentense(string sentence)
        {
            // Compare the characters after the asterisk to the calculation
            return sentence.Substring(sentence.IndexOf("*") + 1) ==
              GetChecksum(sentence);
        }

        // Calculates the checksum for a sentence
        public static string GetChecksum(string sentence)
        {
            // Loop through all chars to get a checksum
            int Checksum = 0;
            foreach (char Character in sentence)
            {
                if (Character == '$')
                {
                    // Ignore the dollar sign
                }
                else if (Character == '*')
                {
                    // Stop processing before the asterisk
                    break;
                }
                else
                {
                    try // 2009.09.19 Added by y3sei
                    { // 2009.09.19 Added by y3sei
                        // Is this the first value for the checksum?
                        if (Checksum == 0)
                        {
                            // Yes. Set the checksum to the value
                            Checksum = Convert.ToByte(Character);
                        }
                        else
                        {
                            // No. XOR the checksum with this character's value
                            Checksum = Checksum ^ Convert.ToByte(Character);
                        }
                    } // 2009.09.19 Added by y3sei
                    catch (Exception) // 2009.09.19 Added by y3sei
                    { // 2009.09.19 Added by y3sei
                        Checksum = 0; // 必ずエラーになるようにする // 2009.09.19 Added by y3sei
                    } // 2009.09.19 Added by y3sei
                }
            }
            // Return the checksum formatted as a two-character hexadecimal
            return Checksum.ToString("X2");
        }

        public static int GetIconType(string name)
        {
            int idx = Array.IndexOf<string>(icons, name);
            if (idx == -1)
            {
                if (name == "Twitter")
                {
                    idx = 99;
                }
                else
                {
                    idx = 0;
                }
            }
            return idx;
        }

        public static double GetMaxVelocity(int iconType)
        {
            try
            {
                return maxVelocity[iconType];
            }
            catch (Exception)
            {
                return 2000;
            }
        }

        public static void PlaySE(string resource)
        {
            if (!Properties.Settings.Default.UseSound)
            {
                return;
            }

            Assembly mainAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            SoundPlayer player = new SoundPlayer(mainAssembly.GetManifestResourceStream(resource));
            player.Play();
        }

        public static void PlaySEFromFile(string path)
        {
            if (!Properties.Settings.Default.UseSound)
            {
                return;
            }

            SoundPlayer player = new SoundPlayer(path);
            player.Play();
        }


        public static void Talk(string text)
        {
            if (!Properties.Settings.Default.UseYomiage)
            {
                return;
            }

            if (Properties.Settings.Default.YomiageTool == "Softalk")
            {
                if (Properties.Settings.Default.SoftalkPath != "")
                {
                    Process.Start(Properties.Settings.Default.SoftalkPath, text);
                }
            }
            else if (Properties.Settings.Default.YomiageTool == "Bouyomi")
            {
                BouyomiChanClient.Talk(text);
            }
        }

        private static double ER = 6378137.0D;
        public static void GetKyoriHoui(double? Mypx, double? Mypy, double? Topx, double? Topy, out double? Kyori, out double? Houi)
        {
            if (!(Mypx.HasValue && Mypy.HasValue && Topx.HasValue && Topy.HasValue))
            {
                Kyori = -1;
                Houi = 0;
                return;
            }
            //Mypx　位置１経度 Mypy 位置２緯度　LHT座標
            //Topx　位置２経度 Topy 位置２緯度　LHT座標
            //Kyori 計算結果距離　km　Houi 計算結果方位　度
            double xx, ram, sig, ssig;
            double mx, my, tx, ty;
            //２点の位置を設定
            mx = (double)Mypx;
            tx = (double)Topx;
            my = (double)Mypy;
            ty = (double)Topy;
            if (mx == tx && my == ty)
            { //010711
                Kyori = 0.0;
                Houi = 0.0;
                return;
            }
            //ラジアン変換
            mx = mx * Math.PI / 180;
            my = my * Math.PI / 180;
            tx = tx * Math.PI / 180;
            ty = ty * Math.PI / 180;
            //距離を求める
            ram = tx - mx;
            xx = Math.Sin(my) * Math.Sin(ty) + Math.Cos(my) * Math.Cos(ty) * Math.Cos(ram);
            if (xx == -1)
            {
                sig = Math.PI;
            }
            else if (xx == 1)
            {
                sig = 0;
            }
            else
            {
                sig = Math.Atan(-xx / Math.Sqrt(-xx * xx + 1)) + Math.PI / 2;
            }
            Kyori = ER * sig;
            //方位を求める
            ssig = Math.Sin(sig);
            if (ssig == 0)
            {
                Houi = 0;
            }
            else
            {
                xx = Math.Cos(ty) * Math.Sin(ram) / ssig;
                if (-xx * xx + 1 < 0)
                {
                    if (Math.Sin(ram) > 0)
                    {
                        Houi = 90;
                    }
                    else
                    {
                        Houi = 270;
                    }
                }
                else if (Math.Sqrt(-xx * xx + 1) == 0)
                {
                    if (Math.Sin(ram) > 0)
                    {
                        Houi = 90;
                    }
                    else
                    {
                        Houi = 270;
                    }
                }
                else
                {
                    Houi = Math.Atan(xx / Math.Sqrt(-xx * xx + 1));
                    if (0 > Math.Cos(my) * Math.Sin(ty) - Math.Sin(my) * Math.Cos(ty) * Math.Cos(ram))
                    {
                        Houi = Math.PI - Houi;
                    }
                    Houi = Houi * 180 / Math.PI;
                    if (Houi < 0) Houi = Houi + 360;
                }
            }
        }
    }
}
