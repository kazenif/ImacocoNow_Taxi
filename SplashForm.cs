using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace PCGPS
{
    public partial class SplashForm : Form, IDisposable
    {
        static readonly object syncObj = new object();
        static Thread _thread = null;
        static SplashForm _form = null;

        public static void ShowSplash()
        {
            if (_form != null || _thread != null)
                return;

            ThreadStart ts = () =>
            {
                _form = new SplashForm();
                _form.Click += new EventHandler(form_Click);
                Application.Run(_form);
            };

            _thread = new Thread(ts);
            _thread.IsBackground = true;
            _thread.SetApartmentState(ApartmentState.STA);
            _thread.Name = "SplashForm";
            _thread.Start();

        }

        public static void CloseSplash()
        {
            lock (syncObj)
            {
                if (_form != null && _form.IsDisposed == false)
                {
                    if (_form.InvokeRequired)
                    {
                        _form.Invoke(new MethodInvoker(_form.Close));
                    }
                    else
                    {
                        _form.Close();
                    }
                }
            }
        }


        static void form_Click(object sender, EventArgs e)
        {
            CloseSplash();
        }

        public SplashForm()
        {
            InitializeComponent();
        }

        #region IDisposable メンバ
        void IDisposable.Dispose()
        {
            _form = null;
            _thread = null;
        }
        #endregion

        private void SplashForm_Load(object sender, EventArgs e)
        {
            Util.PlaySE("PCGPS.Resources.b_021.wav");

            this.timer1.Interval = 5000;
            this.timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CloseSplash();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
