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

namespace WinFormUpload
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += bw_DoWork;
            bw.RunWorkerAsync();
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            WebClient myWebClient = new WebClient();
            myWebClient.UploadFile("http://172.31.132.44:8892/WebForm1.aspx", "POST", @"D:/soft/ietester.zip");
            label1.Invoke(new Action(() => label1.Text = "ok"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += bw_DoWork2;
            bw.RunWorkerAsync();
        }

        private void bw_DoWork2(object sender, DoWorkEventArgs e)
        {
            WebClient WClient = new WebClient();
            System.Collections.Specialized.NameValueCollection VarPost = new System.Collections.Specialized.NameValueCollection();//用于存放post数据
            VarPost.Add("ID", txtID.Text); //数据ID
            VarPost.Add("Type", txtType.Text); //标识

            byte[] imageSource = SetImageToByteArray(txtPath.Text);
            //转Base64
            string Base64 = Convert.ToBase64String(imageSource);
            VarPost.Add("ImageID", Guid.NewGuid().ToString()); //图片ID
            VarPost.Add("Image", Base64); //图片字符

            byte[] RemoteByte = WClient.UploadValues("http://172.31.132.44:8892/WebForm2.aspx", "POST", VarPost);//提交post请求

            label1.Invoke(new Action(() => label1.Text = WebClientResult(RemoteByte) ? "ok" : "error"));
        }

        //根据文件名(完全路径)
        public byte[] SetImageToByteArray(string fileName)
        {
            //图片转二进制
            FileStream fs = new FileStream(fileName, FileMode.Open);
            int streamLength = (int)fs.Length;
            byte[] image = new byte[streamLength];
            fs.Read(image, 0, streamLength);
            fs.Close();
            return image;
        }

        public bool WebClientResult(byte[] result)
        {
            string html = Encoding.Default.GetString(result, 0, result.Length);
            return html.IndexOf("Resule->OK") > 0;
        }
    }
}
