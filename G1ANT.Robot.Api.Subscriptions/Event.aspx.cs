using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace G1ANT.Robot.Api.Subscriptions
{
    public partial class ProcessStart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string fileName = Server.MapPath("~/App_Data") + "/lastevent.json";
            using (var reader = new StreamReader(Request.InputStream))
            {
                string body = reader.ReadToEnd();
                File.WriteAllText(fileName, body);
            }
        }
    }
}