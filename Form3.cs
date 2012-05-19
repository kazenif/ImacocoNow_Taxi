using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PCGPS
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public void SetText(string s)
        {
            textBox1.Text = s;
        }

        delegate void AppendTextCallback(string s);

        public void AppendText(string s)
        {
            if (textBox1.InvokeRequired)
            {
                AppendTextCallback c = new AppendTextCallback(AppendText);
                Invoke(c, new Object[] { s });
            }
            else
            {
                textBox1.Text = DateTime.Now.ToShortTimeString() + ":" + s + textBox1.Text;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
