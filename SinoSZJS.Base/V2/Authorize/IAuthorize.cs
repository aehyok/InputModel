using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinoSZJS.Base.V2.Authorize
{
    public interface IAuthorize
    {

        SinoUser LoginSys(string _sysid, string _name, string _pass, string CheckType);
        bool CheckPassword(string _uname, string _pass, string CheckType);
        bool ChangePassWord(string uname, string old_pass, string new_pass);

    }
}
