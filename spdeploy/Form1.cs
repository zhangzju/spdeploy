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
        static string filePath = Application.StartupPath + "\\config";
        static string ispName = "MNET";
        static string serverPath = Application.StartupPath;
        static string deviceModel = "VR500";
        Program.spdeployConfig config = new Program.spdeployConfig();

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

                filePath = folderBrowserDialog1.SelectedPath;
                config.configPath = filePath + "\\config";
                MessageBox.Show(config.configPath);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog config_file = new OpenFileDialog();
            config_file.InitialDirectory = filePath;
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

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }
    }
}
