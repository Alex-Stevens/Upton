using System.ServiceModel;
using System.ServiceModel.Web;

namespace WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWebService" in both code and config file together.
    [ServiceContract]
    public interface IWebService
    {
        [OperationContract()]
        [WebInvoke(UriTemplate = "/ProcessPage", ResponseFormat = WebMessageFormat.Json)]
        string ProcessPage();
    }
}
