using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class SendWidgetModel
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "To Email")]
        public string toEmail { get; set; }
        public string fromEmail { get; set; }
        [Display(Name = "Message")]
        [AllowHtml]
        public string widgetMessage { get; set; }
    }
}