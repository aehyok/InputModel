using System;
using System.Collections.Generic;
using System.Text;
using SinoSZBaseClass.Authorize;

namespace SinoSZAuthorizeDC
{
        /// <summary>
        /// SQL Server 数据库的认证接口实现
        /// </summary>
        public class SqlAuthorizeFactroy: IAuthorize
        {
                #region IAuthorize Members

                public SinoUser LoginSys(string _sysid, string _name, string _pass,string _type)
                {
                        throw new Exception("The method or operation is not implemented.");
                }

                public bool ChangePassWord(string uname, string old_pass, string new_pass,string _type)
                {
                        throw new Exception("The method or operation is not implemented.");
                }

                public List<SinoOrganize> GetRootDwList(string _rootDwid,decimal _levelNum)
                {
                        throw new Exception("The method or operation is not implemented.");
                }
                #endregion



                #region IAuthorize Members


                public SinoSZBaseClass.Config.ServerConfig GetServerConfig()
                {
                        throw new Exception("The method or operation is not implemented.");
                }

                #endregion

                #region IAuthorize Members


                public bool CheckPassword(string _uname, string old_pass,string _type)
                {
                        throw new Exception("The method or operation is not implemented.");
                }

                #endregion

                #region IAuthorize Members


                public decimal GetDWIDByDWDM(string _dwdm)
                {
                        throw new Exception("The method or operation is not implemented.");
                }

                #endregion

		#region IAuthorize Members


		public List<SinoOrganize> GetRootDwListEx(string _rootDwid, decimal _levelNum, string _type)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		#endregion

                #region IAuthorize Members


                public void WriteExportLog(int _exportRowCount, string ExportDataMsg)
                {
                        throw new Exception("The method or operation is not implemented.");
                }

                #endregion
        }
}
