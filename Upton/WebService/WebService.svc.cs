using System.ServiceModel;

namespace WebService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, IncludeExceptionDetailInFaults = true)]
    public class WebService : IWebService
    {
        public string ProcessPage()
        {
            byte[] binary = OperationContext.Current.RequestContext.RequestMessage.GetBody<byte[]>();
            string requestBody = System.Text.Encoding.UTF8.GetString(binary);
            BrowserRequest request = Newtonsoft.Json.JsonConvert.DeserializeObject<BrowserRequest>(requestBody);

            // TODO: Do something meaningful here.
            return $"You sent: {request.address} \n\n {request.content.Substring(0, 100)}";
        }
    }
}
