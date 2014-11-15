using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        string Path = "~/Upload/";

        //string ID = "";
        //string Type = "";
        //string ImageID = "";
        string ImagePath = "";
        string Image = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Flush();
            try
            {
                //ID = Request.Form["ID"];
                //Type = Request.Form["Type"];
                ImagePath = Request.Form["ImagePath"];
                Image = Request.Form["Image"];
                SaveStringToImage(Image, ImagePath);

                Response.Write(" Resule->OK");
            }
            catch
            {
                Response.Write(" Resule->ERROR");
            }
        }

        public void SaveStringToImage(string data, string ImagePath)
        {
            string savePath = Server.MapPath(Path) + ImagePath;

            byte[] buf = Convert.FromBase64String(data);//把字符串读到字节数组中
            MemoryStream ms = new MemoryStream(buf);
            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);

            img.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            ms.Close();
            ms.Dispose();
        }
    }
}