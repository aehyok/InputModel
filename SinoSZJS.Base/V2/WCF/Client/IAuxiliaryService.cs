using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using SinoSZJS.Base.V2.WCF.Contract;

namespace SinoSZJS.Base.V2.WCF.Client
{
    public interface IAuxiliaryService:IAuxiliaryServiceV2, IClientChannel
    {
    }
}
