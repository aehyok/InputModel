using System;
using System.Collections.Generic;
using System.Text;
using SinoSZMetaDataBase.Define;

namespace SinoSZMetaDataBase.QueryDefine
{
        /// <summary>
        /// 指标查询参数
        /// </summary>
        [Serializable]
        public class MDQuery_GuideLineParameter
        {
                private MD_GuideLineParameter _paramDefine = null;
                private object _data = null;

                public MDQuery_GuideLineParameter() { }

                public MDQuery_GuideLineParameter(MD_GuideLineParameter _pDefine, object data)
                {
                        _paramDefine = _pDefine;
                        _data = data;
                }

                public MD_GuideLineParameter Paramter
                {
                        get { return _paramDefine; }
                        set { _paramDefine = value; }
                }

                public object Data
                {
                        get { return _data; }
                        set { _data = value; }
                }


        }
}
