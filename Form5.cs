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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        delegate void SetDataCallback();
        public void SetLabel()
        {
            if (label2.InvokeRequired)
            {
                SetDataCallback c = new SetDataCallback(SetLabel);
                Invoke(c);
            }
            else
            {
                label2.Text = l;
            }
        }

        string l;
        public string Label
        {
            set
            {
                l = value;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            /*
            Thread t = new Thread(delegate()
            {
                while (DialogResult == DialogResult.None)
                {
                    SetLabel(l);
                    Thread.Sleep(100);
                }
            });
            t.IsBackground = true;
            t.Start();
             */
        }
    }
}
