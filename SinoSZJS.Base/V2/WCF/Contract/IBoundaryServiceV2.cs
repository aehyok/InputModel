using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using SinoSZJS.Base.V2.Document;

namespace SinoSZJS.Base.V2.WCF.Contract
{
    [ServiceContract]
    public interface IBoundaryServiceV2
    {
        [OperationContract]
        List<string> GetIdByStateId(List<string> actionIds);

        [OperationContract]
        List<DocList> GetMadeDocListByAction(string ajid, string actionId, string dwid);

        [OperationContract]
        string CreateModelId(List<string> data, string type);

        [OperationContract]
        bool OnExport(List<string> list);

        [OperationContract]
        List<DocList> GetMadeDocListByWsid(string wsid);

        [OperationContract]
        byte[] DownLoadPdf(string wsid);

        [OperationContract]
        string GetDocName(string wsid);
    }
}
