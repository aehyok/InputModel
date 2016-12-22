using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataBase.QueryDefine
{
        [Serializable]
        public class MDSearch_ResultDataIndex
        {
                private string content = "";
                private int matchPosition = 0;
                private string dataLocation = "";
                private string dataSource = "";
                private string mainKey = "";
                private MDSearch_Column sourceColumn = null;
                public MDSearch_ResultDataIndex() { }

                public MDSearch_ResultDataIndex(string _content, int _position, MDSearch_Column _location, string _source, string _key)
                {
                        content = _content;
                        matchPosition = _position;
                        sourceColumn = _location;
                        dataLocation = string.Format("{0}.{1}", _location.TableTitle, _location.ColumnTitle);
                        dataSource = _source;
                        mainKey = _key;
                }

                public MDSearch_Column SourceColumn
                {
                        get { return sourceColumn; }
                        set { sourceColumn = value; }
                }

                /// <summary>
                /// 结果的数据主键(指表的主键)
                /// </summary>
                public string MainKey
                {
                        get { return mainKey; }
                        set { mainKey = value; }
                }

                /// <summary>
                /// 数据来源,(指查询模型名称)
                /// </summary>
                public string DataSource
                {
                        get
                        {
                                return dataSource;
                        }
                        set { dataSource = value; }
                }

                /// <summary>
                /// 内容
                /// </summary>
                public string Content
                {
                        get
                        {
                                return content;
                        }
                        set
                        {
                                content = value;
                        }
                }

                /// <summary>
                /// 匹配位置
                /// </summary>
                public int MatchPosition
                {
                        get { return matchPosition; }
                        set { matchPosition = value; }
                }

                /// <summary>
                /// 数据位置
                /// </summary>
                public string DataLocation
                {
                        get { return dataLocation; }
                        set { dataLocation = value; }
                }
        }
}
