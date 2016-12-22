using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.Define
{
        [Serializable()]
        public class DB_TableMeta
        {
                private string _tableName = "";
                private string _tableComment = "";
                private string _tableType = "";


                public string TableName
                {
                        get { return _tableName; }
                        set { _tableName = value; }
                }

                public string TableComment
                {
                        get { return _tableComment; }
                        set { _tableComment = value; }
                }

                public string TableType
                {
                        get { return _tableType; }
                        set { _tableType = value; }
                }


                public DB_TableMeta()
                {
                }

                public DB_TableMeta(string _tname, string _tcomment, string _ttype)
                {
                        _tableName = _tname;
                        _tableComment = _tcomment;
                        _tableType = _ttype;
                }
                

        }
}
