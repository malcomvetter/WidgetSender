using System.Web.Http;

namespace WidgetSender.api
{
    public class WidgetController : ApiController
    {
        // GET /api/
        public IHttpActionResult Get()
        {
            return Ok("Widget API Ready");
        }

        // POST /api/Widget
        public IHttpActionResult Post([FromBody]Widget widget)
        {
            return Ok(string.Format("Sent {0} to {1}", widget.Message, widget.Recipient));
        }
    }

    public class Widget
    {
        public string Recipient { get; set; }
        public string Message { get; set; }
    }
}