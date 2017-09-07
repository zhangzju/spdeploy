using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tftp.Net;

namespace spdeploy
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public struct spdeployConfig
        {
            public string configPath;
            public string ispName;
            public string serverPath;
            public string deviceModel;
            public spdeployConfig(string config_path, string isp_name, string server_path, string device_model)
            {
                configPath = config_path;
                ispName = isp_name;
                serverPath = server_path;
                deviceModel = device_model;
            }
        }
    }
}
