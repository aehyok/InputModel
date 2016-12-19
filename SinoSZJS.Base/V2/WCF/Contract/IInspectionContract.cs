using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace SinoSZJS.Base.V2.WCF.Contract
{
    /// <summary>
    /// added by lqm 20161010 埃森哲  查验异常对接接口
    /// </summary>
    [ServiceContract]
    public interface IInspectionContract
    {
        /// <summary>
        /// 测试接口
        /// </summary>
        /// <param name="tokenString">访问令牌,对应访问机器的IP地址</param>
        /// <returns>返回字符串，内容为此令牌是否正确,信息为"访问令牌正确", 令牌错信息为"访问令牌错误"</returns>
        [OperationContract]
        string Echo(string tokenString);

        /// <summary>
        /// 发送查验数据，在办案平台中生成案件
        /// </summary>
        /// <param name="tokenString">访问令牌</param>
        /// <param name="caseData">查验平台数据</param>
        /// <returns>XML格式<Result>成功/失败</Result><ResultData>成为则为案件编号，失败则为失败消息</ResultData> </returns>
        [OperationContract]
        string SendCaseInfo(string tokenString, string caseData);
    }
}
