using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZBaseClass.OrganizeExt
{
        [Serializable]
        public class OrgExtInfo
        {
                private Dictionary<string, object> extProperties = new Dictionary<string, object>();       //其它扩展属性
                public OrgExtInfo(string _zzjgid, string _zzjgqc, string _zzjgxsmc, decimal _isDisplay, decimal _order,string _sjdwid)
                {
                        extProperties.Add("ZZJGID", _zzjgid);//组织机构ID
                        extProperties.Add("ZZJGQC", _zzjgqc);//组织机构全称
                        extProperties.Add("JGXSMC", _zzjgxsmc);//组织机构显示名称
                        extProperties.Add("ISDISPLAY", _isDisplay);//是否显示
                        extProperties.Add("DISPLAYORDER", _order);//显示顺序
                        extProperties.Add("SJDWID", _sjdwid);      //上级单位ID
                }

                public void SetValue(string _fieldName, object _data)
                {
                        if (extProperties.ContainsKey(_fieldName))
                        {
                                extProperties[_fieldName] = _data;                             
                        }
                        else
                        {
                                extProperties.Add(_fieldName,_data);                            
                        }
                }

                public object GetValue(string _fieldName)
                {
                        if (extProperties.ContainsKey(_fieldName))
                        {
                                return extProperties[_fieldName];
                        }
                        else
                        {
                                return null;
                        }
                }




        }
}
