using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using SinoSZJS.Base.V2.Document;
using SinoSZJS.Base.V2.InputModel;

namespace SinoSZJS.Base.V2.WCF.Contract
{
     [ServiceContract]
    public interface IAuxiliaryServiceV2
    {
        [OperationContract]
        int AuxiliaryListPassOrDelete(string id, string state, string actionTableName);

        [OperationContract]
        bool AuxiliaryIsExist(string caseId, string selectTableName);

        [OperationContract]
        bool OnUnityDelete(string id, string typeName);

        [OperationContract]
        string GetTypeById(string id);

        [OperationContract]
        string GetCaseId(string id, string actionName);

        [OperationContract]
        bool HandleById(string id, string typeName);

        [OperationContract]
        bool ActionNameUpdate(MD_InputEntity entity,string bzid);

        [OperationContract]
        bool ActionNameDelete(string bzid);

        [OperationContract]
        bool ProjectNameUpdate(MD_InputEntity entity, string bzid);

        [OperationContract]
        bool ProjectNameDelete(string bzid);
    }
}
