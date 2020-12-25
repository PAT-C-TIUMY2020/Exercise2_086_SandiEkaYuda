using Service_20180140086_SandiEkaYuda;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerForm_20180140086_SandiEkaYuda
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServiceHost hostObject = null;

            try
            {
                hostObject = new ServiceHost(typeof(TI_UMY));
                hostObject.Open();
                label2.Text = "Server ON";
                label3.Text = "Klik OFF untuk Menonaktifkan Server";
                button1.Enabled = false;
                button2.Enabled = true;
            }
            catch (Exception ex)
            {
                hostObject = null;
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            ServiceHost hostObject = null;

            try
            {
                hostObject = new ServiceHost(typeof(TI_UMY));
                hostObject.Close();
                label2.Text = "Server OFF";
                label3.Text = "Klik OFF untuk Menonaktifkan Server";
                button1.Enabled = true;
                button2.Enabled = false;
            }
            catch (Exception ex)
            {
                hostObject = null;
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
