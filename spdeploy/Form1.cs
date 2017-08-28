using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace spdeploy
{
    public partial class Form1 : Form
    {
        static string filepath = Application.StartupPath;

        public Form1(IContainer components, FolderBrowserDialog folderBrowserDialog1, Button button1, Button button2)
        {
            this.components = components;
            this.folderBrowserDialog1 = folderBrowserDialog1;
            this.button1 = button1;
            this.button2 = button2;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = folderBrowserDialog1.ShowDialog();
            if( dialogResult == System.Windows.Forms.DialogResult.OK)
            {
                MessageBox.Show(folderBrowserDialog1.SelectedPath);
                filepath = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog config_file = new OpenFileDialog();
            config_file.InitialDirectory = filepath;
            DialogResult result = config_file.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = config_file.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    MessageBox.Show(text);
                }
                catch (Exception)
                {
                    throw;
                }
                
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }
    }
}
