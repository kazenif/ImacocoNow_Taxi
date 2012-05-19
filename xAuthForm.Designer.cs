namespace PCGPS
{
    partial class xAuthForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTwitterPassword = new System.Windows.Forms.TextBox();
            this.txtTwitterID = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCancel.Location = new System.Drawing.Point(165, 21);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 26);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "認証";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnXAuth_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 12);
            this.label2.TabIndex = 2;
            // 
            // txtTwitterPassword
            // 
            this.txtTwitterPassword.Location = new System.Drawing.Point(72, 28);
            this.txtTwitterPassword.Name = "txtTwitterPassword";
            this.txtTwitterPassword.PasswordChar = '*';
            this.txtTwitterPassword.Size = new System.Drawing.Size(87, 19);
            this.txtTwitterPassword.TabIndex = 6;
            // 
            // txtTwitterID
            // 
            this.txtTwitterID.Location = new System.Drawing.Point(72, 6);
            this.txtTwitterID.Name = "txtTwitterID";
            this.txtTwitterID.Size = new System.Drawing.Size(87, 19);
            this.txtTwitterID.TabIndex = 4;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(12, 31);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(54, 12);
            this.label18.TabIndex = 5;
            this.label18.Text = "Password";
            // 
            // xAuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 56);
            this.ControlBox = false;
            this.Controls.Add(this.txtTwitterPassword);
            this.Controls.Add(this.txtTwitterID);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "xAuthForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Twitter xAuth認証";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.xAuthForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTwitterPassword;
        private System.Windows.Forms.TextBox txtTwitterID;
        private System.Windows.Forms.Label label18;
    }
}