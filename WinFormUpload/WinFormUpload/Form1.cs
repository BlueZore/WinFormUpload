using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            

            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork+=bw_DoWork;
            bw.RunWorkerAsync();
            
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            WebClient myWebClient = new WebClient();
            myWebClient.UploadFile("http://172.31.132.44:8891/WebForm1.aspx", "POST", @"D:/soft/ietester.zip");
            label1.Invoke(new Action(() => label1.Text = "ok"));
        }
    }
}
