using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.Authorize
{
        public class LogonUserLib
        {
                public static Dictionary<string, SinoUser> _users = new Dictionary<string, SinoUser>();

                public static SinoUser GetUserInfo(string _userName)
                {
                        return _users[_userName];
                }

                public static bool AddUserInfo(string _userName,SinoUser _su)
                {
                        if (_users.ContainsKey(_userName))
                        {
                                //如果用户已经登录
                                _users[_userName] = _su;
                        }
                        else
                        {
                                _users.Add(_userName, _su);
                        }

                        return true;
                        
                }

                public static bool RemoveUserInfo(string _userName)
                {
                        if (_users.ContainsKey(_userName))
                        {
                                _users.Remove(_userName);
                        }

                        return true;
                }

        }
}
