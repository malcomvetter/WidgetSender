using System;

namespace WebApplication1
{
    public partial class XSS2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var name = Server.UrlDecode(Request.QueryString["name"]);
            literal1.Text = string.Format("Welcome {0}", name);
        }
    }
}