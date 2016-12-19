using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using SinoSZJS.Base.V2.InputModel;

namespace SinoSZJS.Base.V2.WCF.Contract
{
    [ServiceContract]
    public interface IOnlineInspectionServiceV2
    {
        [OperationContract]
        string IsReasonable(string ajbh);

        [OperationContract]
        string GetCaseName(string ajbh);

        [OperationContract]
        string GetCaseType(string ajid);

        [OperationContract]
        string GetUserLevel(string dwid);

        [OperationContract]
        string GetAjid(string id);

        [OperationContract]
        string GetTableNameById(string id);

        [OperationContract]
        List<string> GetNeedReplaceBH(string userid);

        [OperationContract]
        List<string> GetDoubleInspectionDoing(string userid);

        [OperationContract]
        List<string> GetDoubleInspectionPending(string userid);

        [OperationContract]
        List<string> GetInspectorDisposalDoing(string userid);

        [OperationContract]
        List<string> GetCaseMessege(string ajbh);

        [OperationContract]
        List<string> GetDMMC(List<string> list, string targetTable);

        [OperationContract]
        bool DeleteEvidence(string id);

        [OperationContract]
        bool DeleteDisposalObject(string id);

        [OperationContract]
        bool DeleteDisposalDetail(string id);

        [OperationContract]
        string Check(MD_InputEntity entity);
    }
}
