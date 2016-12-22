using System;

namespace SinoSZBaseClass.Misc
{
	/// <summary>
	/// MD5Base64 ��ժҪ˵����
	/// </summary>
	public class MD5Base64
	{
		
		public static string Encode(string sourceString)
		{
                        //����骣�ȡ��sourceString��MD5 HashCode����ת��Ϊbase64 code����24���ַ���
			char[] chars = sourceString.ToCharArray();
			int count = chars.Length;
			byte[] bytes = new byte[count];
			for(int i=0;i<count;i++)
			{
				bytes[i] = (byte)chars[i];
			}
			System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
			md5.ComputeHash(bytes);
			return Convert.ToBase64String(md5.Hash);
		}
		
	}
}
