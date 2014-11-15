using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WebApplication1
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            for (int i = 2015; i < 2019; i++)
            {
                for (int j = 1; j < 13; j++)
                {
                    string fileName = i.ToString() + j.ToString().PadLeft(2, '0');
                    Directory.CreateDirectory(Server.MapPath("~/Upload/") + fileName);
                }
            }
        }
    }
}