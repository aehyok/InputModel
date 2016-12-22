using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.Define
{
        [Serializable()]
        public class DB_ColumnMeta
        {
                private string _columnName;
                private string _comments;
                private string _dataType;
                private bool _nullable;
                private int _dataLength;
                private int _dataPrecision;


                public DB_ColumnMeta()
                {
                }

                public DB_ColumnMeta(string _cname, string _comm, string _type, bool _null, int _len, int _pri)
                {
                        _columnName = _cname;
                        _comments = _comm;
                        _dataType = _type;
                        _nullable = _null;
                        _dataLength = _len;
                        _dataPrecision = _pri;
                }

                public string ColumnName
                {
                        get { return _columnName; }
                        set { _columnName = value; }
                }

                public string Comments
                {
                        get { return _comments; }
                        set { _comments = value; }
                }

                public string DataType
                {
                        get { return _dataType; }
                        set { _dataType = value; }
                }

                public bool Nullable
                {
                        get { return _nullable; }
                        set { _nullable = value; }
                }

                public int DataLength
                {
                        get { return _dataLength; }
                        set { _dataLength = value; }
                }

                public int DataPrecision
                {
                        get { return _dataPrecision; }
                        set { _dataPrecision = value; }
                }
        }
}
