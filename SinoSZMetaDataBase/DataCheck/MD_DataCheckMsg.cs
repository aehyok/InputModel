using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.DataCheck
{
        [Serializable]
        public class MD_DataCheckMsg
        {
                private string id = "";
                private string shjlid = "";
                private string bh = "";
                private string fbdwdm = "";
                private string fbdwmc = "";
                private DateTime fbsj = DateTime.MinValue;
                private string fbr = "";
                private string lxdh = "";
                private string yjdz = "";
                private string xxbt = "";
                private string xxnr = "";
                private string cddwdm = "";
                private string cddwmc = "";
                private string fkjg = "";
                private object fksj = null;
                private decimal sfyc = 0;

                public MD_DataCheckMsg(string _id, string _shjlid, string _bh, string _fbdwdm, string _fbdwmc, DateTime _fbsj, string _fbr,
                                                                string _lxdh, string _yjdz, string _xxbt, string _xxnr, string _cddwdm, string _cddwmc, string _fkjg, object _fksj, decimal _sfyc)
                {
                        id = _id;
                        shjlid = _shjlid;
                        bh = _bh;
                        fbdwdm = _fbdwdm;
                        fbdwmc = _fbdwmc;
                        fbsj = _fbsj;
                        fbr = _fbr;
                        lxdh = _lxdh;
                        yjdz = _yjdz;
                        xxbt = _xxbt;
                        xxnr = _xxnr;
                        cddwdm = _cddwdm;
                        cddwmc = _cddwmc;
                        fkjg = _fkjg;
                        fksj = _fksj;
                        sfyc = _sfyc;
                }

                public string ID { get { return id; } set { id = value; } }
                public string SHJLID { get { return shjlid; } set { shjlid = value; } }
                public string BH { get { return bh; } set { bh = value; } }
                public string FBDWDM { get { return fbdwdm; } set { fbdwdm = value; } }
                public string FBDWMC { get { return fbdwmc; } set { fbdwmc = value; } }
                public DateTime FBSJ { get { return fbsj; } set { fbsj = value; } }
                public string FBR { get { return fbr; } set { fbr = value; } }
                public string LXDH { get { return lxdh; } set { lxdh = value; } }
                public string YJDZ { get { return yjdz; } set { yjdz = value; } }
                public string XXBT { get { return xxbt; } set { xxbt = value; } }
                public string XXNR { get { return xxnr; } set { xxnr = value; } }
                public string CDDWDM { get { return cddwdm; } set { cddwdm = value; } }
                public string CDDWMC { get { return cddwmc; } set { cddwmc = value; } }
                public string FKJG { get { return fkjg; } set { fkjg = value; } }
                public object FKSJ { get { return fksj; } set { fksj = value; } }
                public decimal SFYC { get { return sfyc; } set { sfyc = value; } }



        }
}
