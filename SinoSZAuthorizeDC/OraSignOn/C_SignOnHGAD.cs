using System;
using System.Collections.Generic;
using System.Text;
using SinoSZBizAuthorize;
using System.Data;
using System.DirectoryServices;
using System.Configuration;
using SinoSZJS.DataAccess.Sql;

namespace SinoSZAuthorizeDC.OraSignOn
{
	public class C_SignOnHGAD : C_SignOnBase
	{
		private static string p_LDAPPath = "";
		private static string p_DomainName = "";
		private static string LDAP_Path
		{
			get
			{
				if (p_LDAPPath == "")
				{
					p_LDAPPath = ConfigurationManager.AppSettings["LDAP_Path"].ToUpper();
				}
				return p_LDAPPath;
			}
		}

		private static string Domain_Name
		{
			get
			{
				if (p_DomainName == "")
				{
					p_DomainName = ConfigurationManager.AppSettings["DomainName"].ToUpper();
				}
				return p_DomainName;
			}
		}


		public C_SignOnHGAD()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 验证口令
		/// </summary>
		/// <param name="_name"></param>
		/// <param name="_pass"></param>
		/// <returns></returns>
		override public bool Check(string _name, string _pass,string _type)
		{
			//1.读取数据库中的用户信息，验证密码
			try
			{
				string _userName = string.Format("{0}\\{1}", Domain_Name, _name);
                using (DirectoryEntry dir = new DirectoryEntry(LDAP_Path, _userName, _pass))
                {

                    object adobj = dir.NativeObject;
                    return true;
                }
			}
			catch (Exception e1)
			{
                LogWriter.WriteSystemLog(string.Format("验证口令出错:{0}\n Name={1} Pass={2}", e1.Message, _name, _pass), "ERROR");
				return false;
			}
		}

		/// <summary>
		/// 修改口令
		/// </summary>
		/// <param name="_name"></param>
		/// <param name="_oldpass"></param>
		/// <param name="_newpass"></param>
		/// <returns></returns>
		override public int ChangePassword(string _name, string _oldpass, string _newpass,string _type)
		{

			return -1;

		}

		/// <summary>
		/// 重置口令
		/// </summary>
		/// <param name="_uname"></param>
		/// <param name="_pass"></param>
		/// <returns></returns>
		override public int ResetPass(string _uname, string _pass)
		{
			return -1;
		}
	}
}
