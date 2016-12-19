﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace SinoSZJS.Base.V2.Misc
{
    public static class DataConverter
    {
        public static TValue GetValue<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue = default(TValue))
        {
            TValue result;
            if (dictionary.TryGetValue(key, out result) == false)
                result = defaultValue;
            return result;
        }

        /// <summary>
        /// 数据转换为XML
        /// </summary>
        /// <param name="_dic"></param>
        /// <returns></returns>
        public static string DictionaryToXML(this Dictionary<string, string> dictionary)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (dictionary.Count > 0)
            {
                foreach (string st in dictionary.Keys)
                {
                    stringBuilder.Append("<" + st + ">");
                    stringBuilder.Append(dictionary[st]);
                    stringBuilder.AppendLine("</" + st + ">");
                }
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// XML转为Dictionary<string,object>
        /// </summary>
        /// <param name="pstr"></param>
        /// <returns></returns>
        public static Dictionary<string, string> ChangeXMLToDictionary(string pstr)
        {
            int index, start, end, em_start;
            string mark, endmark;
            Dictionary<string, string> _ret = new Dictionary<string, string>();
            index = 0;
            if (pstr != null)
            {
                while (index < pstr.Length)
                {
                    start = pstr.IndexOf('<', index);
                    if (start >= 0)
                    {
                        end = pstr.IndexOf('>', start);
                        if (end >= 0)
                        {
                            mark = pstr.Substring(start + 1, end - start - 1);
                            endmark = string.Format("</{0}>", mark);
                            em_start = pstr.IndexOf(endmark, end + 1);
                            if (em_start >= 0)
                            {
                                string value = pstr.Substring(end + 1, em_start - end - 1);
                                _ret.Add(mark, value);
                                index = end + endmark.Length + 1;
                            }
                            else
                            {
                                index = end + 1;
                            }
                        }
                        else
                        {
                            index = start + 1;
                        }
                    }
                    else
                    {
                        index = pstr.Length + 1;
                    }
                }
            }
            return _ret;
        }

        /// <summary>
        /// DataTable转换为XML
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DataTableToXml(this DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb);
            XmlSerializer serializer = new XmlSerializer(typeof(DataTable));
            serializer.Serialize(writer, dt);
            writer.Close();
            return sb.ToString();
        }

        /// <summary>
        /// DataSet转换为XML
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static string DataSetToXml(this DataSet ds)
        {
            StringBuilder sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb);
            XmlSerializer serializer = new XmlSerializer(typeof(DataSet));
            serializer.Serialize(writer, ds);
            writer.Close();
            return sb.ToString();
        }
        /// <summary>
        /// 将XML字符串转换为StreamReader
        /// </summary>
        /// <param name="xmlStr"></param>
        /// <returns></returns>
        public static StreamReader GetStream(this string xmlStr)
        {
            byte[] tempByte = Encoding.UTF8.GetBytes(xmlStr);
            MemoryStream stream = new MemoryStream(tempByte);
            //stream.Position = 0;
            StreamReader streamReader = new StreamReader(stream);
            return streamReader;
        }

        /// <summary>
        /// 将XML字符串转换为DataTable并将XML中的数据填充到DataTable
        /// </summary>
        /// <param name="StrData"></param>
        /// <returns></returns>
        public static DataSet XMLToDataSet(this string StrData)
        {
            if (!string.IsNullOrEmpty(StrData))
            {
                XmlDocument xmlDoc = new XmlDocument();
                DataSet ds = new DataSet();
                try
                {
                    xmlDoc.LoadXml(StrData);
                    ds.ReadXml(GetStream(xmlDoc.OuterXml));
                    return ds;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 将XML转换为DataTable
        /// </summary>
        /// <param name="StrData"></param>
        /// <returns></returns>
        public static DataTable XMLToDataTable(this string StrData)
        {
            if (!string.IsNullOrEmpty(StrData))
            {
                XmlDocument xmlDoc = new XmlDocument();
                DataTable ds = new DataTable("ResultTable");
                try
                {
                    xmlDoc.LoadXml(StrData);
                    XmlSerializer serializer = new XmlSerializer(typeof(DataTable));
                    ds = (DataTable)serializer.Deserialize(GetStream(xmlDoc.InnerXml));

                    return ds;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                return null;
            }
        }

        #region 序列化
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static string Serializer(Type type, object obj)
        {
            MemoryStream Stream = new MemoryStream();
            XmlSerializer xml = new XmlSerializer(type);
            try
            {
                //序列化对象
                xml.Serialize(Stream, obj);
            }
            catch
            {
                throw;
            }
            Stream.Position = 0;
            StreamReader sr = new StreamReader(Stream);
            string str = sr.ReadToEnd();

            sr.Dispose();
            Stream.Dispose();

            return str;
        }
        #endregion

        #region 反序列化
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="xml">XML字符串</param>
        /// <returns></returns>
        public static object Deserialize(Type type, string xml)
        {
            try
            {
                using (StringReader sr = new StringReader(xml))
                {
                    XmlSerializer xmldes = new XmlSerializer(type);
                    return xmldes.Deserialize(sr);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

    }
}
