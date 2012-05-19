namespace PCGPS
    {
    partial class Form1
        {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
            {
            if (disposing && (components != null))
                {
                components.Dispose();
                }
            base.Dispose(disposing);
            }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
            {
                this.components = new System.ComponentModel.Container();
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
                this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
                this.grpGPS = new System.Windows.Forms.GroupBox();
                this.btnScan = new System.Windows.Forms.Button();
                this.cbBaud = new System.Windows.Forms.ComboBox();
                this.cbSerial = new System.Windows.Forms.ComboBox();
                this.label2 = new System.Windows.Forms.Label();
                this.label1 = new System.Windows.Forms.Label();
                this.chkSaveLog = new System.Windows.Forms.CheckBox();
                this.btnCommOpenClose = new System.Windows.Forms.Button();
                this.txtDOP = new System.Windows.Forms.TextBox();
                this.label23 = new System.Windows.Forms.Label();
                this.txtGpsDirection = new System.Windows.Forms.TextBox();
                this.txtGpsVelocity = new System.Windows.Forms.TextBox();
                this.label15 = new System.Windows.Forms.Label();
                this.label14 = new System.Windows.Forms.Label();
                this.txtGpsH = new System.Windows.Forms.TextBox();
                this.label6 = new System.Windows.Forms.Label();
                this.txtGpsCount = new System.Windows.Forms.TextBox();
                this.label10 = new System.Windows.Forms.Label();
                this.txtGpsMode = new System.Windows.Forms.TextBox();
                this.label5 = new System.Windows.Forms.Label();
                this.label4 = new System.Windows.Forms.Label();
                this.btnFTPPost = new System.Windows.Forms.Button();
                this.grpFTP = new System.Windows.Forms.GroupBox();
                this.label17 = new System.Windows.Forms.Label();
                this.label8 = new System.Windows.Forms.Label();
                this.txtPassword = new System.Windows.Forms.TextBox();
                this.txtUsername = new System.Windows.Forms.TextBox();
                this.btnTinyURL = new System.Windows.Forms.Button();
                this.txtMapURL = new System.Windows.Forms.TextBox();
                this.label36 = new System.Windows.Forms.Label();
                this.cbPostInterval = new System.Windows.Forms.ComboBox();
                this.chkAutoPost = new System.Windows.Forms.CheckBox();
                this.btnGetAddress = new System.Windows.Forms.Button();
                this.timer1 = new System.Windows.Forms.Timer(this.components);
                this.txtDistance = new System.Windows.Forms.TextBox();
                this.label21 = new System.Windows.Forms.Label();
                this.label22 = new System.Windows.Forms.Label();
                this.txtAcc = new System.Windows.Forms.TextBox();
                this.label24 = new System.Windows.Forms.Label();
                this.label25 = new System.Windows.Forms.Label();
                this.tabControl1 = new System.Windows.Forms.TabControl();
                this.main = new System.Windows.Forms.TabPage();
                this.groupBox5 = new System.Windows.Forms.GroupBox();
                this.lblNear1 = new System.Windows.Forms.Label();
                this.lblNear2 = new System.Windows.Forms.Label();
                this.picNear1 = new System.Windows.Forms.PictureBox();
                this.picNear2 = new System.Windows.Forms.PictureBox();
                this.picMyDirection = new System.Windows.Forms.PictureBox();
                this.label20 = new System.Windows.Forms.Label();
                this.label7 = new System.Windows.Forms.Label();
                this.prgAutoPost = new System.Windows.Forms.ProgressBar();
                this.prgAutoImakoko = new System.Windows.Forms.ProgressBar();
                this.chkAutoTwit = new System.Windows.Forms.CheckBox();
                this.txtGpsVelocity2 = new System.Windows.Forms.TextBox();
                this.txtGpsLat2 = new System.Windows.Forms.TextBox();
                this.txtGpsLon2 = new System.Windows.Forms.TextBox();
                this.label27 = new System.Windows.Forms.Label();
                this.label28 = new System.Windows.Forms.Label();
                this.label29 = new System.Windows.Forms.Label();
                this.label30 = new System.Windows.Forms.Label();
                this.label31 = new System.Windows.Forms.Label();
                this.txtDistance2 = new System.Windows.Forms.TextBox();
                this.label32 = new System.Windows.Forms.Label();
                this.txtAddress = new System.Windows.Forms.TextBox();
                this.btnTwitterPost = new System.Windows.Forms.Button();
                this.tabNearby = new System.Windows.Forms.TabPage();
                this.listView1 = new System.Windows.Forms.ListView();
                this.detail = new System.Windows.Forms.TabPage();
                this.label9 = new System.Windows.Forms.Label();
                this.txtGpsLat = new System.Windows.Forms.TextBox();
                this.txtGpsLon = new System.Windows.Forms.TextBox();
                this.label3 = new System.Windows.Forms.Label();
                this.label19 = new System.Windows.Forms.Label();
                this.label26 = new System.Windows.Forms.Label();
                this.txtGpsTime = new System.Windows.Forms.TextBox();
                this.setting = new System.Windows.Forms.TabPage();
                this.groupBox7 = new System.Windows.Forms.GroupBox();
                this.txtProxyPort = new System.Windows.Forms.TextBox();
                this.label45 = new System.Windows.Forms.Label();
                this.txtProxyServer = new System.Windows.Forms.TextBox();
                this.label44 = new System.Windows.Forms.Label();
                this.groupBox3 = new System.Windows.Forms.GroupBox();
                this.btnEdit = new System.Windows.Forms.Button();
                this.btnAddNoPost = new System.Windows.Forms.Button();
                this.btnDeleteNoPost = new System.Windows.Forms.Button();
                this.label13 = new System.Windows.Forms.Label();
                this.cbRadius = new System.Windows.Forms.ComboBox();
                this.label12 = new System.Windows.Forms.Label();
                this.cbNoPost = new System.Windows.Forms.ComboBox();
                this.groupBox2 = new System.Windows.Forms.GroupBox();
                this.btnLogDirectory = new System.Windows.Forms.Button();
                this.txtLogDirectory = new System.Windows.Forms.TextBox();
                this.cbIcon = new System.Windows.Forms.ComboBox();
                this.label11 = new System.Windows.Forms.Label();
                this.chkSpeedFilter = new System.Windows.Forms.CheckBox();
                this.chkSaveServer = new System.Windows.Forms.CheckBox();
                this.label34 = new System.Windows.Forms.Label();
                this.groupBox1 = new System.Windows.Forms.GroupBox();
                this.btnXAuth = new System.Windows.Forms.Button();
                this.chkTwitLocation = new System.Windows.Forms.CheckBox();
                this.chkHashTag = new System.Windows.Forms.CheckBox();
                this.txtImakoko = new System.Windows.Forms.TextBox();
                this.label37 = new System.Windows.Forms.Label();
                this.cbNoSameAddress = new System.Windows.Forms.CheckBox();
                this.chkLatLon = new System.Windows.Forms.CheckBox();
                this.txtTinyURL = new System.Windows.Forms.TextBox();
                this.chkMapURL = new System.Windows.Forms.CheckBox();
                this.lblOAuth = new System.Windows.Forms.Label();
                this.setting2 = new System.Windows.Forms.TabPage();
                this.groupBox8 = new System.Windows.Forms.GroupBox();
                this.btnSoundReset = new System.Windows.Forms.Button();
                this.btnSoundRaderIn = new System.Windows.Forms.Button();
                this.btnSoundRaderOut = new System.Windows.Forms.Button();
                this.btnSoundTwit = new System.Windows.Forms.Button();
                this.btnSoundPost = new System.Windows.Forms.Button();
                this.txtSoundRaderOut = new System.Windows.Forms.TextBox();
                this.txtSoundRaderIn = new System.Windows.Forms.TextBox();
                this.txtSoundTwit = new System.Windows.Forms.TextBox();
                this.txtSoundPost = new System.Windows.Forms.TextBox();
                this.label47 = new System.Windows.Forms.Label();
                this.label49 = new System.Windows.Forms.Label();
                this.label48 = new System.Windows.Forms.Label();
                this.label46 = new System.Windows.Forms.Label();
                this.chkSound = new System.Windows.Forms.CheckBox();
                this.groupBox6 = new System.Windows.Forms.GroupBox();
                this.chkNeverShow = new System.Windows.Forms.CheckBox();
                this.chkRestart = new System.Windows.Forms.CheckBox();
                this.chkSend = new System.Windows.Forms.CheckBox();
                this.YomiageGroup = new System.Windows.Forms.GroupBox();
                this.txtRaderIn = new System.Windows.Forms.TextBox();
                this.txtRaderOut = new System.Windows.Forms.TextBox();
                this.label43 = new System.Windows.Forms.Label();
                this.label42 = new System.Windows.Forms.Label();
                this.label40 = new System.Windows.Forms.Label();
                this.chkYomiage = new System.Windows.Forms.CheckBox();
                this.btnSoftalkSetting = new System.Windows.Forms.Button();
                this.txtSoftalk = new System.Windows.Forms.TextBox();
                this.rbBouyomi = new System.Windows.Forms.RadioButton();
                this.rbYomiageSoftalk = new System.Windows.Forms.RadioButton();
                this.groupBox4 = new System.Windows.Forms.GroupBox();
                this.chkUseNearAlert = new System.Windows.Forms.CheckBox();
                this.label39 = new System.Windows.Forms.Label();
                this.label38 = new System.Windows.Forms.Label();
                this.label35 = new System.Windows.Forms.Label();
                this.label33 = new System.Windows.Forms.Label();
                this.cbAlertCheckInterval = new System.Windows.Forms.ComboBox();
                this.cbRaderRange = new System.Windows.Forms.ComboBox();
                this.setting3 = new System.Windows.Forms.TabPage();
                this.label18 = new System.Windows.Forms.Label();
                this.chkDebugLog = new System.Windows.Forms.CheckBox();
                this.groupBox9 = new System.Windows.Forms.GroupBox();
                this.label16 = new System.Windows.Forms.Label();
                this.chkSaveWinPos = new System.Windows.Forms.CheckBox();
                this.tabPlugin = new System.Windows.Forms.TabPage();
                this.chkDebug = new System.Windows.Forms.CheckBox();
                this.button1 = new System.Windows.Forms.Button();
                this.btnDebugWindow = new System.Windows.Forms.Button();
                this.btnPluginConfig = new System.Windows.Forms.Button();
                this.label50 = new System.Windows.Forms.Label();
                this.cbPlugin = new System.Windows.Forms.ComboBox();
                this.tabAbout = new System.Windows.Forms.TabPage();
                this.label51 = new System.Windows.Forms.Label();
                this.label52 = new System.Windows.Forms.Label();
                this.label53 = new System.Windows.Forms.Label();
                this.label54 = new System.Windows.Forms.Label();
                this.pictureBox1 = new System.Windows.Forms.PictureBox();
                this.label41 = new System.Windows.Forms.Label();
                this.linkLabel2 = new System.Windows.Forms.LinkLabel();
                this.linkLabel1 = new System.Windows.Forms.LinkLabel();
                this.lblVersion = new System.Windows.Forms.Label();
                this.lblCopyright = new System.Windows.Forms.Label();
                this.lblProductName = new System.Windows.Forms.Label();
                this.statusStrip1 = new System.Windows.Forms.StatusStrip();
                this.txtErr = new System.Windows.Forms.ToolStripStatusLabel();
                this.stLblNoPost = new System.Windows.Forms.ToolStripStatusLabel();
                this.stLblImakoko = new System.Windows.Forms.ToolStripStatusLabel();
                this.stLblGPSPost = new System.Windows.Forms.ToolStripStatusLabel();
                this.stLblSave = new System.Windows.Forms.ToolStripStatusLabel();
                this.stLblNMEACount = new System.Windows.Forms.ToolStripStatusLabel();
                this.stLblGPSMode = new System.Windows.Forms.ToolStripStatusLabel();
                this.lblIndicator = new System.Windows.Forms.ToolStripStatusLabel();
                this.btnNoPostArea = new System.Windows.Forms.Button();
                this.timer2 = new System.Windows.Forms.Timer(this.components);
                this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
                this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
                this.mSpeedTimer = new System.Windows.Forms.Timer(this.components);
                this.mTaxiTimeFareTimer = new System.Windows.Forms.Timer(this.components);
                this.mBtnKuusha = new System.Windows.Forms.CheckBox();
                this.mBtnJissha = new System.Windows.Forms.CheckBox();
                this.mBtnKosoku = new System.Windows.Forms.CheckBox();
                this.mBtnShiharai = new System.Windows.Forms.CheckBox();
                this.mPosServerTimer = new System.Windows.Forms.Timer(this.components);
                this.grpGPS.SuspendLayout();
                this.grpFTP.SuspendLayout();
                this.tabControl1.SuspendLayout();
                this.main.SuspendLayout();
                this.groupBox5.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.picNear1)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.picNear2)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.picMyDirection)).BeginInit();
                this.tabNearby.SuspendLayout();
                this.detail.SuspendLayout();
                this.setting.SuspendLayout();
                this.groupBox7.SuspendLayout();
                this.groupBox3.SuspendLayout();
                this.groupBox2.SuspendLayout();
                this.groupBox1.SuspendLayout();
                this.setting2.SuspendLayout();
                this.groupBox8.SuspendLayout();
                this.groupBox6.SuspendLayout();
                this.YomiageGroup.SuspendLayout();
                this.groupBox4.SuspendLayout();
                this.setting3.SuspendLayout();
                this.groupBox9.SuspendLayout();
                this.tabPlugin.SuspendLayout();
                this.tabAbout.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
                this.statusStrip1.SuspendLayout();
                this.SuspendLayout();
                // 
                // serialPort1
                // 
                this.serialPort1.DiscardNull = true;
                this.serialPort1.DtrEnable = true;
                this.serialPort1.ReadTimeout = 500;
                this.serialPort1.RtsEnable = true;
                // 
                // grpGPS
                // 
                this.grpGPS.Controls.Add(this.btnScan);
                this.grpGPS.Controls.Add(this.cbBaud);
                this.grpGPS.Controls.Add(this.cbSerial);
                this.grpGPS.Controls.Add(this.label2);
                this.grpGPS.Controls.Add(this.label1);
                this.grpGPS.Location = new System.Drawing.Point(3, 84);
                this.grpGPS.Name = "grpGPS";
                this.grpGPS.Size = new System.Drawing.Size(262, 73);
                this.grpGPS.TabIndex = 1;
                this.grpGPS.TabStop = false;
                this.grpGPS.Text = "GPS通信ポート設定";
                // 
                // btnScan
                // 
                this.btnScan.Location = new System.Drawing.Point(174, 15);
                this.btnScan.Name = "btnScan";
                this.btnScan.Size = new System.Drawing.Size(75, 23);
                this.btnScan.TabIndex = 2;
                this.btnScan.Text = "自動設定";
                this.btnScan.UseVisualStyleBackColor = true;
                this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
                // 
                // cbBaud
                // 
                this.cbBaud.FormattingEnabled = true;
                this.cbBaud.Items.AddRange(new object[] {
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
                this.cbBaud.Location = new System.Drawing.Point(66, 41);
                this.cbBaud.Name = "cbBaud";
                this.cbBaud.Size = new System.Drawing.Size(102, 20);
                this.cbBaud.TabIndex = 4;
                this.cbBaud.SelectedIndexChanged += new System.EventHandler(this.cbBaud_SelectedIndexChanged);
                // 
                // cbSerial
                // 
                this.cbSerial.FormattingEnabled = true;
                this.cbSerial.Location = new System.Drawing.Point(66, 15);
                this.cbSerial.Name = "cbSerial";
                this.cbSerial.Size = new System.Drawing.Size(102, 20);
                this.cbSerial.TabIndex = 1;
                this.cbSerial.SelectedIndexChanged += new System.EventHandler(this.cbSerial_SelectedIndexChanged);
                this.cbSerial.TextUpdate += new System.EventHandler(this.cbSerial_SelectedIndexChanged);
                // 
                // label2
                // 
                this.label2.AutoSize = true;
                this.label2.Location = new System.Drawing.Point(11, 44);
                this.label2.Name = "label2";
                this.label2.Size = new System.Drawing.Size(53, 12);
                this.label2.TabIndex = 3;
                this.label2.Text = "通信速度";
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.Location = new System.Drawing.Point(19, 18);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(45, 12);
                this.label1.TabIndex = 0;
                this.label1.Text = "ポート名";
                // 
                // chkSaveLog
                // 
                this.chkSaveLog.AutoSize = true;
                this.chkSaveLog.Location = new System.Drawing.Point(15, 19);
                this.chkSaveLog.Name = "chkSaveLog";
                this.chkSaveLog.Size = new System.Drawing.Size(110, 16);
                this.chkSaveLog.TabIndex = 0;
                this.chkSaveLog.Text = "ファイルに保存する";
                this.chkSaveLog.UseVisualStyleBackColor = true;
                this.chkSaveLog.CheckedChanged += new System.EventHandler(this.chkSaveLog_CheckedChanged);
                // 
                // btnCommOpenClose
                // 
                this.btnCommOpenClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.btnCommOpenClose.Location = new System.Drawing.Point(374, 363);
                this.btnCommOpenClose.Name = "btnCommOpenClose";
                this.btnCommOpenClose.Size = new System.Drawing.Size(161, 45);
                this.btnCommOpenClose.TabIndex = 3;
                this.btnCommOpenClose.Text = "GPS接続";
                this.btnCommOpenClose.UseVisualStyleBackColor = true;
                this.btnCommOpenClose.Click += new System.EventHandler(this.btnCommOpenClose_Click);
                // 
                // txtDOP
                // 
                this.txtDOP.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.txtDOP.Location = new System.Drawing.Point(444, 222);
                this.txtDOP.Name = "txtDOP";
                this.txtDOP.ReadOnly = true;
                this.txtDOP.Size = new System.Drawing.Size(74, 38);
                this.txtDOP.TabIndex = 22;
                this.txtDOP.TabStop = false;
                // 
                // label23
                // 
                this.label23.AutoSize = true;
                this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.label23.Location = new System.Drawing.Point(363, 225);
                this.label23.Name = "label23";
                this.label23.Size = new System.Drawing.Size(73, 31);
                this.label23.TabIndex = 21;
                this.label23.Text = "DOP";
                // 
                // txtGpsDirection
                // 
                this.txtGpsDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.txtGpsDirection.Location = new System.Drawing.Point(84, 168);
                this.txtGpsDirection.Name = "txtGpsDirection";
                this.txtGpsDirection.ReadOnly = true;
                this.txtGpsDirection.Size = new System.Drawing.Size(112, 38);
                this.txtGpsDirection.TabIndex = 19;
                this.txtGpsDirection.TabStop = false;
                this.txtGpsDirection.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                // 
                // txtGpsVelocity
                // 
                this.txtGpsVelocity.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.txtGpsVelocity.Location = new System.Drawing.Point(328, 114);
                this.txtGpsVelocity.Name = "txtGpsVelocity";
                this.txtGpsVelocity.ReadOnly = true;
                this.txtGpsVelocity.Size = new System.Drawing.Size(94, 38);
                this.txtGpsVelocity.TabIndex = 18;
                this.txtGpsVelocity.TabStop = false;
                this.txtGpsVelocity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                // 
                // label15
                // 
                this.label15.AutoSize = true;
                this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.label15.Location = new System.Drawing.Point(6, 171);
                this.label15.Name = "label15";
                this.label15.Size = new System.Drawing.Size(68, 31);
                this.label15.TabIndex = 17;
                this.label15.Text = "方位";
                // 
                // label14
                // 
                this.label14.AutoSize = true;
                this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.label14.Location = new System.Drawing.Point(250, 117);
                this.label14.Name = "label14";
                this.label14.Size = new System.Drawing.Size(68, 31);
                this.label14.TabIndex = 16;
                this.label14.Text = "速度";
                // 
                // txtGpsH
                // 
                this.txtGpsH.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.txtGpsH.Location = new System.Drawing.Point(84, 114);
                this.txtGpsH.Name = "txtGpsH";
                this.txtGpsH.ReadOnly = true;
                this.txtGpsH.Size = new System.Drawing.Size(112, 38);
                this.txtGpsH.TabIndex = 6;
                this.txtGpsH.TabStop = false;
                this.txtGpsH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                // 
                // label6
                // 
                this.label6.AutoSize = true;
                this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.label6.Location = new System.Drawing.Point(6, 117);
                this.label6.Name = "label6";
                this.label6.Size = new System.Drawing.Size(68, 31);
                this.label6.TabIndex = 4;
                this.label6.Text = "高度";
                // 
                // txtGpsCount
                // 
                this.txtGpsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.txtGpsCount.Location = new System.Drawing.Point(444, 276);
                this.txtGpsCount.Name = "txtGpsCount";
                this.txtGpsCount.ReadOnly = true;
                this.txtGpsCount.Size = new System.Drawing.Size(74, 38);
                this.txtGpsCount.TabIndex = 13;
                this.txtGpsCount.TabStop = false;
                this.txtGpsCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                // 
                // label10
                // 
                this.label10.AutoSize = true;
                this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.label10.Location = new System.Drawing.Point(285, 279);
                this.label10.Name = "label10";
                this.label10.Size = new System.Drawing.Size(149, 31);
                this.label10.TabIndex = 12;
                this.label10.Text = "衛星捕捉数";
                // 
                // txtGpsMode
                // 
                this.txtGpsMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.txtGpsMode.Location = new System.Drawing.Point(145, 276);
                this.txtGpsMode.Name = "txtGpsMode";
                this.txtGpsMode.ReadOnly = true;
                this.txtGpsMode.Size = new System.Drawing.Size(51, 38);
                this.txtGpsMode.TabIndex = 9;
                this.txtGpsMode.TabStop = false;
                this.txtGpsMode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                // 
                // label5
                // 
                this.label5.AutoSize = true;
                this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.label5.Location = new System.Drawing.Point(6, 279);
                this.label5.Name = "label5";
                this.label5.Size = new System.Drawing.Size(133, 31);
                this.label5.TabIndex = 8;
                this.label5.Text = "GPSモード";
                // 
                // label4
                // 
                this.label4.AutoSize = true;
                this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
                this.label4.Location = new System.Drawing.Point(250, 63);
                this.label4.Name = "label4";
                this.label4.Size = new System.Drawing.Size(68, 31);
                this.label4.TabIndex = 7;
                this.label4.Text = "経度";
                // 
                // btnFTPPost
                // 
                this.btnFTPPost.Enabled = false;
                this.btnFTPPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.btnFTPPost.Location = new System.Drawing.Point(232, 363);
                this.btnFTPPost.Name = "btnFTPPost";
                this.btnFTPPost.Size = new System.Drawing.Size(136, 45);
                this.btnFTPPost.TabIndex = 2;
                this.btnFTPPost.Text = "位置送信";
                this.btnFTPPost.UseVisualStyleBackColor = true;
                this.btnFTPPost.Click += new System.EventHandler(this.btnFTPPost_Click);
                // 
                // grpFTP
                // 
                this.grpFTP.Controls.Add(this.label17);
                this.grpFTP.Controls.Add(this.label8);
                this.grpFTP.Controls.Add(this.txtPassword);
                this.grpFTP.Controls.Add(this.txtUsername);
                this.grpFTP.Location = new System.Drawing.Point(3, 6);
                this.grpFTP.Name = "grpFTP";
                this.grpFTP.Size = new System.Drawing.Size(262, 72);
                this.grpFTP.TabIndex = 0;
                this.grpFTP.TabStop = false;
                this.grpFTP.Text = "今ココなう！アカウント";
                // 
                // label17
                // 
                this.label17.AutoSize = true;
                this.label17.Location = new System.Drawing.Point(9, 46);
                this.label17.Name = "label17";
                this.label17.Size = new System.Drawing.Size(54, 12);
                this.label17.TabIndex = 2;
                this.label17.Text = "Password";
                // 
                // label8
                // 
                this.label8.AutoSize = true;
                this.label8.Location = new System.Drawing.Point(24, 21);
                this.label8.Name = "label8";
                this.label8.Size = new System.Drawing.Size(40, 12);
                this.label8.TabIndex = 0;
                this.label8.Text = "UserID";
                // 
                // txtPassword
                // 
                this.txtPassword.Location = new System.Drawing.Point(66, 43);
                this.txtPassword.Name = "txtPassword";
                this.txtPassword.Size = new System.Drawing.Size(183, 19);
                this.txtPassword.TabIndex = 3;
                this.txtPassword.UseSystemPasswordChar = true;
                this.txtPassword.TextChanged += new System.EventHandler(this.txtFtpPASS_TextChanged);
                // 
                // txtUsername
                // 
                this.txtUsername.Location = new System.Drawing.Point(66, 18);
                this.txtUsername.Name = "txtUsername";
                this.txtUsername.Size = new System.Drawing.Size(183, 19);
                this.txtUsername.TabIndex = 1;
                this.txtUsername.TextChanged += new System.EventHandler(this.txtFtpUSER_TextChanged);
                // 
                // btnTinyURL
                // 
                this.btnTinyURL.Enabled = false;
                this.btnTinyURL.Location = new System.Drawing.Point(183, 131);
                this.btnTinyURL.Name = "btnTinyURL";
                this.btnTinyURL.Size = new System.Drawing.Size(66, 23);
                this.btnTinyURL.TabIndex = 12;
                this.btnTinyURL.Text = "TinyURL";
                this.btnTinyURL.UseVisualStyleBackColor = true;
                this.btnTinyURL.Click += new System.EventHandler(this.btnTinyURL_Click);
                // 
                // txtMapURL
                // 
                this.txtMapURL.Location = new System.Drawing.Point(59, 133);
                this.txtMapURL.Name = "txtMapURL";
                this.txtMapURL.Size = new System.Drawing.Size(118, 19);
                this.txtMapURL.TabIndex = 11;
                this.txtMapURL.TextChanged += new System.EventHandler(this.txtMapURL_TextChanged);
                // 
                // label36
                // 
                this.label36.AutoSize = true;
                this.label36.Location = new System.Drawing.Point(6, 136);
                this.label36.Name = "label36";
                this.label36.Size = new System.Drawing.Size(51, 12);
                this.label36.TabIndex = 10;
                this.label36.Text = "地図URL";
                // 
                // cbPostInterval
                // 
                this.cbPostInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cbPostInterval.Items.AddRange(new object[] {
            "10秒",
            "20秒",
            "30秒",
            "250m",
            "500m",
            "1000m"});
                this.cbPostInterval.Location = new System.Drawing.Point(100, 63);
                this.cbPostInterval.Name = "cbPostInterval";
                this.cbPostInterval.Size = new System.Drawing.Size(83, 20);
                this.cbPostInterval.TabIndex = 4;
                this.cbPostInterval.SelectedIndexChanged += new System.EventHandler(this.cbPostInterval_SelectedIndexChanged);
                // 
                // chkAutoPost
                // 
                this.chkAutoPost.Appearance = System.Windows.Forms.Appearance.Button;
                this.chkAutoPost.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.chkAutoPost.Location = new System.Drawing.Point(387, 6);
                this.chkAutoPost.Name = "chkAutoPost";
                this.chkAutoPost.Size = new System.Drawing.Size(136, 45);
                this.chkAutoPost.TabIndex = 0;
                this.chkAutoPost.Text = "自動送信";
                this.chkAutoPost.UseVisualStyleBackColor = true;
                this.chkAutoPost.CheckedChanged += new System.EventHandler(this.chkAutoPost_CheckedChanged);
                // 
                // btnGetAddress
                // 
                this.btnGetAddress.Enabled = false;
                this.btnGetAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.btnGetAddress.Location = new System.Drawing.Point(387, 100);
                this.btnGetAddress.Name = "btnGetAddress";
                this.btnGetAddress.Size = new System.Drawing.Size(136, 45);
                this.btnGetAddress.TabIndex = 1;
                this.btnGetAddress.Text = "住所取得";
                this.btnGetAddress.UseVisualStyleBackColor = true;
                this.btnGetAddress.Click += new System.EventHandler(this.btnGetAddress_Click);
                // 
                // timer1
                // 
                this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
                // 
                // txtDistance
                // 
                this.txtDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.txtDistance.Location = new System.Drawing.Point(84, 222);
                this.txtDistance.Name = "txtDistance";
                this.txtDistance.ReadOnly = true;
                this.txtDistance.Size = new System.Drawing.Size(112, 38);
                this.txtDistance.TabIndex = 13;
                this.txtDistance.TabStop = false;
                this.txtDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                // 
                // label21
                // 
                this.label21.AutoSize = true;
                this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.label21.Location = new System.Drawing.Point(6, 225);
                this.label21.Name = "label21";
                this.label21.Size = new System.Drawing.Size(68, 31);
                this.label21.TabIndex = 14;
                this.label21.Text = "距離";
                // 
                // label22
                // 
                this.label22.AutoSize = true;
                this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.label22.Location = new System.Drawing.Point(202, 225);
                this.label22.Name = "label22";
                this.label22.Size = new System.Drawing.Size(36, 31);
                this.label22.TabIndex = 15;
                this.label22.Text = "m";
                // 
                // txtAcc
                // 
                this.txtAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.txtAcc.Location = new System.Drawing.Point(328, 168);
                this.txtAcc.Name = "txtAcc";
                this.txtAcc.ReadOnly = true;
                this.txtAcc.Size = new System.Drawing.Size(94, 38);
                this.txtAcc.TabIndex = 13;
                this.txtAcc.TabStop = false;
                this.txtAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                // 
                // label24
                // 
                this.label24.AutoSize = true;
                this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.label24.Location = new System.Drawing.Point(223, 171);
                this.label24.Name = "label24";
                this.label24.Size = new System.Drawing.Size(95, 31);
                this.label24.TabIndex = 14;
                this.label24.Text = "加速度";
                // 
                // label25
                // 
                this.label25.AutoSize = true;
                this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.label25.Location = new System.Drawing.Point(428, 171);
                this.label25.Name = "label25";
                this.label25.Size = new System.Drawing.Size(80, 31);
                this.label25.TabIndex = 15;
                this.label25.Text = "m/s/s";
                // 
                // tabControl1
                // 
                this.tabControl1.Controls.Add(this.main);
                this.tabControl1.Controls.Add(this.tabNearby);
                this.tabControl1.Controls.Add(this.detail);
                this.tabControl1.Controls.Add(this.setting);
                this.tabControl1.Controls.Add(this.setting2);
                this.tabControl1.Controls.Add(this.setting3);
                this.tabControl1.Controls.Add(this.tabPlugin);
                this.tabControl1.Controls.Add(this.tabAbout);
                this.tabControl1.Location = new System.Drawing.Point(1, 2);
                this.tabControl1.Name = "tabControl1";
                this.tabControl1.SelectedIndex = 0;
                this.tabControl1.Size = new System.Drawing.Size(541, 358);
                this.tabControl1.TabIndex = 2;
                // 
                // main
                // 
                this.main.Controls.Add(this.mBtnShiharai);
                this.main.Controls.Add(this.mBtnKosoku);
                this.main.Controls.Add(this.mBtnJissha);
                this.main.Controls.Add(this.mBtnKuusha);
                this.main.Controls.Add(this.groupBox5);
                this.main.Controls.Add(this.picMyDirection);
                this.main.Controls.Add(this.label20);
                this.main.Controls.Add(this.label7);
                this.main.Controls.Add(this.prgAutoPost);
                this.main.Controls.Add(this.prgAutoImakoko);
                this.main.Controls.Add(this.chkAutoTwit);
                this.main.Controls.Add(this.txtGpsVelocity2);
                this.main.Controls.Add(this.txtGpsLat2);
                this.main.Controls.Add(this.txtGpsLon2);
                this.main.Controls.Add(this.label27);
                this.main.Controls.Add(this.label28);
                this.main.Controls.Add(this.label29);
                this.main.Controls.Add(this.label30);
                this.main.Controls.Add(this.label31);
                this.main.Controls.Add(this.txtDistance2);
                this.main.Controls.Add(this.label32);
                this.main.Controls.Add(this.txtAddress);
                this.main.Controls.Add(this.btnTwitterPost);
                this.main.Controls.Add(this.chkAutoPost);
                this.main.Controls.Add(this.btnGetAddress);
                this.main.Location = new System.Drawing.Point(4, 22);
                this.main.Name = "main";
                this.main.Padding = new System.Windows.Forms.Padding(3);
                this.main.Size = new System.Drawing.Size(533, 332);
                this.main.TabIndex = 0;
                this.main.Text = "Main";
                this.main.UseVisualStyleBackColor = true;
                // 
                // groupBox5
                // 
                this.groupBox5.Controls.Add(this.lblNear1);
                this.groupBox5.Controls.Add(this.lblNear2);
                this.groupBox5.Controls.Add(this.picNear1);
                this.groupBox5.Controls.Add(this.picNear2);
                this.groupBox5.Location = new System.Drawing.Point(337, 204);
                this.groupBox5.Name = "groupBox5";
                this.groupBox5.Size = new System.Drawing.Size(193, 77);
                this.groupBox5.TabIndex = 39;
                this.groupBox5.TabStop = false;
                this.groupBox5.Text = "近接ユーザー";
                // 
                // lblNear1
                // 
                this.lblNear1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F);
                this.lblNear1.Location = new System.Drawing.Point(25, 19);
                this.lblNear1.Name = "lblNear1";
                this.lblNear1.Size = new System.Drawing.Size(168, 23);
                this.lblNear1.TabIndex = 38;
                // 
                // lblNear2
                // 
                this.lblNear2.Font = new System.Drawing.Font("MS UI Gothic", 14.25F);
                this.lblNear2.Location = new System.Drawing.Point(25, 45);
                this.lblNear2.Name = "lblNear2";
                this.lblNear2.Size = new System.Drawing.Size(168, 23);
                this.lblNear2.TabIndex = 38;
                // 
                // picNear1
                // 
                this.picNear1.Location = new System.Drawing.Point(6, 19);
                this.picNear1.Name = "picNear1";
                this.picNear1.Size = new System.Drawing.Size(16, 16);
                this.picNear1.TabIndex = 37;
                this.picNear1.TabStop = false;
                // 
                // picNear2
                // 
                this.picNear2.Location = new System.Drawing.Point(6, 45);
                this.picNear2.Name = "picNear2";
                this.picNear2.Size = new System.Drawing.Size(16, 16);
                this.picNear2.TabIndex = 37;
                this.picNear2.TabStop = false;
                // 
                // picMyDirection
                // 
                this.picMyDirection.Location = new System.Drawing.Point(267, 212);
                this.picMyDirection.Name = "picMyDirection";
                this.picMyDirection.Size = new System.Drawing.Size(64, 64);
                this.picMyDirection.TabIndex = 36;
                this.picMyDirection.TabStop = false;
                this.picMyDirection.Click += new System.EventHandler(this.picMyDirection_Click);
                // 
                // label20
                // 
                this.label20.AutoSize = true;
                this.label20.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.label20.Location = new System.Drawing.Point(23, 262);
                this.label20.Name = "label20";
                this.label20.Size = new System.Drawing.Size(63, 19);
                this.label20.TabIndex = 35;
                this.label20.Text = "イマココ";
                // 
                // label7
                // 
                this.label7.AutoSize = true;
                this.label7.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.label7.Location = new System.Drawing.Point(1, 235);
                this.label7.Name = "label7";
                this.label7.Size = new System.Drawing.Size(85, 19);
                this.label7.TabIndex = 34;
                this.label7.Text = "位置送信";
                // 
                // prgAutoPost
                // 
                this.prgAutoPost.Enabled = false;
                this.prgAutoPost.Location = new System.Drawing.Point(87, 235);
                this.prgAutoPost.Name = "prgAutoPost";
                this.prgAutoPost.Size = new System.Drawing.Size(170, 19);
                this.prgAutoPost.TabIndex = 33;
                // 
                // prgAutoImakoko
                // 
                this.prgAutoImakoko.Enabled = false;
                this.prgAutoImakoko.Location = new System.Drawing.Point(87, 262);
                this.prgAutoImakoko.Name = "prgAutoImakoko";
                this.prgAutoImakoko.Size = new System.Drawing.Size(170, 19);
                this.prgAutoImakoko.TabIndex = 33;
                // 
                // chkAutoTwit
                // 
                this.chkAutoTwit.Appearance = System.Windows.Forms.Appearance.Button;
                this.chkAutoTwit.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.chkAutoTwit.Location = new System.Drawing.Point(387, 51);
                this.chkAutoTwit.Name = "chkAutoTwit";
                this.chkAutoTwit.Size = new System.Drawing.Size(136, 45);
                this.chkAutoTwit.TabIndex = 32;
                this.chkAutoTwit.Text = "自動ｲﾏｺｺ";
                this.chkAutoTwit.UseVisualStyleBackColor = true;
                this.chkAutoTwit.CheckedChanged += new System.EventHandler(this.chkAutoTwit_CheckedChanged);
                // 
                // txtGpsVelocity2
                // 
                this.txtGpsVelocity2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.txtGpsVelocity2.Location = new System.Drawing.Point(95, 113);
                this.txtGpsVelocity2.Name = "txtGpsVelocity2";
                this.txtGpsVelocity2.ReadOnly = true;
                this.txtGpsVelocity2.Size = new System.Drawing.Size(111, 44);
                this.txtGpsVelocity2.TabIndex = 30;
                this.txtGpsVelocity2.TabStop = false;
                this.txtGpsVelocity2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                // 
                // txtGpsLat2
                // 
                this.txtGpsLat2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.txtGpsLat2.Location = new System.Drawing.Point(95, 10);
                this.txtGpsLat2.Name = "txtGpsLat2";
                this.txtGpsLat2.ReadOnly = true;
                this.txtGpsLat2.Size = new System.Drawing.Size(205, 44);
                this.txtGpsLat2.TabIndex = 22;
                this.txtGpsLat2.TabStop = false;
                // 
                // txtGpsLon2
                // 
                this.txtGpsLon2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.txtGpsLon2.Location = new System.Drawing.Point(95, 62);
                this.txtGpsLon2.Name = "txtGpsLon2";
                this.txtGpsLon2.ReadOnly = true;
                this.txtGpsLon2.Size = new System.Drawing.Size(205, 44);
                this.txtGpsLon2.TabIndex = 23;
                this.txtGpsLon2.TabStop = false;
                // 
                // label27
                // 
                this.label27.AutoSize = true;
                this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.label27.Location = new System.Drawing.Point(6, 116);
                this.label27.Name = "label27";
                this.label27.Size = new System.Drawing.Size(81, 37);
                this.label27.TabIndex = 29;
                this.label27.Text = "速度";
                // 
                // label28
                // 
                this.label28.AutoSize = true;
                this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.label28.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
                this.label28.Location = new System.Drawing.Point(6, 13);
                this.label28.Name = "label28";
                this.label28.Size = new System.Drawing.Size(81, 37);
                this.label28.TabIndex = 4;
                this.label28.Text = "緯度";
                // 
                // label29
                // 
                this.label29.AutoSize = true;
                this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.label29.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
                this.label29.Location = new System.Drawing.Point(6, 65);
                this.label29.Name = "label29";
                this.label29.Size = new System.Drawing.Size(81, 37);
                this.label29.TabIndex = 24;
                this.label29.Text = "経度";
                // 
                // label30
                // 
                this.label30.AutoSize = true;
                this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.label30.Location = new System.Drawing.Point(212, 116);
                this.label30.Name = "label30";
                this.label30.Size = new System.Drawing.Size(87, 37);
                this.label30.TabIndex = 28;
                this.label30.Text = "km/h";
                // 
                // label31
                // 
                this.label31.AutoSize = true;
                this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.label31.Location = new System.Drawing.Point(212, 167);
                this.label31.Name = "label31";
                this.label31.Size = new System.Drawing.Size(44, 37);
                this.label31.TabIndex = 27;
                this.label31.Text = "m";
                // 
                // txtDistance2
                // 
                this.txtDistance2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.txtDistance2.Location = new System.Drawing.Point(95, 164);
                this.txtDistance2.Name = "txtDistance2";
                this.txtDistance2.ReadOnly = true;
                this.txtDistance2.Size = new System.Drawing.Size(111, 44);
                this.txtDistance2.TabIndex = 25;
                this.txtDistance2.TabStop = false;
                this.txtDistance2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                // 
                // label32
                // 
                this.label32.AutoSize = true;
                this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.label32.Location = new System.Drawing.Point(6, 167);
                this.label32.Name = "label32";
                this.label32.Size = new System.Drawing.Size(81, 37);
                this.label32.TabIndex = 26;
                this.label32.Text = "距離";
                // 
                // txtAddress
                // 
                this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.txtAddress.Location = new System.Drawing.Point(3, 288);
                this.txtAddress.Name = "txtAddress";
                this.txtAddress.Size = new System.Drawing.Size(421, 35);
                this.txtAddress.TabIndex = 3;
                this.txtAddress.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);
                // 
                // btnTwitterPost
                // 
                this.btnTwitterPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnTwitterPost.Location = new System.Drawing.Point(428, 288);
                this.btnTwitterPost.Name = "btnTwitterPost";
                this.btnTwitterPost.Size = new System.Drawing.Size(91, 35);
                this.btnTwitterPost.TabIndex = 2;
                this.btnTwitterPost.Text = "Tweet";
                this.btnTwitterPost.UseVisualStyleBackColor = true;
                this.btnTwitterPost.Click += new System.EventHandler(this.btnTwitterPost_Click);
                // 
                // tabNearby
                // 
                this.tabNearby.Controls.Add(this.listView1);
                this.tabNearby.Location = new System.Drawing.Point(4, 22);
                this.tabNearby.Name = "tabNearby";
                this.tabNearby.Padding = new System.Windows.Forms.Padding(3);
                this.tabNearby.Size = new System.Drawing.Size(533, 332);
                this.tabNearby.TabIndex = 5;
                this.tabNearby.Text = "近接ユーザー";
                this.tabNearby.UseVisualStyleBackColor = true;
                // 
                // listView1
                // 
                this.listView1.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.listView1.FullRowSelect = true;
                this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
                this.listView1.Location = new System.Drawing.Point(3, 6);
                this.listView1.MultiSelect = false;
                this.listView1.Name = "listView1";
                this.listView1.Size = new System.Drawing.Size(524, 320);
                this.listView1.TabIndex = 0;
                this.listView1.UseCompatibleStateImageBehavior = false;
                this.listView1.View = System.Windows.Forms.View.Details;
                // 
                // detail
                // 
                this.detail.Controls.Add(this.txtDOP);
                this.detail.Controls.Add(this.label23);
                this.detail.Controls.Add(this.label9);
                this.detail.Controls.Add(this.txtGpsDirection);
                this.detail.Controls.Add(this.label24);
                this.detail.Controls.Add(this.txtGpsVelocity);
                this.detail.Controls.Add(this.txtGpsLat);
                this.detail.Controls.Add(this.label15);
                this.detail.Controls.Add(this.txtGpsLon);
                this.detail.Controls.Add(this.label14);
                this.detail.Controls.Add(this.txtAcc);
                this.detail.Controls.Add(this.txtGpsH);
                this.detail.Controls.Add(this.label3);
                this.detail.Controls.Add(this.label6);
                this.detail.Controls.Add(this.label4);
                this.detail.Controls.Add(this.txtGpsCount);
                this.detail.Controls.Add(this.label19);
                this.detail.Controls.Add(this.label26);
                this.detail.Controls.Add(this.label22);
                this.detail.Controls.Add(this.label10);
                this.detail.Controls.Add(this.label5);
                this.detail.Controls.Add(this.txtGpsTime);
                this.detail.Controls.Add(this.txtDistance);
                this.detail.Controls.Add(this.label21);
                this.detail.Controls.Add(this.txtGpsMode);
                this.detail.Controls.Add(this.label25);
                this.detail.Location = new System.Drawing.Point(4, 22);
                this.detail.Name = "detail";
                this.detail.Padding = new System.Windows.Forms.Padding(3);
                this.detail.Size = new System.Drawing.Size(533, 332);
                this.detail.TabIndex = 3;
                this.detail.Text = "受信データ詳細";
                this.detail.UseVisualStyleBackColor = true;
                // 
                // label9
                // 
                this.label9.AutoSize = true;
                this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
                this.label9.Location = new System.Drawing.Point(6, 9);
                this.label9.Name = "label9";
                this.label9.Size = new System.Drawing.Size(68, 31);
                this.label9.TabIndex = 10;
                this.label9.Text = "時刻";
                // 
                // txtGpsLat
                // 
                this.txtGpsLat.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.txtGpsLat.Location = new System.Drawing.Point(84, 60);
                this.txtGpsLat.Name = "txtGpsLat";
                this.txtGpsLat.ReadOnly = true;
                this.txtGpsLat.Size = new System.Drawing.Size(160, 38);
                this.txtGpsLat.TabIndex = 4;
                this.txtGpsLat.TabStop = false;
                // 
                // txtGpsLon
                // 
                this.txtGpsLon.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.txtGpsLon.Location = new System.Drawing.Point(328, 60);
                this.txtGpsLon.Name = "txtGpsLon";
                this.txtGpsLon.ReadOnly = true;
                this.txtGpsLon.Size = new System.Drawing.Size(190, 38);
                this.txtGpsLon.TabIndex = 5;
                this.txtGpsLon.TabStop = false;
                // 
                // label3
                // 
                this.label3.AutoSize = true;
                this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
                this.label3.Location = new System.Drawing.Point(6, 63);
                this.label3.Name = "label3";
                this.label3.Size = new System.Drawing.Size(68, 31);
                this.label3.TabIndex = 3;
                this.label3.Text = "緯度";
                // 
                // label19
                // 
                this.label19.AutoSize = true;
                this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.label19.Location = new System.Drawing.Point(428, 117);
                this.label19.Name = "label19";
                this.label19.Size = new System.Drawing.Size(73, 31);
                this.label19.TabIndex = 15;
                this.label19.Text = "km/h";
                // 
                // label26
                // 
                this.label26.AutoSize = true;
                this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.label26.Location = new System.Drawing.Point(202, 117);
                this.label26.Name = "label26";
                this.label26.Size = new System.Drawing.Size(36, 31);
                this.label26.TabIndex = 15;
                this.label26.Text = "m";
                // 
                // txtGpsTime
                // 
                this.txtGpsTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.txtGpsTime.Location = new System.Drawing.Point(84, 6);
                this.txtGpsTime.Name = "txtGpsTime";
                this.txtGpsTime.ReadOnly = true;
                this.txtGpsTime.Size = new System.Drawing.Size(434, 38);
                this.txtGpsTime.TabIndex = 11;
                this.txtGpsTime.TabStop = false;
                // 
                // setting
                // 
                this.setting.Controls.Add(this.groupBox7);
                this.setting.Controls.Add(this.groupBox3);
                this.setting.Controls.Add(this.groupBox2);
                this.setting.Controls.Add(this.grpFTP);
                this.setting.Controls.Add(this.groupBox1);
                this.setting.Controls.Add(this.grpGPS);
                this.setting.Location = new System.Drawing.Point(4, 22);
                this.setting.Name = "setting";
                this.setting.Padding = new System.Windows.Forms.Padding(3);
                this.setting.Size = new System.Drawing.Size(533, 332);
                this.setting.TabIndex = 2;
                this.setting.Text = "設定";
                this.setting.UseVisualStyleBackColor = true;
                // 
                // groupBox7
                // 
                this.groupBox7.Controls.Add(this.txtProxyPort);
                this.groupBox7.Controls.Add(this.label45);
                this.groupBox7.Controls.Add(this.txtProxyServer);
                this.groupBox7.Controls.Add(this.label44);
                this.groupBox7.Location = new System.Drawing.Point(269, 229);
                this.groupBox7.Name = "groupBox7";
                this.groupBox7.Size = new System.Drawing.Size(256, 77);
                this.groupBox7.TabIndex = 5;
                this.groupBox7.TabStop = false;
                this.groupBox7.Text = "ネットワーク設定";
                // 
                // txtProxyPort
                // 
                this.txtProxyPort.Location = new System.Drawing.Point(83, 45);
                this.txtProxyPort.Name = "txtProxyPort";
                this.txtProxyPort.Size = new System.Drawing.Size(58, 19);
                this.txtProxyPort.TabIndex = 3;
                this.txtProxyPort.TextChanged += new System.EventHandler(this.txtProxyPort_TextChanged);
                // 
                // label45
                // 
                this.label45.AutoSize = true;
                this.label45.Location = new System.Drawing.Point(12, 48);
                this.label45.Name = "label45";
                this.label45.Size = new System.Drawing.Size(62, 12);
                this.label45.TabIndex = 2;
                this.label45.Text = "Proxyポート";
                // 
                // txtProxyServer
                // 
                this.txtProxyServer.Location = new System.Drawing.Point(83, 21);
                this.txtProxyServer.Name = "txtProxyServer";
                this.txtProxyServer.Size = new System.Drawing.Size(165, 19);
                this.txtProxyServer.TabIndex = 1;
                this.txtProxyServer.TextChanged += new System.EventHandler(this.txtProxyServer_TextChanged);
                // 
                // label44
                // 
                this.label44.AutoSize = true;
                this.label44.Location = new System.Drawing.Point(12, 24);
                this.label44.Name = "label44";
                this.label44.Size = new System.Drawing.Size(64, 12);
                this.label44.TabIndex = 0;
                this.label44.Text = "Proxyサーバ";
                // 
                // groupBox3
                // 
                this.groupBox3.Controls.Add(this.btnEdit);
                this.groupBox3.Controls.Add(this.btnAddNoPost);
                this.groupBox3.Controls.Add(this.btnDeleteNoPost);
                this.groupBox3.Controls.Add(this.label13);
                this.groupBox3.Controls.Add(this.cbRadius);
                this.groupBox3.Controls.Add(this.label12);
                this.groupBox3.Controls.Add(this.cbNoPost);
                this.groupBox3.Location = new System.Drawing.Point(269, 125);
                this.groupBox3.Name = "groupBox3";
                this.groupBox3.Size = new System.Drawing.Size(256, 102);
                this.groupBox3.TabIndex = 4;
                this.groupBox3.TabStop = false;
                this.groupBox3.Text = "非送信地帯";
                // 
                // btnEdit
                // 
                this.btnEdit.Location = new System.Drawing.Point(116, 41);
                this.btnEdit.Name = "btnEdit";
                this.btnEdit.Size = new System.Drawing.Size(45, 21);
                this.btnEdit.TabIndex = 3;
                this.btnEdit.Text = "編集";
                this.btnEdit.UseVisualStyleBackColor = true;
                this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
                // 
                // btnAddNoPost
                // 
                this.btnAddNoPost.Location = new System.Drawing.Point(14, 41);
                this.btnAddNoPost.Name = "btnAddNoPost";
                this.btnAddNoPost.Size = new System.Drawing.Size(45, 21);
                this.btnAddNoPost.TabIndex = 1;
                this.btnAddNoPost.Text = "追加";
                this.btnAddNoPost.UseVisualStyleBackColor = true;
                this.btnAddNoPost.Click += new System.EventHandler(this.btnAddNoPost_Click);
                // 
                // btnDeleteNoPost
                // 
                this.btnDeleteNoPost.Location = new System.Drawing.Point(65, 41);
                this.btnDeleteNoPost.Name = "btnDeleteNoPost";
                this.btnDeleteNoPost.Size = new System.Drawing.Size(45, 21);
                this.btnDeleteNoPost.TabIndex = 2;
                this.btnDeleteNoPost.Text = "削除";
                this.btnDeleteNoPost.UseVisualStyleBackColor = true;
                this.btnDeleteNoPost.Click += new System.EventHandler(this.btnDeleteNoPost_Click);
                // 
                // label13
                // 
                this.label13.AutoSize = true;
                this.label13.Location = new System.Drawing.Point(147, 69);
                this.label13.Name = "label13";
                this.label13.Size = new System.Drawing.Size(14, 12);
                this.label13.TabIndex = 6;
                this.label13.Text = "m";
                // 
                // cbRadius
                // 
                this.cbRadius.FormattingEnabled = true;
                this.cbRadius.Items.AddRange(new object[] {
            "250",
            "500",
            "750",
            "1000",
            "2000",
            "3000"});
                this.cbRadius.Location = new System.Drawing.Point(83, 66);
                this.cbRadius.Name = "cbRadius";
                this.cbRadius.Size = new System.Drawing.Size(58, 20);
                this.cbRadius.TabIndex = 5;
                this.cbRadius.Text = "500";
                this.cbRadius.SelectedIndexChanged += new System.EventHandler(this.cbRadius_SelectedIndexChanged);
                this.cbRadius.TextUpdate += new System.EventHandler(this.cbRadius_SelectedIndexChanged);
                this.cbRadius.TextChanged += new System.EventHandler(this.cbRadius_SelectedIndexChanged);
                // 
                // label12
                // 
                this.label12.AutoSize = true;
                this.label12.Location = new System.Drawing.Point(12, 69);
                this.label12.Name = "label12";
                this.label12.Size = new System.Drawing.Size(65, 12);
                this.label12.TabIndex = 4;
                this.label12.Text = "非送信半径";
                // 
                // cbNoPost
                // 
                this.cbNoPost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cbNoPost.Location = new System.Drawing.Point(14, 15);
                this.cbNoPost.Name = "cbNoPost";
                this.cbNoPost.Size = new System.Drawing.Size(234, 20);
                this.cbNoPost.TabIndex = 0;
                // 
                // groupBox2
                // 
                this.groupBox2.Controls.Add(this.btnLogDirectory);
                this.groupBox2.Controls.Add(this.txtLogDirectory);
                this.groupBox2.Controls.Add(this.cbIcon);
                this.groupBox2.Controls.Add(this.label11);
                this.groupBox2.Controls.Add(this.chkSpeedFilter);
                this.groupBox2.Controls.Add(this.chkSaveServer);
                this.groupBox2.Controls.Add(this.label34);
                this.groupBox2.Controls.Add(this.chkSaveLog);
                this.groupBox2.Controls.Add(this.cbPostInterval);
                this.groupBox2.Location = new System.Drawing.Point(269, 6);
                this.groupBox2.Name = "groupBox2";
                this.groupBox2.Size = new System.Drawing.Size(256, 116);
                this.groupBox2.TabIndex = 3;
                this.groupBox2.TabStop = false;
                this.groupBox2.Text = "データ";
                // 
                // btnLogDirectory
                // 
                this.btnLogDirectory.Location = new System.Drawing.Point(230, 13);
                this.btnLogDirectory.Name = "btnLogDirectory";
                this.btnLogDirectory.Size = new System.Drawing.Size(23, 23);
                this.btnLogDirectory.TabIndex = 8;
                this.btnLogDirectory.Text = "...";
                this.btnLogDirectory.UseVisualStyleBackColor = true;
                this.btnLogDirectory.Click += new System.EventHandler(this.btnLogDirectory_Click);
                // 
                // txtLogDirectory
                // 
                this.txtLogDirectory.Location = new System.Drawing.Point(127, 16);
                this.txtLogDirectory.Name = "txtLogDirectory";
                this.txtLogDirectory.ReadOnly = true;
                this.txtLogDirectory.Size = new System.Drawing.Size(100, 19);
                this.txtLogDirectory.TabIndex = 7;
                // 
                // cbIcon
                // 
                this.cbIcon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cbIcon.FormattingEnabled = true;
                this.cbIcon.Items.AddRange(new object[] {
            "標準",
            "携帯電話",
            "飛行機",
            "列車",
            "新幹線",
            "バス",
            "自転車",
            "徒歩",
            "バイク",
            "ヘリコプター",
            "船",
            "Twitter"});
                this.cbIcon.Location = new System.Drawing.Point(100, 89);
                this.cbIcon.Name = "cbIcon";
                this.cbIcon.Size = new System.Drawing.Size(83, 20);
                this.cbIcon.TabIndex = 6;
                this.cbIcon.SelectedIndexChanged += new System.EventHandler(this.cbIcon_SelectedIndexChanged);
                // 
                // label11
                // 
                this.label11.AutoSize = true;
                this.label11.Location = new System.Drawing.Point(14, 93);
                this.label11.Name = "label11";
                this.label11.Size = new System.Drawing.Size(40, 12);
                this.label11.TabIndex = 5;
                this.label11.Text = "アイコン";
                // 
                // chkSpeedFilter
                // 
                this.chkSpeedFilter.AutoSize = true;
                this.chkSpeedFilter.Checked = true;
                this.chkSpeedFilter.CheckState = System.Windows.Forms.CheckState.Checked;
                this.chkSpeedFilter.Location = new System.Drawing.Point(15, 43);
                this.chkSpeedFilter.Name = "chkSpeedFilter";
                this.chkSpeedFilter.Size = new System.Drawing.Size(132, 16);
                this.chkSpeedFilter.TabIndex = 2;
                this.chkSpeedFilter.Text = "速度フィルターを入れる";
                this.chkSpeedFilter.UseVisualStyleBackColor = true;
                this.chkSpeedFilter.CheckedChanged += new System.EventHandler(this.chkSpeedFilter_CheckedChanged);
                // 
                // chkSaveServer
                // 
                this.chkSaveServer.AutoSize = true;
                this.chkSaveServer.Location = new System.Drawing.Point(152, 43);
                this.chkSaveServer.Name = "chkSaveServer";
                this.chkSaveServer.Size = new System.Drawing.Size(106, 16);
                this.chkSaveServer.TabIndex = 1;
                this.chkSaveServer.Text = "サーバに保存する";
                this.chkSaveServer.UseVisualStyleBackColor = true;
                this.chkSaveServer.CheckedChanged += new System.EventHandler(this.chkSaveServer_CheckedChanged);
                // 
                // label34
                // 
                this.label34.AutoSize = true;
                this.label34.Location = new System.Drawing.Point(12, 66);
                this.label34.Name = "label34";
                this.label34.Size = new System.Drawing.Size(82, 12);
                this.label34.TabIndex = 3;
                this.label34.Text = "自動POST間隔";
                // 
                // groupBox1
                // 
                this.groupBox1.Controls.Add(this.btnXAuth);
                this.groupBox1.Controls.Add(this.chkTwitLocation);
                this.groupBox1.Controls.Add(this.chkHashTag);
                this.groupBox1.Controls.Add(this.btnTinyURL);
                this.groupBox1.Controls.Add(this.label36);
                this.groupBox1.Controls.Add(this.txtImakoko);
                this.groupBox1.Controls.Add(this.txtMapURL);
                this.groupBox1.Controls.Add(this.label37);
                this.groupBox1.Controls.Add(this.cbNoSameAddress);
                this.groupBox1.Controls.Add(this.chkLatLon);
                this.groupBox1.Controls.Add(this.txtTinyURL);
                this.groupBox1.Controls.Add(this.chkMapURL);
                this.groupBox1.Controls.Add(this.lblOAuth);
                this.groupBox1.Location = new System.Drawing.Point(3, 163);
                this.groupBox1.Name = "groupBox1";
                this.groupBox1.Size = new System.Drawing.Size(262, 163);
                this.groupBox1.TabIndex = 2;
                this.groupBox1.TabStop = false;
                this.groupBox1.Text = "Twitter";
                // 
                // btnXAuth
                // 
                this.btnXAuth.Location = new System.Drawing.Point(174, 13);
                this.btnXAuth.Name = "btnXAuth";
                this.btnXAuth.Size = new System.Drawing.Size(75, 23);
                this.btnXAuth.TabIndex = 14;
                this.btnXAuth.Text = "xAuth認証";
                this.btnXAuth.UseVisualStyleBackColor = true;
                this.btnXAuth.Click += new System.EventHandler(this.btnXAuth_Click);
                // 
                // chkTwitLocation
                // 
                this.chkTwitLocation.AutoSize = true;
                this.chkTwitLocation.Location = new System.Drawing.Point(120, 66);
                this.chkTwitLocation.Name = "chkTwitLocation";
                this.chkTwitLocation.Size = new System.Drawing.Size(129, 16);
                this.chkTwitLocation.TabIndex = 13;
                this.chkTwitLocation.Text = "APIに位置情報も送る";
                this.chkTwitLocation.UseVisualStyleBackColor = true;
                this.chkTwitLocation.CheckedChanged += new System.EventHandler(this.chkTwitLocation_CheckedChanged);
                // 
                // chkHashTag
                // 
                this.chkHashTag.AutoSize = true;
                this.chkHashTag.Location = new System.Drawing.Point(6, 88);
                this.chkHashTag.Name = "chkHashTag";
                this.chkHashTag.Size = new System.Drawing.Size(189, 16);
                this.chkHashTag.TabIndex = 7;
                this.chkHashTag.Text = "ハッシュタグ(#imacoconow)をつける";
                this.chkHashTag.UseVisualStyleBackColor = true;
                this.chkHashTag.CheckedChanged += new System.EventHandler(this.chkHashTag_CheckedChanged);
                // 
                // txtImakoko
                // 
                this.txtImakoko.Location = new System.Drawing.Point(183, 40);
                this.txtImakoko.Name = "txtImakoko";
                this.txtImakoko.Size = new System.Drawing.Size(66, 19);
                this.txtImakoko.TabIndex = 6;
                this.txtImakoko.Text = "ｲﾏｺｺ! L:";
                this.txtImakoko.TextChanged += new System.EventHandler(this.txtImakoko_TextChanged);
                // 
                // label37
                // 
                this.label37.AutoSize = true;
                this.label37.Location = new System.Drawing.Point(146, 43);
                this.label37.Name = "label37";
                this.label37.Size = new System.Drawing.Size(31, 12);
                this.label37.TabIndex = 5;
                this.label37.Text = "ヘッダ";
                // 
                // cbNoSameAddress
                // 
                this.cbNoSameAddress.AutoSize = true;
                this.cbNoSameAddress.Location = new System.Drawing.Point(6, 42);
                this.cbNoSameAddress.Name = "cbNoSameAddress";
                this.cbNoSameAddress.Size = new System.Drawing.Size(134, 16);
                this.cbNoSameAddress.TabIndex = 4;
                this.cbNoSameAddress.Text = "同一住所判定をしない";
                this.cbNoSameAddress.UseVisualStyleBackColor = true;
                this.cbNoSameAddress.CheckedChanged += new System.EventHandler(this.cbNoSameAddress_CheckedChanged);
                // 
                // chkLatLon
                // 
                this.chkLatLon.AutoSize = true;
                this.chkLatLon.Location = new System.Drawing.Point(6, 66);
                this.chkLatLon.Name = "chkLatLon";
                this.chkLatLon.Size = new System.Drawing.Size(88, 16);
                this.chkLatLon.TabIndex = 4;
                this.chkLatLon.Text = "座標も付ける";
                this.chkLatLon.UseVisualStyleBackColor = true;
                this.chkLatLon.CheckedChanged += new System.EventHandler(this.cbLatLon_CheckedChanged);
                // 
                // txtTinyURL
                // 
                this.txtTinyURL.Location = new System.Drawing.Point(59, 109);
                this.txtTinyURL.Name = "txtTinyURL";
                this.txtTinyURL.Size = new System.Drawing.Size(190, 19);
                this.txtTinyURL.TabIndex = 9;
                this.txtTinyURL.TextChanged += new System.EventHandler(this.txtTinyURL_TextChanged);
                // 
                // chkMapURL
                // 
                this.chkMapURL.AutoSize = true;
                this.chkMapURL.Location = new System.Drawing.Point(6, 111);
                this.chkMapURL.Name = "chkMapURL";
                this.chkMapURL.Size = new System.Drawing.Size(47, 16);
                this.chkMapURL.TabIndex = 8;
                this.chkMapURL.Text = "フッタ";
                this.chkMapURL.UseVisualStyleBackColor = true;
                this.chkMapURL.CheckedChanged += new System.EventHandler(this.cbMapURL_CheckedChanged);
                // 
                // lblOAuth
                // 
                this.lblOAuth.AutoSize = true;
                this.lblOAuth.Location = new System.Drawing.Point(6, 18);
                this.lblOAuth.Name = "lblOAuth";
                this.lblOAuth.Size = new System.Drawing.Size(16, 12);
                this.lblOAuth.TabIndex = 0;
                this.lblOAuth.Text = "ID";
                // 
                // setting2
                // 
                this.setting2.Controls.Add(this.groupBox8);
                this.setting2.Controls.Add(this.groupBox6);
                this.setting2.Controls.Add(this.YomiageGroup);
                this.setting2.Controls.Add(this.groupBox4);
                this.setting2.Location = new System.Drawing.Point(4, 22);
                this.setting2.Name = "setting2";
                this.setting2.Padding = new System.Windows.Forms.Padding(3);
                this.setting2.Size = new System.Drawing.Size(533, 332);
                this.setting2.TabIndex = 6;
                this.setting2.Text = "設定2";
                this.setting2.UseVisualStyleBackColor = true;
                // 
                // groupBox8
                // 
                this.groupBox8.Controls.Add(this.btnSoundReset);
                this.groupBox8.Controls.Add(this.btnSoundRaderIn);
                this.groupBox8.Controls.Add(this.btnSoundRaderOut);
                this.groupBox8.Controls.Add(this.btnSoundTwit);
                this.groupBox8.Controls.Add(this.btnSoundPost);
                this.groupBox8.Controls.Add(this.txtSoundRaderOut);
                this.groupBox8.Controls.Add(this.txtSoundRaderIn);
                this.groupBox8.Controls.Add(this.txtSoundTwit);
                this.groupBox8.Controls.Add(this.txtSoundPost);
                this.groupBox8.Controls.Add(this.label47);
                this.groupBox8.Controls.Add(this.label49);
                this.groupBox8.Controls.Add(this.label48);
                this.groupBox8.Controls.Add(this.label46);
                this.groupBox8.Controls.Add(this.chkSound);
                this.groupBox8.Location = new System.Drawing.Point(7, 238);
                this.groupBox8.Name = "groupBox8";
                this.groupBox8.Size = new System.Drawing.Size(519, 88);
                this.groupBox8.TabIndex = 4;
                this.groupBox8.TabStop = false;
                this.groupBox8.Text = "サウンド設定";
                // 
                // btnSoundReset
                // 
                this.btnSoundReset.Location = new System.Drawing.Point(443, 12);
                this.btnSoundReset.Name = "btnSoundReset";
                this.btnSoundReset.Size = new System.Drawing.Size(75, 23);
                this.btnSoundReset.TabIndex = 9;
                this.btnSoundReset.Text = "リセット";
                this.btnSoundReset.UseVisualStyleBackColor = true;
                this.btnSoundReset.Click += new System.EventHandler(this.btnSoundReset_Click);
                // 
                // btnSoundRaderIn
                // 
                this.btnSoundRaderIn.Location = new System.Drawing.Point(496, 61);
                this.btnSoundRaderIn.Name = "btnSoundRaderIn";
                this.btnSoundRaderIn.Size = new System.Drawing.Size(20, 23);
                this.btnSoundRaderIn.TabIndex = 8;
                this.btnSoundRaderIn.Text = "...";
                this.btnSoundRaderIn.UseVisualStyleBackColor = true;
                this.btnSoundRaderIn.Click += new System.EventHandler(this.btnSoundRaderIn_Click);
                // 
                // btnSoundRaderOut
                // 
                this.btnSoundRaderOut.Location = new System.Drawing.Point(496, 39);
                this.btnSoundRaderOut.Name = "btnSoundRaderOut";
                this.btnSoundRaderOut.Size = new System.Drawing.Size(20, 23);
                this.btnSoundRaderOut.TabIndex = 8;
                this.btnSoundRaderOut.Text = "...";
                this.btnSoundRaderOut.UseVisualStyleBackColor = true;
                this.btnSoundRaderOut.Click += new System.EventHandler(this.btnSoundRaderOut_Click);
                // 
                // btnSoundTwit
                // 
                this.btnSoundTwit.Location = new System.Drawing.Point(225, 61);
                this.btnSoundTwit.Name = "btnSoundTwit";
                this.btnSoundTwit.Size = new System.Drawing.Size(20, 23);
                this.btnSoundTwit.TabIndex = 8;
                this.btnSoundTwit.Text = "...";
                this.btnSoundTwit.UseVisualStyleBackColor = true;
                this.btnSoundTwit.Click += new System.EventHandler(this.btnSoundTwit_Click);
                // 
                // btnSoundPost
                // 
                this.btnSoundPost.Location = new System.Drawing.Point(225, 39);
                this.btnSoundPost.Name = "btnSoundPost";
                this.btnSoundPost.Size = new System.Drawing.Size(20, 23);
                this.btnSoundPost.TabIndex = 8;
                this.btnSoundPost.Text = "...";
                this.btnSoundPost.UseVisualStyleBackColor = true;
                this.btnSoundPost.Click += new System.EventHandler(this.btnSoundPost_Click);
                // 
                // txtSoundRaderOut
                // 
                this.txtSoundRaderOut.Location = new System.Drawing.Point(373, 41);
                this.txtSoundRaderOut.Name = "txtSoundRaderOut";
                this.txtSoundRaderOut.Size = new System.Drawing.Size(120, 19);
                this.txtSoundRaderOut.TabIndex = 7;
                // 
                // txtSoundRaderIn
                // 
                this.txtSoundRaderIn.Location = new System.Drawing.Point(373, 63);
                this.txtSoundRaderIn.Name = "txtSoundRaderIn";
                this.txtSoundRaderIn.Size = new System.Drawing.Size(120, 19);
                this.txtSoundRaderIn.TabIndex = 7;
                // 
                // txtSoundTwit
                // 
                this.txtSoundTwit.Location = new System.Drawing.Point(104, 63);
                this.txtSoundTwit.Name = "txtSoundTwit";
                this.txtSoundTwit.Size = new System.Drawing.Size(120, 19);
                this.txtSoundTwit.TabIndex = 6;
                // 
                // txtSoundPost
                // 
                this.txtSoundPost.Location = new System.Drawing.Point(104, 41);
                this.txtSoundPost.Name = "txtSoundPost";
                this.txtSoundPost.Size = new System.Drawing.Size(120, 19);
                this.txtSoundPost.TabIndex = 5;
                // 
                // label47
                // 
                this.label47.AutoSize = true;
                this.label47.Location = new System.Drawing.Point(9, 66);
                this.label47.Name = "label47";
                this.label47.Size = new System.Drawing.Size(63, 12);
                this.label47.TabIndex = 4;
                this.label47.Text = "Twit送信時";
                // 
                // label49
                // 
                this.label49.AutoSize = true;
                this.label49.Location = new System.Drawing.Point(255, 44);
                this.label49.Name = "label49";
                this.label49.Size = new System.Drawing.Size(115, 12);
                this.label49.TabIndex = 4;
                this.label49.Text = "レーダー範囲外になった";
                // 
                // label48
                // 
                this.label48.AutoSize = true;
                this.label48.Location = new System.Drawing.Point(255, 66);
                this.label48.Name = "label48";
                this.label48.Size = new System.Drawing.Size(115, 12);
                this.label48.TabIndex = 4;
                this.label48.Text = "レーダー範囲内になった";
                // 
                // label46
                // 
                this.label46.AutoSize = true;
                this.label46.Location = new System.Drawing.Point(9, 44);
                this.label46.Name = "label46";
                this.label46.Size = new System.Drawing.Size(89, 12);
                this.label46.TabIndex = 4;
                this.label46.Text = "位置情報送信時";
                // 
                // chkSound
                // 
                this.chkSound.AutoSize = true;
                this.chkSound.Location = new System.Drawing.Point(14, 18);
                this.chkSound.Name = "chkSound";
                this.chkSound.Size = new System.Drawing.Size(100, 16);
                this.chkSound.TabIndex = 3;
                this.chkSound.Text = "サウンドを鳴らす";
                this.chkSound.UseVisualStyleBackColor = true;
                this.chkSound.CheckedChanged += new System.EventHandler(this.chkSound_CheckedChanged);
                // 
                // groupBox6
                // 
                this.groupBox6.Controls.Add(this.chkNeverShow);
                this.groupBox6.Controls.Add(this.chkRestart);
                this.groupBox6.Controls.Add(this.chkSend);
                this.groupBox6.Location = new System.Drawing.Point(268, 6);
                this.groupBox6.Name = "groupBox6";
                this.groupBox6.Size = new System.Drawing.Size(258, 94);
                this.groupBox6.TabIndex = 1;
                this.groupBox6.TabStop = false;
                this.groupBox6.Text = "エラー発生時の挙動";
                // 
                // chkNeverShow
                // 
                this.chkNeverShow.AutoSize = true;
                this.chkNeverShow.Location = new System.Drawing.Point(9, 62);
                this.chkNeverShow.Name = "chkNeverShow";
                this.chkNeverShow.Size = new System.Drawing.Size(145, 16);
                this.chkNeverShow.TabIndex = 2;
                this.chkNeverShow.Text = "エラーダイアログを出さない";
                this.chkNeverShow.UseVisualStyleBackColor = true;
                this.chkNeverShow.CheckedChanged += new System.EventHandler(this.chkNeverShow_CheckedChanged);
                // 
                // chkRestart
                // 
                this.chkRestart.AutoSize = true;
                this.chkRestart.Checked = true;
                this.chkRestart.CheckState = System.Windows.Forms.CheckState.Checked;
                this.chkRestart.Location = new System.Drawing.Point(9, 40);
                this.chkRestart.Name = "chkRestart";
                this.chkRestart.Size = new System.Drawing.Size(196, 16);
                this.chkRestart.TabIndex = 1;
                this.chkRestart.Text = "今ココなう！クライアントを再起動する";
                this.chkRestart.UseVisualStyleBackColor = true;
                this.chkRestart.CheckedChanged += new System.EventHandler(this.chkRestart_CheckedChanged);
                // 
                // chkSend
                // 
                this.chkSend.AutoSize = true;
                this.chkSend.Enabled = false;
                this.chkSend.Location = new System.Drawing.Point(9, 18);
                this.chkSend.Name = "chkSend";
                this.chkSend.Size = new System.Drawing.Size(172, 16);
                this.chkSend.TabIndex = 0;
                this.chkSend.Text = "エラーの内容をフィードバックする";
                this.chkSend.UseVisualStyleBackColor = true;
                this.chkSend.CheckedChanged += new System.EventHandler(this.chkSend_CheckedChanged);
                // 
                // YomiageGroup
                // 
                this.YomiageGroup.Controls.Add(this.txtRaderIn);
                this.YomiageGroup.Controls.Add(this.txtRaderOut);
                this.YomiageGroup.Controls.Add(this.label43);
                this.YomiageGroup.Controls.Add(this.label42);
                this.YomiageGroup.Controls.Add(this.label40);
                this.YomiageGroup.Controls.Add(this.chkYomiage);
                this.YomiageGroup.Controls.Add(this.btnSoftalkSetting);
                this.YomiageGroup.Controls.Add(this.txtSoftalk);
                this.YomiageGroup.Controls.Add(this.rbBouyomi);
                this.YomiageGroup.Controls.Add(this.rbYomiageSoftalk);
                this.YomiageGroup.Location = new System.Drawing.Point(7, 106);
                this.YomiageGroup.Name = "YomiageGroup";
                this.YomiageGroup.Size = new System.Drawing.Size(519, 126);
                this.YomiageGroup.TabIndex = 2;
                this.YomiageGroup.TabStop = false;
                this.YomiageGroup.Text = "読み上げツール設定";
                // 
                // txtRaderIn
                // 
                this.txtRaderIn.Location = new System.Drawing.Point(144, 93);
                this.txtRaderIn.Name = "txtRaderIn";
                this.txtRaderIn.Size = new System.Drawing.Size(369, 19);
                this.txtRaderIn.TabIndex = 9;
                this.txtRaderIn.Text = "%USER%がレーダー範囲内に入りました";
                this.txtRaderIn.Leave += new System.EventHandler(this.txtRaderIn_Leave);
                // 
                // txtRaderOut
                // 
                this.txtRaderOut.Location = new System.Drawing.Point(144, 67);
                this.txtRaderOut.Name = "txtRaderOut";
                this.txtRaderOut.Size = new System.Drawing.Size(369, 19);
                this.txtRaderOut.TabIndex = 7;
                this.txtRaderOut.Text = "%USER%がレーダー範囲外にでました";
                this.txtRaderOut.Leave += new System.EventHandler(this.txtRaderOut_Leave);
                // 
                // label43
                // 
                this.label43.AutoSize = true;
                this.label43.Location = new System.Drawing.Point(6, 96);
                this.label43.Name = "label43";
                this.label43.Size = new System.Drawing.Size(132, 12);
                this.label43.TabIndex = 8;
                this.label43.Text = "レーダー範囲内になったとき";
                // 
                // label42
                // 
                this.label42.AutoSize = true;
                this.label42.Location = new System.Drawing.Point(6, 70);
                this.label42.Name = "label42";
                this.label42.Size = new System.Drawing.Size(132, 12);
                this.label42.TabIndex = 6;
                this.label42.Text = "レーダー範囲外になったとき";
                // 
                // label40
                // 
                this.label40.AutoSize = true;
                this.label40.Location = new System.Drawing.Point(41, 45);
                this.label40.Name = "label40";
                this.label40.Size = new System.Drawing.Size(97, 12);
                this.label40.TabIndex = 3;
                this.label40.Text = "Softalk.exeの位置:";
                // 
                // chkYomiage
                // 
                this.chkYomiage.AutoSize = true;
                this.chkYomiage.Location = new System.Drawing.Point(9, 18);
                this.chkYomiage.Name = "chkYomiage";
                this.chkYomiage.Size = new System.Drawing.Size(126, 16);
                this.chkYomiage.TabIndex = 0;
                this.chkYomiage.Text = "読み上げツールを使う";
                this.chkYomiage.UseVisualStyleBackColor = true;
                this.chkYomiage.CheckedChanged += new System.EventHandler(this.chkYomiage_CheckedChanged);
                // 
                // btnSoftalkSetting
                // 
                this.btnSoftalkSetting.Location = new System.Drawing.Point(491, 40);
                this.btnSoftalkSetting.Name = "btnSoftalkSetting";
                this.btnSoftalkSetting.Size = new System.Drawing.Size(22, 23);
                this.btnSoftalkSetting.TabIndex = 5;
                this.btnSoftalkSetting.Text = "...";
                this.btnSoftalkSetting.UseVisualStyleBackColor = true;
                this.btnSoftalkSetting.Click += new System.EventHandler(this.btnSoftalkSetting_Click);
                // 
                // txtSoftalk
                // 
                this.txtSoftalk.Location = new System.Drawing.Point(144, 42);
                this.txtSoftalk.Name = "txtSoftalk";
                this.txtSoftalk.Size = new System.Drawing.Size(341, 19);
                this.txtSoftalk.TabIndex = 4;
                // 
                // rbBouyomi
                // 
                this.rbBouyomi.AutoSize = true;
                this.rbBouyomi.Location = new System.Drawing.Point(221, 17);
                this.rbBouyomi.Name = "rbBouyomi";
                this.rbBouyomi.Size = new System.Drawing.Size(85, 16);
                this.rbBouyomi.TabIndex = 2;
                this.rbBouyomi.TabStop = true;
                this.rbBouyomi.Text = "棒読みちゃん";
                this.rbBouyomi.UseVisualStyleBackColor = true;
                this.rbBouyomi.CheckedChanged += new System.EventHandler(this.rbBouyomi_CheckedChanged);
                // 
                // rbYomiageSoftalk
                // 
                this.rbYomiageSoftalk.AutoSize = true;
                this.rbYomiageSoftalk.Location = new System.Drawing.Point(156, 17);
                this.rbYomiageSoftalk.Name = "rbYomiageSoftalk";
                this.rbYomiageSoftalk.Size = new System.Drawing.Size(59, 16);
                this.rbYomiageSoftalk.TabIndex = 1;
                this.rbYomiageSoftalk.TabStop = true;
                this.rbYomiageSoftalk.Text = "Softalk";
                this.rbYomiageSoftalk.UseVisualStyleBackColor = true;
                this.rbYomiageSoftalk.CheckedChanged += new System.EventHandler(this.rbYomiageSoftalk_CheckedChanged);
                // 
                // groupBox4
                // 
                this.groupBox4.Controls.Add(this.chkUseNearAlert);
                this.groupBox4.Controls.Add(this.label39);
                this.groupBox4.Controls.Add(this.label38);
                this.groupBox4.Controls.Add(this.label35);
                this.groupBox4.Controls.Add(this.label33);
                this.groupBox4.Controls.Add(this.cbAlertCheckInterval);
                this.groupBox4.Controls.Add(this.cbRaderRange);
                this.groupBox4.Location = new System.Drawing.Point(7, 6);
                this.groupBox4.Name = "groupBox4";
                this.groupBox4.Size = new System.Drawing.Size(258, 94);
                this.groupBox4.TabIndex = 0;
                this.groupBox4.TabStop = false;
                this.groupBox4.Text = "接近アラート";
                // 
                // chkUseNearAlert
                // 
                this.chkUseNearAlert.AutoSize = true;
                this.chkUseNearAlert.Location = new System.Drawing.Point(6, 18);
                this.chkUseNearAlert.Name = "chkUseNearAlert";
                this.chkUseNearAlert.Size = new System.Drawing.Size(111, 16);
                this.chkUseNearAlert.TabIndex = 0;
                this.chkUseNearAlert.Text = "接近アラートを使う";
                this.chkUseNearAlert.UseVisualStyleBackColor = true;
                this.chkUseNearAlert.CheckedChanged += new System.EventHandler(this.chkUseNearAlert_CheckedChanged);
                // 
                // label39
                // 
                this.label39.AutoSize = true;
                this.label39.Location = new System.Drawing.Point(210, 70);
                this.label39.Name = "label39";
                this.label39.Size = new System.Drawing.Size(17, 12);
                this.label39.TabIndex = 6;
                this.label39.Text = "秒";
                // 
                // label38
                // 
                this.label38.AutoSize = true;
                this.label38.Location = new System.Drawing.Point(210, 45);
                this.label38.Name = "label38";
                this.label38.Size = new System.Drawing.Size(20, 12);
                this.label38.TabIndex = 5;
                this.label38.Text = "km";
                // 
                // label35
                // 
                this.label35.AutoSize = true;
                this.label35.Location = new System.Drawing.Point(12, 67);
                this.label35.Name = "label35";
                this.label35.Size = new System.Drawing.Size(60, 12);
                this.label35.TabIndex = 2;
                this.label35.Text = "チェック間隔";
                // 
                // label33
                // 
                this.label33.AutoSize = true;
                this.label33.Location = new System.Drawing.Point(6, 43);
                this.label33.Name = "label33";
                this.label33.Size = new System.Drawing.Size(67, 12);
                this.label33.TabIndex = 1;
                this.label33.Text = "レーダー範囲";
                // 
                // cbAlertCheckInterval
                // 
                this.cbAlertCheckInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cbAlertCheckInterval.FormattingEnabled = true;
                this.cbAlertCheckInterval.Items.AddRange(new object[] {
            "10",
            "20",
            "30",
            "60",
            "90",
            "120"});
                this.cbAlertCheckInterval.Location = new System.Drawing.Point(83, 64);
                this.cbAlertCheckInterval.Name = "cbAlertCheckInterval";
                this.cbAlertCheckInterval.Size = new System.Drawing.Size(121, 20);
                this.cbAlertCheckInterval.TabIndex = 4;
                this.cbAlertCheckInterval.SelectedIndexChanged += new System.EventHandler(this.cbAlertCheckInterval_SelectedIndexChanged);
                // 
                // cbRaderRange
                // 
                this.cbRaderRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cbRaderRange.FormattingEnabled = true;
                this.cbRaderRange.Items.AddRange(new object[] {
            "10",
            "20",
            "30",
            "50",
            "75",
            "100",
            "150",
            "200",
            "300"});
                this.cbRaderRange.Location = new System.Drawing.Point(83, 40);
                this.cbRaderRange.Name = "cbRaderRange";
                this.cbRaderRange.Size = new System.Drawing.Size(121, 20);
                this.cbRaderRange.TabIndex = 3;
                this.cbRaderRange.SelectedIndexChanged += new System.EventHandler(this.cbRaderRange_SelectedIndexChanged);
                // 
                // setting3
                // 
                this.setting3.Controls.Add(this.label18);
                this.setting3.Controls.Add(this.chkDebugLog);
                this.setting3.Controls.Add(this.groupBox9);
                this.setting3.Location = new System.Drawing.Point(4, 22);
                this.setting3.Name = "setting3";
                this.setting3.Size = new System.Drawing.Size(533, 332);
                this.setting3.TabIndex = 8;
                this.setting3.Text = "設定3";
                this.setting3.UseVisualStyleBackColor = true;
                // 
                // label18
                // 
                this.label18.AutoSize = true;
                this.label18.Location = new System.Drawing.Point(121, 97);
                this.label18.Name = "label18";
                this.label18.Size = new System.Drawing.Size(291, 12);
                this.label18.TabIndex = 2;
                this.label18.Text = "設定のログ出力先ディレクトリにimacoconow.logを出力します";
                this.label18.Visible = false;
                // 
                // chkDebugLog
                // 
                this.chkDebugLog.AutoSize = true;
                this.chkDebugLog.Location = new System.Drawing.Point(13, 96);
                this.chkDebugLog.Name = "chkDebugLog";
                this.chkDebugLog.Size = new System.Drawing.Size(102, 16);
                this.chkDebugLog.TabIndex = 1;
                this.chkDebugLog.Text = "デバッグログ出力";
                this.chkDebugLog.UseVisualStyleBackColor = true;
                this.chkDebugLog.Visible = false;
                this.chkDebugLog.CheckedChanged += new System.EventHandler(this.chkDebugLog_CheckedChanged);
                // 
                // groupBox9
                // 
                this.groupBox9.Controls.Add(this.label16);
                this.groupBox9.Controls.Add(this.chkSaveWinPos);
                this.groupBox9.Location = new System.Drawing.Point(7, 3);
                this.groupBox9.Name = "groupBox9";
                this.groupBox9.Size = new System.Drawing.Size(410, 70);
                this.groupBox9.TabIndex = 0;
                this.groupBox9.TabStop = false;
                this.groupBox9.Text = "Window位置";
                // 
                // label16
                // 
                this.label16.AutoSize = true;
                this.label16.Location = new System.Drawing.Point(6, 37);
                this.label16.Name = "label16";
                this.label16.Size = new System.Drawing.Size(307, 24);
                this.label16.TabIndex = 1;
                this.label16.Text = "うまく動作しないことがあります。\r\nその場合は画面外に行っていますので、手動で移動させてください\r\n";
                // 
                // chkSaveWinPos
                // 
                this.chkSaveWinPos.AutoSize = true;
                this.chkSaveWinPos.Location = new System.Drawing.Point(6, 18);
                this.chkSaveWinPos.Name = "chkSaveWinPos";
                this.chkSaveWinPos.Size = new System.Drawing.Size(138, 16);
                this.chkSaveWinPos.TabIndex = 0;
                this.chkSaveWinPos.Text = "Window位置を保存する";
                this.chkSaveWinPos.UseVisualStyleBackColor = true;
                this.chkSaveWinPos.CheckedChanged += new System.EventHandler(this.chkSaveWinPos_CheckedChanged);
                // 
                // tabPlugin
                // 
                this.tabPlugin.Controls.Add(this.chkDebug);
                this.tabPlugin.Controls.Add(this.button1);
                this.tabPlugin.Controls.Add(this.btnDebugWindow);
                this.tabPlugin.Controls.Add(this.btnPluginConfig);
                this.tabPlugin.Controls.Add(this.label50);
                this.tabPlugin.Controls.Add(this.cbPlugin);
                this.tabPlugin.Location = new System.Drawing.Point(4, 22);
                this.tabPlugin.Name = "tabPlugin";
                this.tabPlugin.Size = new System.Drawing.Size(533, 332);
                this.tabPlugin.TabIndex = 7;
                this.tabPlugin.Text = "プラグイン";
                this.tabPlugin.UseVisualStyleBackColor = true;
                // 
                // chkDebug
                // 
                this.chkDebug.AutoSize = true;
                this.chkDebug.Location = new System.Drawing.Point(114, 256);
                this.chkDebug.Name = "chkDebug";
                this.chkDebug.Size = new System.Drawing.Size(60, 16);
                this.chkDebug.TabIndex = 17;
                this.chkDebug.Text = "デバッグ";
                this.chkDebug.UseVisualStyleBackColor = true;
                this.chkDebug.Visible = false;
                this.chkDebug.CheckedChanged += new System.EventHandler(this.cbDebug_CheckedChanged);
                // 
                // button1
                // 
                this.button1.Location = new System.Drawing.Point(33, 249);
                this.button1.Name = "button1";
                this.button1.Size = new System.Drawing.Size(75, 23);
                this.button1.TabIndex = 18;
                this.button1.Text = "確認";
                this.button1.UseVisualStyleBackColor = true;
                this.button1.Visible = false;
                this.button1.Click += new System.EventHandler(this.button1_Click);
                // 
                // btnDebugWindow
                // 
                this.btnDebugWindow.Location = new System.Drawing.Point(179, 252);
                this.btnDebugWindow.Name = "btnDebugWindow";
                this.btnDebugWindow.Size = new System.Drawing.Size(75, 23);
                this.btnDebugWindow.TabIndex = 19;
                this.btnDebugWindow.Text = "Debug";
                this.btnDebugWindow.UseVisualStyleBackColor = true;
                this.btnDebugWindow.Visible = false;
                this.btnDebugWindow.Click += new System.EventHandler(this.button2_Click);
                // 
                // btnPluginConfig
                // 
                this.btnPluginConfig.Location = new System.Drawing.Point(299, 12);
                this.btnPluginConfig.Name = "btnPluginConfig";
                this.btnPluginConfig.Size = new System.Drawing.Size(75, 23);
                this.btnPluginConfig.TabIndex = 2;
                this.btnPluginConfig.Text = "設定";
                this.btnPluginConfig.UseVisualStyleBackColor = true;
                this.btnPluginConfig.Click += new System.EventHandler(this.btnPluginConfig_Click);
                // 
                // label50
                // 
                this.label50.AutoSize = true;
                this.label50.Location = new System.Drawing.Point(7, 17);
                this.label50.Name = "label50";
                this.label50.Size = new System.Drawing.Size(73, 12);
                this.label50.TabIndex = 1;
                this.label50.Text = "プラグイン一覧";
                // 
                // cbPlugin
                // 
                this.cbPlugin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cbPlugin.FormattingEnabled = true;
                this.cbPlugin.Location = new System.Drawing.Point(86, 14);
                this.cbPlugin.Name = "cbPlugin";
                this.cbPlugin.Size = new System.Drawing.Size(207, 20);
                this.cbPlugin.TabIndex = 0;
                this.cbPlugin.SelectedIndexChanged += new System.EventHandler(this.cbPlugin_SelectedIndexChanged);
                // 
                // tabAbout
                // 
                this.tabAbout.Controls.Add(this.label51);
                this.tabAbout.Controls.Add(this.label52);
                this.tabAbout.Controls.Add(this.label53);
                this.tabAbout.Controls.Add(this.label54);
                this.tabAbout.Controls.Add(this.pictureBox1);
                this.tabAbout.Controls.Add(this.label41);
                this.tabAbout.Controls.Add(this.linkLabel2);
                this.tabAbout.Controls.Add(this.linkLabel1);
                this.tabAbout.Controls.Add(this.lblVersion);
                this.tabAbout.Controls.Add(this.lblCopyright);
                this.tabAbout.Controls.Add(this.lblProductName);
                this.tabAbout.Location = new System.Drawing.Point(4, 22);
                this.tabAbout.Name = "tabAbout";
                this.tabAbout.Padding = new System.Windows.Forms.Padding(3);
                this.tabAbout.Size = new System.Drawing.Size(533, 332);
                this.tabAbout.TabIndex = 4;
                this.tabAbout.Text = "About";
                this.tabAbout.UseVisualStyleBackColor = true;
                // 
                // label51
                // 
                this.label51.Location = new System.Drawing.Point(12, 191);
                this.label51.Name = "label51";
                this.label51.Size = new System.Drawing.Size(373, 31);
                this.label51.TabIndex = 13;
                this.label51.Text = "Json.NET\r\n  Copyright (c) 2007 James Newton-King";
                // 
                // label52
                // 
                this.label52.Location = new System.Drawing.Point(22, 164);
                this.label52.Name = "label52";
                this.label52.Size = new System.Drawing.Size(373, 15);
                this.label52.TabIndex = 10;
                this.label52.Text = " <iseteki AT half-done DOT net>  All rights reserved.";
                // 
                // label53
                // 
                this.label53.Location = new System.Drawing.Point(12, 133);
                this.label53.Name = "label53";
                this.label53.Size = new System.Drawing.Size(209, 16);
                this.label53.TabIndex = 11;
                this.label53.Text = "EbiSoft.Library.PluginFramework.dll";
                // 
                // label54
                // 
                this.label54.Location = new System.Drawing.Point(22, 149);
                this.label54.Name = "label54";
                this.label54.Size = new System.Drawing.Size(324, 15);
                this.label54.TabIndex = 12;
                this.label54.Text = "Copyright (c) 2006-2009  Shin ISE (Nobuhiro Ito) ";
                // 
                // pictureBox1
                // 
                this.pictureBox1.Image = global::PCGPS.Properties.Resources.GPS;
                this.pictureBox1.Location = new System.Drawing.Point(6, 6);
                this.pictureBox1.Name = "pictureBox1";
                this.pictureBox1.Size = new System.Drawing.Size(64, 64);
                this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                this.pictureBox1.TabIndex = 4;
                this.pictureBox1.TabStop = false;
                // 
                // label41
                // 
                this.label41.AutoSize = true;
                this.label41.Location = new System.Drawing.Point(13, 108);
                this.label41.Name = "label41";
                this.label41.Size = new System.Drawing.Size(237, 12);
                this.label41.TabIndex = 3;
                this.label41.Text = "01Earth, inc.様の効果音素材を使用しています。";
                // 
                // linkLabel2
                // 
                this.linkLabel2.AutoSize = true;
                this.linkLabel2.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.linkLabel2.Location = new System.Drawing.Point(256, 105);
                this.linkLabel2.Name = "linkLabel2";
                this.linkLabel2.Size = new System.Drawing.Size(154, 18);
                this.linkLabel2.TabIndex = 2;
                this.linkLabel2.TabStop = true;
                this.linkLabel2.Text = "http://www.01earth.net/";
                this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
                // 
                // linkLabel1
                // 
                this.linkLabel1.AutoSize = true;
                this.linkLabel1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.linkLabel1.Location = new System.Drawing.Point(95, 73);
                this.linkLabel1.Name = "linkLabel1";
                this.linkLabel1.Size = new System.Drawing.Size(207, 18);
                this.linkLabel1.TabIndex = 2;
                this.linkLabel1.TabStop = true;
                this.linkLabel1.Text = "http://imakoko-gps.appspot.com/";
                this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
                // 
                // lblVersion
                // 
                this.lblVersion.AutoSize = true;
                this.lblVersion.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.lblVersion.Location = new System.Drawing.Point(95, 37);
                this.lblVersion.Name = "lblVersion";
                this.lblVersion.Size = new System.Drawing.Size(142, 18);
                this.lblVersion.TabIndex = 1;
                this.lblVersion.Text = "Version %d.%d.%d.%d";
                // 
                // lblCopyright
                // 
                this.lblCopyright.AutoSize = true;
                this.lblCopyright.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.lblCopyright.Location = new System.Drawing.Point(95, 55);
                this.lblCopyright.Name = "lblCopyright";
                this.lblCopyright.Size = new System.Drawing.Size(187, 18);
                this.lblCopyright.TabIndex = 1;
                this.lblCopyright.Text = "(c) 2009,2010 y_beta, fujitalon";
                // 
                // lblProductName
                // 
                this.lblProductName.AutoSize = true;
                this.lblProductName.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.lblProductName.Location = new System.Drawing.Point(76, 6);
                this.lblProductName.Name = "lblProductName";
                this.lblProductName.Size = new System.Drawing.Size(378, 31);
                this.lblProductName.TabIndex = 0;
                this.lblProductName.Text = "今ココなう！クラアント for Windows";
                // 
                // statusStrip1
                // 
                this.statusStrip1.AutoSize = false;
                this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
                this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtErr,
            this.stLblNoPost,
            this.stLblImakoko,
            this.stLblGPSPost,
            this.stLblSave,
            this.stLblNMEACount,
            this.stLblGPSMode,
            this.lblIndicator});
                this.statusStrip1.Location = new System.Drawing.Point(1, 414);
                this.statusStrip1.Name = "statusStrip1";
                this.statusStrip1.Size = new System.Drawing.Size(558, 27);
                this.statusStrip1.SizingGrip = false;
                this.statusStrip1.TabIndex = 17;
                this.statusStrip1.Text = "statusStrip1";
                // 
                // txtErr
                // 
                this.txtErr.AutoSize = false;
                this.txtErr.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
                this.txtErr.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
                this.txtErr.Name = "txtErr";
                this.txtErr.Size = new System.Drawing.Size(204, 22);
                this.txtErr.Text = "メッセージ";
                this.txtErr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // stLblNoPost
                // 
                this.stLblNoPost.AutoSize = false;
                this.stLblNoPost.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
                this.stLblNoPost.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
                this.stLblNoPost.Name = "stLblNoPost";
                this.stLblNoPost.Size = new System.Drawing.Size(44, 22);
                this.stLblNoPost.Text = "非通知";
                // 
                // stLblImakoko
                // 
                this.stLblImakoko.AutoSize = false;
                this.stLblImakoko.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
                this.stLblImakoko.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
                this.stLblImakoko.Name = "stLblImakoko";
                this.stLblImakoko.Size = new System.Drawing.Size(58, 22);
                this.stLblImakoko.Text = "自動ｲﾏｺｺ";
                // 
                // stLblGPSPost
                // 
                this.stLblGPSPost.AutoSize = false;
                this.stLblGPSPost.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
                this.stLblGPSPost.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
                this.stLblGPSPost.Name = "stLblGPSPost";
                this.stLblGPSPost.Size = new System.Drawing.Size(58, 22);
                this.stLblGPSPost.Text = "自動送信";
                // 
                // stLblSave
                // 
                this.stLblSave.AutoSize = false;
                this.stLblSave.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
                this.stLblSave.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
                this.stLblSave.Name = "stLblSave";
                this.stLblSave.Size = new System.Drawing.Size(44, 22);
                this.stLblSave.Text = "保存中";
                // 
                // stLblNMEACount
                // 
                this.stLblNMEACount.AutoSize = false;
                this.stLblNMEACount.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
                this.stLblNMEACount.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
                this.stLblNMEACount.Name = "stLblNMEACount";
                this.stLblNMEACount.Size = new System.Drawing.Size(72, 22);
                this.stLblNMEACount.Text = "0/0";
                this.stLblNMEACount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // stLblGPSMode
                // 
                this.stLblGPSMode.AutoSize = false;
                this.stLblGPSMode.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
                this.stLblGPSMode.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
                this.stLblGPSMode.Name = "stLblGPSMode";
                this.stLblGPSMode.Size = new System.Drawing.Size(38, 22);
                this.stLblGPSMode.Text = "DGPS";
                // 
                // lblIndicator
                // 
                this.lblIndicator.AutoSize = false;
                this.lblIndicator.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
                this.lblIndicator.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
                this.lblIndicator.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
                this.lblIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.lblIndicator.Name = "lblIndicator";
                this.lblIndicator.Size = new System.Drawing.Size(23, 22);
                this.lblIndicator.Text = "●";
                // 
                // btnNoPostArea
                // 
                this.btnNoPostArea.Enabled = false;
                this.btnNoPostArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.btnNoPostArea.Location = new System.Drawing.Point(5, 363);
                this.btnNoPostArea.Name = "btnNoPostArea";
                this.btnNoPostArea.Size = new System.Drawing.Size(221, 45);
                this.btnNoPostArea.TabIndex = 1;
                this.btnNoPostArea.Text = "非送信地帯登録";
                this.btnNoPostArea.UseVisualStyleBackColor = true;
                this.btnNoPostArea.Click += new System.EventHandler(this.btnNoPostArea_Click);
                // 
                // timer2
                // 
                this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
                // 
                // openFileDialog1
                // 
                this.openFileDialog1.FileName = "openFileDialog1";
                // 
                // mSpeedTimer
                // 
                this.mSpeedTimer.Tick += new System.EventHandler(this.mSpeedTimer_Tick);
                // 
                // mTaxiTimeFareTimer
                // 
                this.mTaxiTimeFareTimer.Tick += new System.EventHandler(this.mTaxiTimeFareTimer_Tick);
                // 
                // mBtnKuusha
                // 
                this.mBtnKuusha.Appearance = System.Windows.Forms.Appearance.Button;
                this.mBtnKuusha.BackColor = System.Drawing.Color.Red;
                this.mBtnKuusha.Checked = true;
                this.mBtnKuusha.CheckState = System.Windows.Forms.CheckState.Checked;
                this.mBtnKuusha.Enabled = false;
                this.mBtnKuusha.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.mBtnKuusha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                this.mBtnKuusha.Location = new System.Drawing.Point(264, 151);
                this.mBtnKuusha.Name = "mBtnKuusha";
                this.mBtnKuusha.Size = new System.Drawing.Size(66, 47);
                this.mBtnKuusha.TabIndex = 103;
                this.mBtnKuusha.TabStop = false;
                this.mBtnKuusha.Text = "空車";
                this.mBtnKuusha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                this.mBtnKuusha.UseVisualStyleBackColor = false;
                this.mBtnKuusha.CheckedChanged += new System.EventHandler(this.mBtnKuusha_CheckedChanged);
                // 
                // mBtnJissha
                // 
                this.mBtnJissha.Appearance = System.Windows.Forms.Appearance.Button;
                this.mBtnJissha.BackColor = System.Drawing.Color.DarkCyan;
                this.mBtnJissha.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.mBtnJissha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                this.mBtnJissha.Location = new System.Drawing.Point(330, 151);
                this.mBtnJissha.Name = "mBtnJissha";
                this.mBtnJissha.Size = new System.Drawing.Size(65, 47);
                this.mBtnJissha.TabIndex = 103;
                this.mBtnJissha.TabStop = false;
                this.mBtnJissha.Text = "実車";
                this.mBtnJissha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                this.mBtnJissha.UseVisualStyleBackColor = false;
                this.mBtnJissha.CheckedChanged += new System.EventHandler(this.mBtnJissha_CheckedChanged);
                // 
                // mBtnKosoku
                // 
                this.mBtnKosoku.Appearance = System.Windows.Forms.Appearance.Button;
                this.mBtnKosoku.BackColor = System.Drawing.Color.Green;
                this.mBtnKosoku.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.mBtnKosoku.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                this.mBtnKosoku.Location = new System.Drawing.Point(395, 151);
                this.mBtnKosoku.Name = "mBtnKosoku";
                this.mBtnKosoku.Size = new System.Drawing.Size(64, 47);
                this.mBtnKosoku.TabIndex = 103;
                this.mBtnKosoku.TabStop = false;
                this.mBtnKosoku.Text = "高速";
                this.mBtnKosoku.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                this.mBtnKosoku.UseVisualStyleBackColor = false;
                this.mBtnKosoku.CheckedChanged += new System.EventHandler(this.mBtnKosoku_CheckedChanged);
                // 
                // mBtnShiharai
                // 
                this.mBtnShiharai.Appearance = System.Windows.Forms.Appearance.Button;
                this.mBtnShiharai.BackColor = System.Drawing.Color.Olive;
                this.mBtnShiharai.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
                this.mBtnShiharai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                this.mBtnShiharai.Location = new System.Drawing.Point(459, 151);
                this.mBtnShiharai.Name = "mBtnShiharai";
                this.mBtnShiharai.Size = new System.Drawing.Size(64, 47);
                this.mBtnShiharai.TabIndex = 103;
                this.mBtnShiharai.TabStop = false;
                this.mBtnShiharai.Text = "支払";
                this.mBtnShiharai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                this.mBtnShiharai.UseVisualStyleBackColor = false;
                this.mBtnShiharai.CheckedChanged += new System.EventHandler(this.mBtnShiharai_CheckedChanged);
                // 
                // mPosServerTimer
                // 
                this.mPosServerTimer.Interval = 5000;
                this.mPosServerTimer.Tick += new System.EventHandler(this.mPosServerTimer_Tick);
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(542, 441);
                this.Controls.Add(this.statusStrip1);
                this.Controls.Add(this.tabControl1);
                this.Controls.Add(this.btnNoPostArea);
                this.Controls.Add(this.btnCommOpenClose);
                this.Controls.Add(this.btnFTPPost);
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.MaximizeBox = false;
                this.Name = "Form1";
                this.Text = "今ココなう！クライアントツール";
                this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
                this.Load += new System.EventHandler(this.Form1_Load);
                this.Move += new System.EventHandler(this.Form1_Move);
                this.grpGPS.ResumeLayout(false);
                this.grpGPS.PerformLayout();
                this.grpFTP.ResumeLayout(false);
                this.grpFTP.PerformLayout();
                this.tabControl1.ResumeLayout(false);
                this.main.ResumeLayout(false);
                this.main.PerformLayout();
                this.groupBox5.ResumeLayout(false);
                ((System.ComponentModel.ISupportInitialize)(this.picNear1)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.picNear2)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.picMyDirection)).EndInit();
                this.tabNearby.ResumeLayout(false);
                this.detail.ResumeLayout(false);
                this.detail.PerformLayout();
                this.setting.ResumeLayout(false);
                this.groupBox7.ResumeLayout(false);
                this.groupBox7.PerformLayout();
                this.groupBox3.ResumeLayout(false);
                this.groupBox3.PerformLayout();
                this.groupBox2.ResumeLayout(false);
                this.groupBox2.PerformLayout();
                this.groupBox1.ResumeLayout(false);
                this.groupBox1.PerformLayout();
                this.setting2.ResumeLayout(false);
                this.groupBox8.ResumeLayout(false);
                this.groupBox8.PerformLayout();
                this.groupBox6.ResumeLayout(false);
                this.groupBox6.PerformLayout();
                this.YomiageGroup.ResumeLayout(false);
                this.YomiageGroup.PerformLayout();
                this.groupBox4.ResumeLayout(false);
                this.groupBox4.PerformLayout();
                this.setting3.ResumeLayout(false);
                this.setting3.PerformLayout();
                this.groupBox9.ResumeLayout(false);
                this.groupBox9.PerformLayout();
                this.tabPlugin.ResumeLayout(false);
                this.tabPlugin.PerformLayout();
                this.tabAbout.ResumeLayout(false);
                this.tabAbout.PerformLayout();
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
                this.statusStrip1.ResumeLayout(false);
                this.statusStrip1.PerformLayout();
                this.ResumeLayout(false);

            }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.GroupBox grpGPS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGpsH;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGpsMode;
        private System.Windows.Forms.Button btnFTPPost;
        private System.Windows.Forms.GroupBox grpFTP;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkSaveLog;
        private System.Windows.Forms.TextBox txtGpsCount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbSerial;
        private System.Windows.Forms.ComboBox cbBaud;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtGpsDirection;
        private System.Windows.Forms.TextBox txtGpsVelocity;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnGetAddress;
        private System.Windows.Forms.ComboBox cbPostInterval;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtDistance;
        private System.Windows.Forms.TextBox txtDOP;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtAcc;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage main;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel txtErr;
        private System.Windows.Forms.ToolStripStatusLabel lblIndicator;
        private System.Windows.Forms.TabPage setting;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnTwitterPost;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblOAuth;
        private System.Windows.Forms.ToolStripStatusLabel stLblNMEACount;
        private System.Windows.Forms.TabPage detail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGpsLon;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtGpsLat;
        private System.Windows.Forms.TextBox txtGpsTime;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ToolStripStatusLabel stLblGPSPost;
        private System.Windows.Forms.ToolStripStatusLabel stLblGPSMode;
        private System.Windows.Forms.ToolStripStatusLabel stLblSave;
        private System.Windows.Forms.TextBox txtGpsVelocity2;
        private System.Windows.Forms.TextBox txtGpsLat2;
        private System.Windows.Forms.TextBox txtGpsLon2;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox txtDistance2;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Button btnNoPostArea;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnDeleteNoPost;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbRadius;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbNoPost;
        private System.Windows.Forms.ToolStripStatusLabel stLblNoPost;
        private System.Windows.Forms.Button btnAddNoPost;
        private System.Windows.Forms.CheckBox chkMapURL;
        private System.Windows.Forms.TextBox txtMapURL;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Button btnTinyURL;
        private System.Windows.Forms.TextBox txtTinyURL;
        private System.Windows.Forms.CheckBox chkLatLon;
        private System.Windows.Forms.TabPage tabAbout;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.CheckBox chkSaveServer;
        private System.Windows.Forms.TextBox txtImakoko;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ProgressBar prgAutoImakoko;
        private System.Windows.Forms.CheckBox chkSpeedFilter;
        private System.Windows.Forms.ToolStripStatusLabel stLblImakoko;
        private System.Windows.Forms.ComboBox cbIcon;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ProgressBar prgAutoPost;
        private System.Windows.Forms.TabPage tabNearby;
        private System.Windows.Forms.CheckBox chkHashTag;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage setting2;
        private System.Windows.Forms.GroupBox YomiageGroup;
        private System.Windows.Forms.RadioButton rbBouyomi;
        private System.Windows.Forms.RadioButton rbYomiageSoftalk;
        private System.Windows.Forms.CheckBox chkYomiage;
        private System.Windows.Forms.CheckBox chkSound;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.ComboBox cbAlertCheckInterval;
        private System.Windows.Forms.ComboBox cbRaderRange;
        private System.Windows.Forms.Button btnSoftalkSetting;
        private System.Windows.Forms.TextBox txtSoftalk;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtRaderOut;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox txtRaderIn;
        private System.Windows.Forms.PictureBox picMyDirection;
        private System.Windows.Forms.Label lblNear1;
        private System.Windows.Forms.PictureBox picNear2;
        private System.Windows.Forms.PictureBox picNear1;
        private System.Windows.Forms.Label lblNear2;
        private System.Windows.Forms.GroupBox groupBox5;
        public System.Windows.Forms.Button btnCommOpenClose;
        public System.Windows.Forms.CheckBox chkAutoPost;
        public System.Windows.Forms.CheckBox chkAutoTwit;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox chkNeverShow;
        private System.Windows.Forms.CheckBox chkRestart;
        private System.Windows.Forms.CheckBox chkSend;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txtProxyPort;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.TextBox txtProxyServer;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.CheckBox chkUseNearAlert;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Button btnSoundReset;
        private System.Windows.Forms.Button btnSoundRaderIn;
        private System.Windows.Forms.Button btnSoundRaderOut;
        private System.Windows.Forms.Button btnSoundTwit;
        private System.Windows.Forms.Button btnSoundPost;
        private System.Windows.Forms.TextBox txtSoundRaderOut;
        private System.Windows.Forms.TextBox txtSoundRaderIn;
        private System.Windows.Forms.TextBox txtSoundTwit;
        private System.Windows.Forms.TextBox txtSoundPost;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.CheckBox chkTwitLocation;
        private System.Windows.Forms.TabPage tabPlugin;
        private System.Windows.Forms.Button btnPluginConfig;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.ComboBox cbPlugin;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Button btnLogDirectory;
        private System.Windows.Forms.TextBox txtLogDirectory;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.CheckBox cbNoSameAddress;
        private System.Windows.Forms.Button btnXAuth;
        private System.Windows.Forms.CheckBox chkDebug;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDebugWindow;
        private System.Windows.Forms.TabPage setting3;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox chkSaveWinPos;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.CheckBox chkDebugLog;
        private System.Windows.Forms.Timer mSpeedTimer;
        private System.Windows.Forms.Timer mTaxiTimeFareTimer;
        private System.Windows.Forms.CheckBox mBtnKuusha;
        private System.Windows.Forms.CheckBox mBtnShiharai;
        private System.Windows.Forms.CheckBox mBtnKosoku;
        private System.Windows.Forms.CheckBox mBtnJissha;
        private System.Windows.Forms.Timer mPosServerTimer;
        }
    }

