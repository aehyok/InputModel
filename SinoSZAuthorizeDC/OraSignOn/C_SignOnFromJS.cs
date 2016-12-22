using System;
using System.Diagnostics;
using SinoSZDataAccessBase;
using System.Data;
using SinoSZBizAuthorize;
using SinoSZBaseClass.Misc;

namespace SinoSZAuthorizeDC.OraSignOn
{
	/// <summary>
	/// ʹ�ü�˽�ۺ�ϵͳ������������������
	/// </summary>
	public class C_SignOnFromJS :C_SignOnBase
	{
		public C_SignOnFromJS()
		{
			//
			// TODO: �ڴ˴����ӹ��캯���߼�
			//
		}

                /// <summary>
                /// ��֤����
                /// </summary>
                /// <param name="_name"></param>
                /// <param name="_pass"></param>
                /// <returns></returns>
		override public bool Check(string _name,string _pass,string _type)
		{
			//1.��ȡ���ݿ��е��û���Ϣ����֤����
			string CheckStr = string.Format("SELECT count(*) FROM qx_tjyhb WHERE YHM='{0}' and KL='{1}' ",_name,MD5Base64.Encode(_pass));
                        decimal _ret = (decimal)OracleHelper.ExecuteScalar(OracleHelper.ConnectionStringProfile, CommandType.Text, CheckStr); 
                       
			return (_ret >0);
		}

                /// <summary>
                /// �޸Ŀ���
                /// </summary>
                /// <param name="_name"></param>
                /// <param name="_oldpass"></param>
                /// <param name="_newpass"></param>
                /// <returns></returns>
		override public int ChangePassword(string _name,string _oldpass,string _newpass,string _type) {
			//1.��ȡ���ݿ��е��û���Ϣ����֤����
			string CheckStr = string.Format("SELECT count(*) FROM qx_tjyhb WHERE YHM='{0}' and KL='{1}' ",_name,MD5Base64.Encode(_oldpass));
                        decimal _ret = (decimal)OracleHelper.ExecuteScalar(OracleHelper.ConnectionStringProfile, CommandType.Text, CheckStr); 
                       
			if (_ret<1) {
				return -1;
			}
			string Changepass = string.Format("Update qx_tjyhb set KL='{1}' where YHM='{0}'",_name,MD5Base64.Encode(_newpass));
			try {
                                OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, Changepass);
				
				return 1;
			}
			catch (Exception e) {
                                throw new Exception(string.Format("�޸Ŀ������:{0}", e.Message));   
				
			}
		}

                /// <summary>
                /// ���ÿ���
                /// </summary>
                /// <param name="_uname"></param>
                /// <param name="_pass"></param>
                /// <returns></returns>
		override public int ResetPass(string _uname, string _pass) {
			string Changepass = string.Format("Update qx_tjyhb set KL='{1}' where YHM='{0}'",_uname,MD5Base64.Encode(_pass));
			try {
                                OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, Changepass);
				
				return 1;
			}
			catch (Exception e) {
                                throw new Exception(string.Format("����������:{0}", e.Message));  
			}
		}
	}
}