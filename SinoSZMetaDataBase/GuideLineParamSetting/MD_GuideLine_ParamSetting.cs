using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.GuideLineParamSetting
{
        [Serializable]
        public class MD_GuideLine_ParamSetting
        {
                protected string csid = "";
                protected string zbid = "";
                protected string dwid = "";
                protected string csMeta = "";

                public string ParamMeta
                {
                        get { return csMeta; }
                        set { csMeta = value; }
                }

                public string DWID { get { return dwid; } set { dwid = value; } }
                public string GuideLineID { get { return zbid; } set { zbid = value; } }
                public string CSID { get { return csid; } set { csid = value; } }

                public MD_GuideLine_ParamSetting(string _csid, string _zbid, string _dwid, string _cs)
                {
                        csid = _csid;
                        zbid = _zbid;
                        dwid = _dwid;
                        csMeta = _cs;
                }
        }


}
