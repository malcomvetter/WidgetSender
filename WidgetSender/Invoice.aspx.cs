using System;

namespace WidgetSender
{
    public partial class Invoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var file = Server.UrlDecode(Request.QueryString["ID"]);
            if (string.IsNullOrWhiteSpace(file))
            {
                Response.Redirect("/");
                return;
            }
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.WriteFile(file);
            Response.End();
        }
    }
}