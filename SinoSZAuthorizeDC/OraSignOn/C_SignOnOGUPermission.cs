using System;
using System.Collections.Generic;
using System.Text;
using SinoSZBizAuthorize;
using System.Net;
using System.IO;

namespace SinoSZAuthorizeDC.OraSignOn
{
        public class C_SignOnOGUPermission : C_SignOnBase
        {
                /// <summary>
                /// 验证口令
                /// </summary>
                /// <param name="_name"></param>
                /// <param name="_pass"></param>
                /// <returns></returns>
                override public bool Check(string _name, string _pass,string _type)
                {                     
                        ASCIIEncoding encoding = new ASCIIEncoding();
                        string postData = "username=" + _name;
                        postData += ("&password=" + _pass);
                       
                        byte[] data = encoding.GetBytes(postData);
                        // Prepare web request...
                        HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create("http://www.csharpcn.com/login.aspx");
                        myRequest.Method = "POST";
                        myRequest.ContentType = "application/x-www-form-urlencoded";
                        myRequest.ContentLength = data.Length;
                        Stream newStream = myRequest.GetRequestStream();
                        // Send the data.
                        newStream.Write(data, 0, data.Length);
                        newStream.Close();
                        // Get response
                        HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                        StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                        string content = reader.ReadToEnd();
                        //Response.Write(content); 
                        // textBox1.Text = content;
                        if (myResponse.StatusCode == HttpStatusCode.OK)
                        {
                                return true;
                        }
                        else
                        {
                                return false;
                        }
                }

        }
}
