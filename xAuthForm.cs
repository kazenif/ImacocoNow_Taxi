using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using PCGPS.OAuth;

namespace PCGPS
{
    public partial class xAuthForm : Form
    {
        public xAuthForm()
        {
            InitializeComponent();
        }

        private void btnXAuth_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                Properties.Settings.Default.OAuthToken = "";
                Properties.Settings.Default.OAuthTokenSecret = "";
                TwitterOAuth.getInstance().getAccessToken(txtTwitterID.Text, txtTwitterPassword.Text);
                MessageBox.Show("認証成功", "Twitter 認証", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "認証失敗", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Cursor.Current = Cursors.Default;
        }

        private void xAuthForm_Load(object sender, EventArgs e)
        {
            this.txtTwitterID.Text = "";
            this.txtTwitterPassword.Text = "";
        }
    }
}
