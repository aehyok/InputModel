using System;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.Entry
{
    [Serializable]
    public class EntryItem_RSK_INSTR
    {
        protected string id = "";
        protected string entry_id = "";		//报关单编号
        protected string instr_Type_Name = "";			//布控种类
        protected string rsk_Department = "";			//布控单位
        protected string instr_code = "";				//布控人工号
        protected bool selected = false;

        [DataMember]
        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// 是否选择
        /// </summary>
        /// 
        [DataMember]
        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }

        /// <summary>
        /// 报关单号
        /// </summary>
        /// 
        [DataMember]
        public string Entry_ID
        {
            get { return entry_id; }
            set { entry_id = value; }
        }
        [DataMember]
        public string Instr_Type_Name
        {
            get { return instr_Type_Name; }
            set { instr_Type_Name = value; }
        }
        [DataMember]
        public string Rsk_Department
        {
            get { return rsk_Department; }
            set { rsk_Department = value; }
        }
        [DataMember]
        public string Instr_Code
        {
            get { return instr_code; }
            set { instr_code = value; }
        }
    }
}
