using System;

namespace WidgetService
{
    public class WidgetService : IWidgetService
    {
        public string SendWidget(Widget widget)
        {
            return string.Format("Sent {0} to {1}", widget.Message, widget.Recipient);
        }
    }
}
