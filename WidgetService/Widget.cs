using System.Runtime.Serialization;

namespace WidgetService
{
    [DataContract]
    public class Widget
    {
        public string Recipient { get; set; }
        public string Message { get; set; }
    }
}
