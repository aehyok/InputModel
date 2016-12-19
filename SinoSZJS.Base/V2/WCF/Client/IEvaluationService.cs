using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using SinoSZJS.Base.V2.WCF.Contract;

namespace SinoSZJS.Base.V2.WCF.Client
{
    /// <summary>
    /// 刑事个案考评客户端接口 added by lqm 20160226
    /// </summary>
    public interface IEvaluationService:IEvaluationContract,IClientChannel
    {

    }
}
