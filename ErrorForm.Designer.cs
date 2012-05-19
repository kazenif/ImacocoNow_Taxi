namespace PCGPS
{
    partial class ErrorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.chkNeverDisplay = new System.Windows.Forms.CheckBox();
            this.chkReboot = new System.Windows.Forms.CheckBox();
            this.chkSend = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "不具合により致命的なエラーが発生したため、\r\n処理を継続することができません。\r\nご迷惑をおかけしております。";
            // 
            // chkNeverDisplay
            // 
            this.chkNeverDisplay.AutoSize = true;
            this.chkNeverDisplay.Location = new System.Drawing.Point(12, 237);
            this.chkNeverDisplay.Name = "chkNeverDisplay";
            this.chkNeverDisplay.Size = new System.Drawing.Size(168, 16);
            this.chkNeverDisplay.TabIndex = 2;
            this.chkNeverDisplay.Text = "今後、このダイアログを出さない";
            this.chkNeverDisplay.UseVisualStyleBackColor = true;
            // 
            // chkReboot
            // 
            this.chkReboot.AutoSize = true;
            this.chkReboot.Checked = true;
            this.chkReboot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReboot.Location = new System.Drawing.Point(12, 215);
            this.chkReboot.Name = "chkReboot";
            this.chkReboot.Size = new System.Drawing.Size(196, 16);
            this.chkReboot.TabIndex = 3;
            this.chkReboot.Text = "今ココなう！クライアントを再起動する";
            this.chkReboot.UseVisualStyleBackColor = true;
            // 
            // chkSend
            // 
            this.chkSend.AutoSize = true;
            this.chkSend.Enabled = false;
            this.chkSend.Location = new System.Drawing.Point(12, 193);
            this.chkSend.Name = "chkSend";
            this.chkSend.Size = new System.Drawing.Size(137, 16);
            this.chkSend.TabIndex = 3;
            this.chkSend.Text = "エラーの内容を送信する";
            this.chkSend.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(251, 237);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 51);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(314, 124);
            this.textBox1.TabIndex = 5;
            // 
            // ErrorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 272);
            this.ControlBox = false;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkSend);
            this.Controls.Add(this.chkReboot);
            this.Controls.Add(this.chkNeverDisplay);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ErrorForm";
            this.Text = "致命的なエラー";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.CheckBox chkNeverDisplay;
        public System.Windows.Forms.CheckBox chkReboot;
        public System.Windows.Forms.CheckBox chkSend;
    }
}