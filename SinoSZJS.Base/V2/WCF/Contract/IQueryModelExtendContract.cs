using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using SinoSZJS.Base.V2.MetaData.QueryModel;
using SinoSZJS.Base.V2.Authorize;

namespace SinoSZJS.Base.V2.WCF.Contract
{
    [ServiceContract]
    public interface IQueryModelExtendContract
    {
        [OperationContract]
        DataSet QueryData(MDModel_QueryModel queryModel, MDQuery_Request request, SinoRequestUser sinoRequestUser);

        /// <summary>
        /// 获取查询模型主表数据
        /// </summary>
        /// <param name="queryModel"></param>
        /// <param name="bzid"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [OperationContract]
        MDQueryResult_Table QueryMainTableDataByMainKey(MDModel_QueryModel queryModel, string bzid, SinoRequestUser user);

        [OperationContract]
        string GetMainTableKeyByColumnCondition(MDModel_QueryModel _queryModel, string _columnName, string _data);

        /// <summary>
        /// 根据子模型主键MainKey获取子模型数据
        /// </summary>
        /// <param name="queryModel"></param>
        /// <param name="tableId"></param>
        /// <param name="mainKey"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [OperationContract]
        DataTable QueryChildTableDataByMainKey(MDModel_QueryModel queryModel, string tableId, string mainKey, SinoRequestUser user);

        /// <summary>
        /// 获取子模型数据行数 根据子模型主键MainKey
        /// </summary>
        /// <param name="queryModel"></param>
        /// <param name="tableId"></param>
        /// <param name="mainKey"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [OperationContract]
        int QueryChildTableDataCountByMainKey(MDModel_QueryModel queryModel, string tableId, string mainKey, SinoRequestUser user);
    }
}
