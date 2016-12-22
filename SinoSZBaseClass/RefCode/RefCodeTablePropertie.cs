using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZBaseClass.RefCode
{
        [Serializable]
        public class RefCodeTablePropertie
        {
                private string _refTableName = "";                              //代码表名
                private string _displayTitle = "";                             //显示名称
                private RefCodeType _codeType = RefCodeType.Number;     //代码类型

                private bool _supportPyzt = true;               //是否支持拼音字头
                private bool _supportLevel = false;             //是否分级代码
                private int _levelDownloadMode = 1;        //数据下载模式 1：一次性全部下载 2：分级下载
                private int _refTableMode = 1;	                //代码表模式：1：正常模式 2参数比较下载模式
                private bool _hideCode = false;                //是否隐藏代码  
                private string _LevelFormat = "";               //分级格式
                protected string _codeFieldName = "DM";	        //代码字段名
                protected string _pyztFieldName = "PYZT";       //拼音字头字段名
                protected string _valueFieldName = "MC";        //值字段名

                public RefCodeType CodeType { get { return _codeType; } set { _codeType = value; } }
                public bool HideCode { get { return _hideCode; } set { _hideCode = value; } }
                public bool SupportPyzt { get { return _supportPyzt; } set { _supportPyzt = value; } }
                public bool SupportLevel { get { return _supportLevel; } set { _supportLevel = value; } }
                public int LevelDownloadMode { get { return _levelDownloadMode; } set { _levelDownloadMode = value; } }
                public string CodeFieldName { get { return _codeFieldName; } set { _codeFieldName = value; } }
                public string PyztFieldName { get { return _pyztFieldName; } set { _pyztFieldName = value; } }
                public string ValueFieldName { get { return _valueFieldName; } set { _valueFieldName = value; } }
                public string LevelFormat { get { return _LevelFormat; } set { _LevelFormat = value; } }
                public int RefTableMode { get { return _refTableMode; } set { _refTableMode = value; } }
                public string Name { get { return _refTableName; } set { _refTableName = value; } }
                public string DisplayTitle { get { return _displayTitle; } set { _displayTitle = value; } }

                public RefCodeTablePropertie() { }

                public RefCodeTablePropertie(string _name, string _title, RefCodeType _type, bool _pyzt, bool _level, int _downLoadMode, int _refMode, string _format, bool _hide)
                {
                        _refTableName = _name;
                        _displayTitle = _title;
                        _codeType = _type;
                        _supportPyzt = _pyzt;
                        _supportLevel = _level;
                        _levelDownloadMode = _downLoadMode;
                        _refTableMode = _refMode;
                        _LevelFormat = _format;
                        _hideCode = _hide;

                }

        }
}
