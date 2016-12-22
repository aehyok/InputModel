using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.QueryDefine
{
        /// <summary>
        /// 查询条件项
        /// </summary>
        [Serializable]
        public class MDQuery_ConditionItem
        {
                private string _columnIndex = "";
                private MDQuery_ResultTableColumn _columnDefine = null;
                private string _operator = "";
                private List<string> _values = new List<string>();
                private bool _caseSensitive = false;

                public bool CaseSensitive
                {
                        get { return _caseSensitive; }
                        set { _caseSensitive = value; }
                }

                public string ColumnIndex
                {
                        get { return _columnIndex; }
                        set { _columnIndex = value; }
                }

                public MDQuery_ResultTableColumn Column
                {
                        get { return _columnDefine; }
                        set { _columnDefine = value; }
                }

                public string Operator
                {
                        get { return _operator; }
                        set { _operator = value; }
                }

                public List<string> Values
                {
                        get { return _values; }
                        set { _values = value; }
                }

        }
}
