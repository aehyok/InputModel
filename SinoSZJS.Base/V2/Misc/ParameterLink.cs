using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SinoSZJS.Base.V2.Misc
{
    public class ParameterLink
    {
        /// <summary>
        /// 链接单元格的参数替换
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <param name="rowValue"></param>
        /// <returns></returns>
        public static string ReplaceVerRow(string data, string type, string name, object rowValue)
        {
            string value = string.Empty;
            if (rowValue != null)
            {
                if (type == "日期型")
                {
                    if (rowValue is DateTime)
                        value = ((DateTime)rowValue).ToString("yyyyMMddHHmmss");
                    else if (rowValue is string)
                    {
                        value = StrUtils.String2Date(rowValue.ToString()).ToString("yyyyMMddHHmmss");
                    }
                    else
                        value = DateTime.MinValue.ToString("yyyyMMddHHmmss");
                }
                else
                    value = rowValue.ToString();
            }
            return value;
        }

        /// <summary>
        /// 链接单元格的参数替换
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string ReplaceVerColumn(string data, Dictionary<string, object> dictionary, string type, string name)
        {
            //**表示从当前指标参数中取值
            if (Regex.IsMatch(data, "\\*.{1,}\\*"))
            {
                string value = "";
                string verName0 = data.Substring(1, data.Length - 2);
                if (dictionary.ContainsKey(verName0))
                {
                    if (type == "日期型")
                    {
                        if (dictionary[verName0] is DateTime)
                            value = ((DateTime)dictionary[verName0]).ToString("yyyyMMddHHmmss");
                        else if (dictionary[verName0] is string)
                        {
                            value = StrUtils.String2Date(dictionary[verName0].ToString()).ToString("yyyyMMddHHmmss");
                        }
                        else
                            value = DateTime.MinValue.ToString("yyyyMMddHHmmss");
                    }
                    else
                        value = dictionary[verName0].ToString();
                }
                return value;
            }

            //类型为日期型，需替换掉“#当年#”，“#当月#”，“#当日#”
            if (type == "日期型")
            {
                string date = DateTime.Now.ToString("yyyy-MM-dd");
                data = data.Replace("#当年#", date.Substring(0, 4));
                data = data.Replace("#当月#", date.Substring(5, 2));
                data = data.Replace("#当日#", date.Substring(8, 2));
                return data;
            }
            return data;
        }
    }
}
