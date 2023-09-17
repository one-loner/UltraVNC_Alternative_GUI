using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace VNC1
{
    public partial class Form1 : Form
    {
        public string dir = System.IO.Directory.GetCurrentDirectory() + "\\connections\\";
        string VNCPath = System.IO.Directory.GetCurrentDirectory() + "\\vncviewer.exe";
        public string selectedListBoxItem = "";
        public string h = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
       

            if (Directory.Exists(dir))
            {
                string[] files = Directory.GetFiles(dir, "*.txt");

                foreach (string file in files)
                {
                    string fileName = Path.GetFileNameWithoutExtension(file);
                    listBox1.Items.Add(fileName);
                }
            }
            else
            {
                MessageBox.Show("Directory not exsists.");
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string d = "";
            try
            {
                selectedListBoxItem = listBox1.SelectedItem.ToString();
                string dp = dir + selectedListBoxItem + ".txt";
                string raw = System.IO.File.ReadAllText(dp, Encoding.GetEncoding("UTF-8"));
                string[] ar = raw.Split('\n');
                h = ar[0];
                d = ar[1];
            }
            catch { }
            finally
            {
                button1.Enabled = true;
                textBox1.Text = d;
                label4.Text = h;
            }

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string args = h + " -password " + textBox2.Text;
            Process.Start(VNCPath, args);
        }
    }
}