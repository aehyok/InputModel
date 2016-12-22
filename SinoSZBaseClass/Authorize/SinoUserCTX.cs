using System;

namespace SinoSZBaseClass.Authorize
{      
	/// <summary>
	/// SinoUserCtx
	/// ����Remoting�� UserCtx��Ϣ
	/// </summary>
	public class SinoUserCtx
	{
                private static IUserInfoCTX userInfoCTX = new RemotingUserCTX();

		/// <summary>
		/// ��ȡ��ǰ�û����û�ID��
		/// </summary>
		public static SinoUser CurUser
		{
                        get { return UserInfoCTX.GetCurrentUser(); }
		}

               /// <summary>
               /// �û���Ϣ�ӿ�
               /// </summary>
                public static IUserInfoCTX UserInfoCTX
                {
                        get { return userInfoCTX; }
                        set { userInfoCTX = value; }
                }
                

	}
}