using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using SinoSZJS.Base.Report;
using SinoSZJS.Base.V2.Document;
using SinoSZJS.Base.V2.InputModel;

namespace SinoSZJS.Base.V2.WCF.Contract
{
     [ServiceContract]
    public interface IThreadContract
     {
         [OperationContract]
         DataTable GetStatis_DWBM(string dwid, DateTime sdate, DateTime edate, string sort);

         [OperationContract]
         DataTable GetStatis_YWSX(DateTime sdate, DateTime edate, string sort);
     }
}
