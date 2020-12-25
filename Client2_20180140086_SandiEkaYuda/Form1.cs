using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client2_20180140086_SandiEkaYuda
{
    public partial class Form1 : Form
    {
        ClassData classData = new ClassData();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    ClassData classData = new ClassData();
                    classData.deleteMahasiswa(textBox1.Text);
                    dataGridView1.DataSource = classData.getAllData();
                    MessageBox.Show("Data successfuly deleted");
                }
                catch (Exception ex)
                {
                 
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" &&
               textBox2.Text != "" &&
               textBox3.Text != "" &&
               textBox4.Text != "")
            {
                if (textBox1.Text.Length <= 12 &&
                textBox4.Text.Length <= 4 &&
                textBox3.Text.Length <= 30 &&
                textBox2.Text.Length <= 20)
                {
                    try
                    {
                        Mahasiswa mhs = new Mahasiswa();
                        mhs.nim = textBox1.Text;
                        mhs.nama = textBox2.Text;
                        mhs.prodi = textBox3.Text;
                        mhs.angkatan = textBox4.Text;

                        ClassData classData = new ClassData();
                        classData.updateDatabase(mhs);
                        MessageBox.Show("Data successfuly updated");

                        dataGridView1.DataSource = classData.getAllData();
                    }
                    catch
                    {
                        label5.Text = "Server Error";
                    }
                }
                else
                {
                    MessageBox.Show("Please check your data");
                }
            }
            else
            {
                MessageBox.Show("Please check your data");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        public void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

        }
        private void button3_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = classData.getAllData();
            }
            catch
            {
                label5.Text = "Server error";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var json = new WebClient().DownloadString("http://localhost:0409/Mahasiswa");
            var data = JsonConvert.DeserializeObject<List<Mahasiswa>>(json);
            int length = data.Count();
            label6.Text = Convert.ToString(length);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
