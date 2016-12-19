using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using SinoSZJS.Base.V2.Authorize;

namespace SinoSZJS.Base.V2.WCF.Contract
{
    /// <summary>
    /// added by lqm 20160406
    /// 指标获取数据的接口
    /// </summary>
    [ServiceContract]
    public interface IGuideLineContract
    {
        /// <summary>
        /// 获取指标结果集记录数
        /// </summary>
        /// <param name="guideLineId"></param>
        /// <param name="param"></param>
        /// <param name="filterWord"></param>
        /// <param name="requestUser"></param>
        /// <returns></returns>
        [OperationContract]
        int GetQueryResultCount(string guideLineId, Dictionary<string, object> param, string filterWord, SinoRequestUser requestUser);

        /// <summary>
        /// 获取过滤后的指标结果集
        /// </summary>
        /// <param name="guideLineId"></param>
        /// <param name="param"></param>
        /// <param name="filterWord"></param>
        /// <param name="requestUser"></param>
        /// <returns></returns>
        [OperationContract]
        DataTable QueryGuideline(string guideLineId, Dictionary<string, object> param, string filterWord, SinoRequestUser requestUser);


        /// <summary>
        /// 分页查询指标结果集
        /// </summary>
        /// <param name="guideLineId"></param>
        /// <param name="param"></param>
        /// <param name="filterWord"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortBy"></param>
        /// <param name="sortDirection"></param>
        /// <param name="requestUser"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        [OperationContract]
        DataTable QueryGuidelineByPaging(string guideLineId, Dictionary<string, object> param, string filterWord, decimal pageIndex, decimal pageSize, string sortBy, string sortDirection, SinoRequestUser requestUser, ref int recordCount);
    }
}
