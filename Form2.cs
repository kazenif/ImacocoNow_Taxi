using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PCGPS
{
    public partial class Form2 : Form
    {
        private Double lat, lon;
        private string name;

        public Double Lat
        {
            set
            {
                textBox1.Text = value.ToString();
            }
            get
            {
                return lat;
            }
        }
        public Double Lon
        {
            set
            {
                textBox2.Text = value.ToString();
            }
            get
            {
                return lon;
            }
        }
        public string PosName
        {
            set
            {
                textBox3.Text = value;
            }
            get
            {
                return textBox3.Text;
            }
        }
        
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lat = Double.Parse(textBox1.Text);
                lon = Double.Parse(textBox2.Text);
                name = textBox3.Text;
                btnFm2OK.Enabled = name.Length > 0;
            }
            catch (Exception /*e */)
            {
            }
        }
    }
}
