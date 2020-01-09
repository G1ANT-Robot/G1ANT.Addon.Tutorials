using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace G1ANT.Robot.Api.Subscriptions
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string fileName = Server.MapPath("~/App_Data") + "/lastevent.json";
            if (File.Exists(fileName))
                Response.Write(File.ReadAllText(fileName));
            else
                Response.Write("Empty");
        }
    }
}