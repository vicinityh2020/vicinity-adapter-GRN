using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace VicinityWCF
{
    [ServiceContract]
    public interface IVicinityWCFService
    {
        #region Consumption - /objects

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "objects")]
        Stream SM_Objects_GET();

        #endregion


        #region Consumption - /objects/{oid}/properties/{pid}

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "objects/{oid}/properties/{pid}")]
        Stream SM_Objects_Properties_GET(string oid, string pid);

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "objects/{oid}/properties/{pid}")]
        Stream SM_Objects_Properties_PUT(string oid, string pid);

        #endregion


        #region Consumption - /objects/{oid}/actions/{aid}

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "objects/{oid}/actions/{aid}")]
        Stream SM_Objects_Actions_GET(string oid, string aid);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "objects/{oid}/actions/{aid}")]
        Stream SM_Objects_Actions_POST(string oid, string aid);

        #endregion

    }
}
