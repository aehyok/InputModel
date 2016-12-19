using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace SinoSZJS.Base.V2.WCF.Contract
{
	[ServiceContract]
	public interface IJS4InspectionService
	{
		/// <summary>
		/// 测试接口
		/// </summary>
		/// <param name="TokenString">访问令牌,对应访问机器的IP地址</param>
		/// <returns>返回字符串，内容为此令牌是否正确,信息为"访问令牌正确", 令牌错信息为"访问令牌错误"</returns>
		[OperationContract]
		string Echo(string TokenString);
 
		/// <summary>
		/// 发送查验数据，在办案平台中生成案件
		/// </summary>
		/// <param name="TokenString">访问令牌</param>
		/// <param name="CaseData">查验平台数据JSON格式</param>
		/// <returns>XML格式<Result>成功/失败</Result><ResultData>成为则为案件编号，失败则为失败消息</ResultData> </returns>
		[OperationContract]
		string SendCaseInfo(string TokenString, string CaseData);

		/// <summary>
		/// 发送查验数据，在办案平台中生成线索
		/// </summary>
		/// <param name="TokenString">访问令牌</param>
		/// <param name="ClueData">查验平台数据JSON格式</param>
		/// <returns></returns>
		[OperationContract]
		string SendClueInfo(string TokenString, string ClueData);


		/// <summary>
		/// 从办案平台获取案件的行政处罚决定书PDF
		/// </summary>
		/// <param name="TokenString">访问令牌</param>
		/// <param name="CaseNum">案件编号</param>
		/// <param name="FileType">文件类型</param>
		/// <returns>文书字节组数</returns>
		[OperationContract]
		byte[] GetPunishmentDocument(string TokenString, string CaseNum, string FileType);
	}
}
