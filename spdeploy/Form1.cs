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
        static string filePath = Application.StartupPath + "\\config\\";
        static string ispName = "MNET";
        static string serverPath = Application.StartupPath;
        static string deviceModel = "VR500";
        static char[] flashMode = {'0','0','0','0','0'};
        static string[] flashModeList = {"Image(boot)", "Image(kernel)", "Image(rootfs)", "Config(user)", "Config(second)"};
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
                serverPath = filePath + "\\config\\default.config";
                if(File.Exists(serverPath))
                {
                    MessageBox.Show("配置文件路径为" + serverPath);
                }
                else
                {
                    MessageBox.Show("这不是一个合法的路径！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
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
                    string line;
                    StreamReader spconfig = new StreamReader(file);
                    if((line = spconfig.ReadLine()) != null)
                    {
                        //config.ispName = line;
                        string showInfo = "运营商是"+line+"?";
                        if(MessageBox.Show(showInfo,"Confirm Message",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            ispName = line;
                        }
                    }

                    if((line = spconfig.ReadLine()) != null)
                    {                  
                        string showInfo = "机型是" + line + "?";
                        if (MessageBox.Show(showInfo, "Confirm Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            deviceModel = line;
                        }
                    }

                    MessageBox.Show("运营商设定为" + ispName + "," + "机型设定为" + deviceModel);

                    spconfig.Close();

                }
                catch (Exception)
                {
                    throw;
                }
                
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int itemIndex;
            for(itemIndex=0; itemIndex < checkedListBox1.Items.Count; itemIndex++)
            {
                if(checkedListBox1.GetItemChecked(itemIndex))
                {
                    //MessageBox.Show(flashModeList[itemIndex]);
                    flashMode[itemIndex] = '1';
                }
            }

            MessageBox.Show(new string(flashMode));
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
            MessageBox.Show(comboBox1.SelectedItem.ToString());
            ispName = comboBox1.SelectedItem.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            deviceModel = comboBox2.SelectedItem.ToString();
            MessageBox.Show(comboBox2.SelectedItem.ToString());
        }
    }
}
