using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;
using SinoSZJS.Base.Report;

namespace SinoSZJS.Base.V2.WCF.Contract
{
    [ServiceContract]
    public interface IReportServiceV2
    {
        [OperationContract]
        DataSet GetTempReportData(string dwdm, DateTime sdate, DateTime edate, string reportName, bool ishdy,
           decimal validity, out string errorMsg);

        [OperationContract]
        DataTable GetReportData_Old(string dwdm, DateTime sdate, DateTime edate, string reportName, bool ishdy);

        [OperationContract]
        DataSet QueryReportData(string dwdm, DateTime sdate, DateTime edate, string reportName, bool ishdy, out string errorMsg);

        [OperationContract]
        List<ReportWebItem> GetReportNameList(string dwdm, string tjnf, string tjyf, string reportNames, string bhxj);

        [OperationContract]
        byte[] GetRsReport(MD_ReportItem reportItem, string format);
    }
}
