using System;
using System.Collections;
using System.Xml;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Text;
using System.Collections.Generic;

namespace SinoSZBaseClass.Misc
{
        /// <summary>
        /// Summary description for StrUtils.
        /// </summary>
        public class StrUtils
        {
                public static int GetLengthChinese2(string _s)
                {
                        int _ret = 0;
                        foreach (char c in _s)
                        {
                                if (char.GetUnicodeCategory(c) == UnicodeCategory.OtherLetter)
                                {
                                        _ret += 2;
                                }
                                else if (c == '��' || c == '��')
                                {
                                        _ret += 2;
                                }
                                else
                                {
                                        _ret += 1;
                                }
                        }
                        return _ret;
                }

                public static string GetLeftStringChinese2(string _s, int _length)
                {
                        int _ret = 0;
                        string _res = "";
                        foreach (char c in _s)
                        {
                                if (char.GetUnicodeCategory(c) == UnicodeCategory.OtherLetter)
                                {
                                        _ret += 2;
                                }
                                else if (c == '��' || c == '��')
                                {
                                        _ret += 2;
                                }
                                else
                                {
                                        _ret += 1;
                                }
                                if (_ret > _length) return _res;
                                _res += c;
                                if (_ret == _length) return _res;
                        }
                        return _res;
                }

                public static string PaddingRightChinese2(string _s, int _length, char _blankChar)
                {
                        int _srcLength = GetLengthChinese2(_s);
                        if (_srcLength == _length) return _s;
                        if (_srcLength > _length)
                        {
                                string _newString = GetLeftStringChinese2(_s, _length);
                                if (GetLengthChinese2(_newString) < _length)
                                {
                                        return _newString + _blankChar;
                                }
                                else
                                {
                                        return _newString;
                                }
                        }
                        if (_srcLength < _length)
                        {
                                int _needNum = _length - _srcLength;
                                return _s + "".PadRight(_needNum, _blankChar);
                        }
                        return _s;
                }
                /// <summary>
                /// ȷ���ַ�����ָ�����ַ����ַ�����β(����������Զ����)
                /// </summary>
                /// <param name="str"></param>
                /// <param name="suffix"></param>
                /// <returns></returns>
                public static string EnsureEndsWith(ref string str, char suffix)
                {
                        string suffixStr = new string(suffix, 1);
                        if (!str.EndsWith(suffixStr))
                                str += suffixStr;
                        return str;
                }

                public static string EnsureEndsWith(ref string str, string suffix)
                {
                        if (!str.EndsWith(suffix))
                                str += suffix;
                        return str;
                }

                /// <summary>
                /// ׷���ַ����������ʵ�����Ӷ���
                /// </summary>
                /// <param name="dest">Ŀ���ַ���</param>
                /// <param name="src">Ҫ��ӵ��ַ���</param>
                /// <returns></returns>
                public static string AddByComma(ref string dest, string src)
                {
                        return AddBySeperator(ref dest, src, ",", true);
                }

                public static string AddByComma(ref string dest, string src, bool addSpace)
                {
                        return AddBySeperator(ref dest, src, ",", addSpace);
                }


                /// <summary>
                /// ׷���ַ����������ʵ�����ӷָ���
                /// </summary>
                /// <param name="dest">Ŀ���ַ���</param>
                /// <param name="src">Ҫ��ӵ��ַ���</param>
                /// <param name="seperator">�ָ���</param>
                /// <returns></returns>
                public static string AddBySeperator(ref string dest, string src, string seperator)
                {
                        return AddBySeperator(ref dest, src, seperator, false);
                }

                /// <summary>
                /// ׷���ַ����������ʵ�����ӷָ����Ϳո�
                /// </summary>
                /// <param name="dest">Ŀ���ַ���</param>
                /// <param name="src">Ҫ��ӵ��ַ���</param>
                /// <param name="seperator">�ָ���</param>
                /// <param name="addSpace">�Ƿ���ӿո�</param>
                /// <returns></returns>
                public static string AddBySeperator(ref string dest, string src, string seperator, bool addSpace)
                {
                        if (dest == string.Empty)
                                dest = src;
                        else
                        {
                                if (addSpace)
                                        dest += seperator + " " + src;
                                else
                                        dest += seperator + src;
                        }
                        return dest;
                }


                /// <summary>
                /// �ж��ַ����Ƿ�������
                /// </summary>
                /// <param name="s"></param>
                /// <returns></returns>
                public static bool IsDigit(string s)
                {
                        Char[] chars = s.ToCharArray();
                        foreach (char c in chars)
                        {
                                if (!Char.IsDigit(c))
                                        return false;
                        }
                        return true;
                }

                /// <summary>
                /// ��XML�ַ�����ȡָ�������ƶε�����
                /// </summary>
                /// <param name="_name">����</param>
                /// <param name="_meta">XML�ַ���</param>
                /// <returns></returns>
                public static string GetMetaByName(string _name, string _meta)
                {
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(string.Format("<XmlText>{0}</XmlText>", _meta));

                        XmlNodeList elemList = doc.GetElementsByTagName(_name);
                        for (int i = 0; i < elemList.Count; i++)
                        {
                                string _s2 = elemList[i].InnerXml;
                                return _s2;

                        }

                        return "";
                }

                public static string GetMetaByName2(string _name, string _meta)
                {
                        RegexOptions options = RegexOptions.None;
                        string _regStr = "<" + _name + @">[^<]{1,}</" + _name + ">";
                        Regex regeMeta = new Regex(_regStr, options);
                        int _TagLength = _name.Length;
                        MatchCollection _mc = regeMeta.Matches(_meta);
                        foreach (Match _m in _mc)
                        {
                                string _s2 = _m.Value.Substring(_TagLength + 2, _m.Length - (_TagLength + 2) * 2 - 1);
                                return _s2;
                        }
                        return "";
                }

                /// <summary>
                /// ��XML�ַ�����ȡָ�������ƶε������б�
                /// </summary>
                /// <param name="_name">������</param>
                /// <param name="_meta">XML�ַ���</param>
                /// <returns></returns>
                public static ArrayList GetMetasByName(string _name, string _meta)
                {
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(string.Format("<XmlText>{0}</XmlText>", _meta));
                        ArrayList _res = new ArrayList();
                        XmlNodeList elemList = doc.GetElementsByTagName(_name);
                        for (int i = 0; i < elemList.Count; i++)
                        {
                                string _s2 = elemList[i].InnerXml;
                                _res.Add(_s2);
                        }

                        return _res;
                }

                public static ArrayList GetMetasByName2(string _name, string _meta)
                {
                        ArrayList _res = new ArrayList();

                        RegexOptions options = RegexOptions.None;
                        string _regStr = "<" + _name + @">[^<]{1,}</" + _name + ">";
                        Regex regeMeta = new Regex(_regStr, options);
                        int _TagLength = _name.Length;
                        MatchCollection _mc = regeMeta.Matches(_meta);
                        foreach (Match _m in _mc)
                        {
                                string _s2 = _m.Value.Substring(_TagLength + 2, _m.Length - (_TagLength + 2) * 2 - 1);
                                _res.Add(_s2);
                        }

                        return _res;
                }

                /// <summary>
                /// ȫ��ת���ɰ��
                /// </summary>
                /// <param name="_s"></param>
                /// <returns></returns>
                static public string ConvertToNarrow(string input)
                {
                        char[] c = input.ToCharArray();
                        for (int i = 0; i < c.Length; i++)
                        {
                                if (c[i] == 12288)
                                {
                                        c[i] = (char)32;
                                        continue;
                                }

                                if (c[i] > 65280 && c[i] < 65375)
                                        c[i] = (char)(c[i] - 65248);
                        }
                        return new string(c);
                }

                /// <summary>
                /// ���ת��Ϊȫ��
                /// </summary>
                /// <param name="_s"></param>
                /// <returns></returns>
                static public string ConvertToWide(string input)
                {
                        char[] c = input.ToCharArray();
                        for (int i = 0; i < c.Length; i++)
                        {
                                if (c[i] == 32)
                                {
                                        c[i] = (char)12288;
                                        continue;
                                }

                                if (c[i] < 127)
                                        c[i] = (char)(c[i] + 65248);
                        }
                        return new string(c);
                }

                /// <summary> 
                /// ���Сд���д 
                /// </summary> 
                /// <param name="smallnum"></param> 
                /// <returns></returns> 
                public static string ConvertToChineseMoney(decimal smallnum)
                {
                        string cmoney, cnumber, cnum, cnum_end, cmon, cno, snum, sno;
                        int snum_len, sint_len, cbegin, zflag, i;
                        if (smallnum > 1000000000000 || smallnum < -99999999999 || smallnum == 0)
                                return "";
                        cmoney = "Ǫ��ʰ��Ǫ��ʰ��Ǫ��ʰԪ�Ƿ�";// ��д����ҵ�λ�ַ��� 
                        cnumber = "Ҽ��������½��ƾ�";// ��д�����ַ��� 
                        cnum = "";// ת����Ĵ�д�����ַ��� 
                        cnum_end = "";// ת����Ĵ�д�����ַ��������һλ 
                        cmon = "";// ȡ��д����ҵ�λ�ַ����е�ĳһλ 
                        cno = "";// ȡ��д�����ַ����е�ĳһλ 

                        snum = System.Math.Round(smallnum, 2).ToString("############.00"); ;// Сд�����ַ��� 
                        snum_len = snum.Length;// Сд�����ַ����ĳ��� 
                        sint_len = snum_len - 2;// Сд�������������ַ����ĳ��� 
                        sno = "";// Сд�����ַ����е�ĳ�������ַ� 
                        cbegin = 15 - snum_len;// ��д����ҵ�λ�еĺ���λ�� 
                        zflag = 1;// Сд�����ַ��Ƿ�Ϊ0(0=0)���жϱ�־ 
                        i = 0;// Сд�����ַ����������ַ���λ�� 

                        if (snum_len > 15)
                                return "";
                        for (i = 0; i < snum_len; i++)
                        {
                                if (i == sint_len - 1)
                                        continue;

                                cmon = cmoney.Substring(cbegin, 1);
                                cbegin = cbegin + 1;
                                sno = snum.Substring(i, 1);
                                if (sno == "-")
                                {
                                        cnum = cnum + "��";
                                        continue;
                                }
                                else if (sno == "0")
                                {
                                        cnum_end = cnum.Substring(cnum.Length - 2, 1);
                                        if (cbegin == 4 || (cbegin == 8 || cnum_end.IndexOf("��") >= 0 || cbegin == 12))
                                        {
                                                cnum = cnum + cmon;
                                                if (cnumber.IndexOf(cnum_end) >= 0)
                                                        zflag = 1;
                                                else
                                                        zflag = 0;
                                        }
                                        else
                                        {
                                                zflag = 0;
                                        }
                                        continue;
                                }
                                else if (sno != "0" && zflag == 0)
                                {
                                        cnum = cnum + "��";
                                        zflag = 1;
                                }
                                cno = cnumber.Substring(System.Convert.ToInt32(sno) - 1, 1);
                                cnum = cnum + cno + cmon;
                        }
                        if (snum.Substring(snum.Length - 2, 1) == "0")
                        {
                                return cnum + "��";
                        }
                        else
                                return cnum;
                }


                private static char[] strChinese = new char[] {
					'��','һ','��','��','��','��','��','��','��','��','ʮ'
					};

                /// <summary>
                /// ������ת�������Ĵ�дд��
                /// </summary>
                /// <param name="strDate"></param>
                /// <returns></returns>
                public static string ConvertToChineseDate(string DateParam)
                {
                        StringBuilder result = new StringBuilder();
                        string strDate = DateParam.Replace("��", "/");
                        strDate = strDate.Replace("��", "/");
                        strDate = strDate.Replace("��", "");

                        if (strDate.Length > 0)
                        {
                                // ���������ڵ������մ浽�ַ�����str��
                                string[] str = null;
                                if (strDate.Contains("-"))
                                {
                                        str = strDate.Split('-');
                                }
                                else if (strDate.Contains("/"))
                                {
                                        str = strDate.Split('/');
                                }

                                // str[0]��Ϊ�꣬��������ַ�ת��Ϊ��Ӧ�ĺ���
                                for (int i = 0; i < str[0].Length; i++)
                                {
                                        result.Append(strChinese[int.Parse(str[0][i].ToString())]);
                                }
                                result.Append("��");

                                // ת����
                                int month = int.Parse(str[1]);
                                int MN1 = month / 10;
                                int MN2 = month % 10;

                                if (MN1 > 1)
                                {
                                        result.Append(strChinese[MN1]);
                                }
                                if (MN1 > 0)
                                {
                                        result.Append(strChinese[10]);
                                }
                                if (MN2 != 0)
                                {
                                        result.Append(strChinese[MN2]);
                                }
                                result.Append("��");

                                // ת����
                                int day = int.Parse(str[2]);
                                int DN1 = day / 10;
                                int DN2 = day % 10;

                                if (DN1 > 1)
                                {
                                        result.Append(strChinese[DN1]);
                                }
                                if (DN1 > 0)
                                {
                                        result.Append(strChinese[10]);
                                }
                                if (DN2 != 0)
                                {
                                        result.Append(strChinese[DN2]);
                                }
                                result.Append("��");
                                return result.ToString();
                        }
                        else
                        {
                                return "";
                        }

                }

                public static Dictionary<string, object> ChangeXMLToDictionary(string pstr)
                {
                        int _index, _start, _end, em_start, em_end;
                        string _mark, _endmark;
                        Dictionary<string, object> _ret = new Dictionary<string, object>();
                        _index = 0;
                        while (_index < pstr.Length)
                        {
                                _start = pstr.IndexOf('<', _index);
                                if (_start >= 0)
                                {
                                        _end = pstr.IndexOf('>', _start);
                                        if (_end >= 0)
                                        {
                                                _mark = pstr.Substring(_start + 1, _end - _start - 1);
                                                _endmark = string.Format("</{0}>", _mark);
                                                em_start = pstr.IndexOf(_endmark, _end + 1);
                                                if (em_start >= 0)
                                                {
                                                        string value = pstr.Substring(_end + 1, em_start - _end - 1);
                                                        _ret.Add(_mark, value);
                                                        _index = _end + _endmark.Length + 1;
                                                }
                                                else
                                                {
                                                        _index = _end + 1;
                                                }
                                        }
                                        else
                                        {
                                                _index = _start + 1;
                                        }
                                }
                                else
                                {
                                        _index = pstr.Length + 1;
                                }
                        }

                        return _ret;
                }
        }
}
