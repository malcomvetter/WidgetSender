using System;

namespace WebApplication1
{
    public partial class XSS1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var img = Server.UrlDecode(Request.QueryString["img"]);
            literal1.Text = string.Format("<img src={0}>", img);
        }
    }
}