using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using SinoSZJS.Base.V2.Authorize;

namespace SinoSZJS.Base.V2.WCF.Contract
{
    /// <summary>
    /// 刑事考评 added lqm 20160226
    /// </summary>
    [ServiceContract]
    public interface IEvaluationContract
    {
        [OperationContract]
        bool CriminalWaitApprovalPass(string ajid);

        [OperationContract]
        byte[] GradeItemSave(string level,string bzid, List<string> itemList, string type,SinoRequestUser user);

        [OperationContract]
        string GetAjidByKpid(string kpid);

        [OperationContract]
        string GetKpidByAjid(string ajid);

        [OperationContract]
        OperationResult DeleteExamine(string kpid);

        [OperationContract]
        OperationResult DeleteYearExamine(string kpid,string level);

        [OperationContract]
        string GetMaxYear(string dwid,string level);

        [OperationContract]
        bool SetYear(string kpid, string year);

        [OperationContract]
        string GetAnnualExamineByDwid(string dwid,string year, string level);

        [OperationContract]
        string GetAnnualState(string bzid);

        [OperationContract]
        OperationResult UpdateExamineType(string bzid, string type,string annual,string bjAmount,string kpAmount);

        [OperationContract]
        string GetYearByTqid(string tqid);
    }
}
