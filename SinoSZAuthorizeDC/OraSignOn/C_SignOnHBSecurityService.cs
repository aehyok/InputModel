using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using SinoSZBizAuthorize;
using SinoSZDataAccessBase;

namespace SinoSZAuthorizeDC.OraSignOn
{

	public class C_SignOnHBSecurityService : C_SignOnBase
	{
		#region �����ַ
		public static string serviceUrl = "";
		public static string ServiceURL
		{
			get
			{
				if (serviceUrl == "")
				{
					try
					{
						serviceUrl = ConfigurationSettings.AppSettings["SecurityCheckURL"];
					}
					catch
					{
						serviceUrl = "http://10.73.2.207/AppAdmin/Exports/AppSecurityCheckService.asmx";
					}
				}

				return serviceUrl;
			}
		}
		#endregion

		/// <summary>
		/// ��֤����
		/// </summary>
		/// <param name="_name"></param>
		/// <param name="_pass"></param>
		/// <returns></returns>
		override public bool Check(string _name, string _pass,string _type)
		{
			
			bool _ret = false;
			HBSecurityCheckService.AppSecurityCheckService _wsobj = new HBSecurityCheckService.AppSecurityCheckService();
			if (ServiceURL == "")
			{
				_wsobj.Url = "http://10.73.2.207/AppAdmin/Exports/AppSecurityCheckService.asmx";
			}
			else
			{
				_wsobj.Url = ServiceURL;
			}
			_wsobj.Timeout = 60000;

			for (int i = 0; i < 3; i++)
			{
				try
				{
					return _wsobj.SignInCheck(_name, _pass);
				}
				catch (Exception e)
				{
					string _errmsg = string.Format("����HB2004��AppSecurityCheckService�����û������֤ʱ����,������ϢΪ:{0}!\n name:{1}\n_pass:{2}\n",
						e.Message, _name, _pass);
					OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
				}
			}
			return _ret;
		}


	}
}
