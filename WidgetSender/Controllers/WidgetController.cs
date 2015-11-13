using System.Web.Mvc;
using WebApplication1.Models;
using System.Runtime.Serialization.Json;
using System.Text;
using System.IO;
using System.Web.Script.Serialization;
using System;
using System.Web.Helpers;

namespace WebApplication1.Controllers
{
    public class WidgetController : Controller
    {
        // GET: /Widget
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Widget/WebApi
        public ActionResult WebApi()
        {
            return View();
        }

        // GET: /Widget/MvcJson
        public ActionResult MvcJson()
        {
            return View();
        }

        // POST: /Widget/MvcJson
        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public ActionResult MvcJson(SendWidgetModel sendWidgetModel)
        {
            return Json(string.Format("Sent {0} to {1}", sendWidgetModel.widgetMessage, sendWidgetModel.toEmail), JsonRequestBehavior.DenyGet);
        }

        // POST: /Widget/Send
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Send(SendWidgetModel sendWidgetModel)
        {
            var json = new JavaScriptSerializer().Serialize(sendWidgetModel);
            Session["widget"] = json;
            return RedirectToAction("Sent");
        }

        // POST: /Widget/Preview
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Preview(SendWidgetModel sendWidgetModel)
        {
            var json = new JavaScriptSerializer().Serialize(sendWidgetModel);
            Session["widget"] = json;
            return RedirectToAction("Sent");
        }

        // GET: Widget/Sent
        public ActionResult Sent()
        {
            if (Session["widget"] == null)
            {
                return RedirectToAction("Index");
            }
            string widget = (string)Session["widget"];
            var json = new DataContractJsonSerializer(typeof(SendWidgetModel));
            var ms = new MemoryStream(Encoding.ASCII.GetBytes(widget));
            var model = (SendWidgetModel)json.ReadObject(ms);
            return View(model);
        }

        [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
        public class ValidateJsonAntiForgeryTokenAttribute : FilterAttribute, IAuthorizationFilter
        {
            public void OnAuthorization(AuthorizationContext filterContext)
            {
                if (filterContext == null)
                {
                    throw new ArgumentNullException("filterContext");
                }

                var httpContext = filterContext.HttpContext;
                var cookie = httpContext.Request.Cookies[AntiForgeryConfig.CookieName];
                AntiForgery.Validate(cookie != null ? cookie.Value : null, httpContext.Request.Headers["__RequestVerificationToken"]);
            }
        }
    }
}
