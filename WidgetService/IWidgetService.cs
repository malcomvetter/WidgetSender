using System.ServiceModel;
using System.ServiceModel.Web;

namespace WidgetService
{
    [ServiceContract]
    public interface IWidgetService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/SendWidget/{widget}",
            ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string SendWidget(Widget widget);
    }
}
