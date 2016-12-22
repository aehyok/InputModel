using System;

namespace SinoSZBaseClass.Misc
{
	/// <summary>
	/// MD5Base64 的摘要说明。
	/// </summary>
	public class MD5Base64
	{
		
		public static string Encode(string sourceString)
		{
                        //王立楠：取得sourceString的MD5 HashCode，再转换为base64 code，共24个字符。
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
