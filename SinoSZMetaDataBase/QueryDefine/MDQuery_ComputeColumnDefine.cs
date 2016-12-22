using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.QueryDefine
{
        [Serializable]
        public class MDQuery_ComputeColumnDefine
        {
                protected string columnName = "";
                protected string displayName = "";
                protected string columnMethod = "";
                protected string columnDescription = "";
                protected bool isPublic = false;
                protected string fullModelName = "";
                protected string tableName = "";
                protected string resultDataType = "";
                protected string displayMethod = "";
                protected DateTime createDate = DateTime.Now;

                public MDQuery_ComputeColumnDefine() { }
                public MDQuery_ComputeColumnDefine(string _columnName, string _displayName, string _columnMethod, string _description, bool _isPublic,
                        string _fullModelName, string _tableName, string _resultType, string _displayMethod,DateTime _createDate)
                {
                        columnName = _columnName;
                        displayName = _displayName;
                        columnMethod = _columnMethod;
                        columnDescription = _description;
                        isPublic = _isPublic;
                        fullModelName = _fullModelName;
                        tableName = _tableName;
                        resultDataType = _resultType;
                        displayMethod = _displayMethod;
                        createDate = _createDate;
                }

                public DateTime CreateDate
                {
                        get { return createDate; }
                        set { createDate = value; }
                }

                public string DisplayMethod
                {
                        get { return displayMethod; }
                        set { displayMethod = value; }
                }
                public string TableName
                {
                        get { return tableName; }
                        set { tableName = value; }
                }

                public string ResultDataType
                {
                        get { return resultDataType; }
                        set { resultDataType = value; }
                }
                public string ColumnDescription
                {
                        get { return columnDescription; }
                        set { columnDescription = value; }
                }

                public bool IsPulbic
                {
                        get { return isPublic; }
                        set { isPublic = value; }
                }

                public string FullModelName
                {
                        get { return fullModelName; }
                        set { fullModelName = value; }
                }

                public string ColumnName
                {
                        get { return columnName; }
                        set { columnName = value; }
                }

                public string DisplayName
                {
                        get { return displayName; }
                        set { displayName = value; }
                }

                public string ColumnMethod
                {
                        get { return columnMethod; }
                        set { columnMethod = value; }
                }

        }
}
