using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZBaseClass.OrganizeExt
{
        [Serializable]
        public class OrgExtInfo
        {
                private Dictionary<string, object> extProperties = new Dictionary<string, object>();       //������չ����
                public OrgExtInfo(string _zzjgid, string _zzjgqc, string _zzjgxsmc, decimal _isDisplay, decimal _order,string _sjdwid)
                {
                        extProperties.Add("ZZJGID", _zzjgid);//��֯����ID
                        extProperties.Add("ZZJGQC", _zzjgqc);//��֯����ȫ��
                        extProperties.Add("JGXSMC", _zzjgxsmc);//��֯������ʾ����
                        extProperties.Add("ISDISPLAY", _isDisplay);//�Ƿ���ʾ
                        extProperties.Add("DISPLAYORDER", _order);//��ʾ˳��
                        extProperties.Add("SJDWID", _sjdwid);      //�ϼ���λID
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
