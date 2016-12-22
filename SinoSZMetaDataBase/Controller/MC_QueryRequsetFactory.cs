using System;
using System.Collections.Generic;
using System.Text;
using SinoSZMetaDataBase.QueryDefine;
using SinoSZMetaDataBase.ModelDefine;
using SinoSZMetaDataBase.Define;

namespace SinoSZMetaDataBase.Controller
{
        public class MC_QueryRequsetFactory
        {
                protected MDQuery_Request queryRequest = new MDQuery_Request();

                public MDQuery_Request GetQueryRequest()
                {
                        return queryRequest;
                }

                public string QueryModelName
                {
                        get { return queryRequest.QueryModelName; }
                        set { queryRequest.QueryModelName = value; }
                }

                public void AddConditonItem(MDQuery_ConditionItem _conditionItem)
                {
                        this.queryRequest.ConditionItems.Add(_conditionItem.ColumnIndex,_conditionItem);
                }

                public void AddResultTable(MDModel_Table _mtable)
                {
                        string _tname = _mtable.TableName;
                        if (this.queryRequest.MainResultTable !=null && this.queryRequest.MainResultTable.TableName == _tname) return;
                        if (this.queryRequest.ChildResultTables.ContainsKey(_tname)) return;
                        MDQuery_ResultTable _table = new MDQuery_ResultTable();
                        _table.TableName = _mtable.TableName;
                        _table.DisplayTitle = _mtable.TableDefine.DisplayTitle;
                        if (_mtable.TableDefine.ViewTableType == MDType_ViewTable.MainTable)
                        {
                                this.queryRequest.MainResultTable = _table;
                        }
                        else
                        {
                                this.queryRequest.ChildResultTables.Add(_tname, _table);
                        }
                }

                public void AddResultTableColumn(MDModel_Table _mtable, MDModel_Table_Column _mColumn)
                {
                        MDQuery_ResultTable _rtable;
                        string _tname = _mtable.TableName;
                        if (this.queryRequest.MainResultTable!=null && this.queryRequest.MainResultTable.TableName == _tname)
                        {
                                _rtable = this.queryRequest.MainResultTable;
                        }
                        else
                        {
                                _rtable = this.queryRequest.ChildResultTables[_tname];
                        }

                        string _cname = _mColumn.ColumnName;
                        if (!_rtable.ColumnsDict.ContainsKey(_cname))
                        {
                                MDQuery_ResultTableColumn _column =new MDQuery_ResultTableColumn(_mColumn);
                                _rtable.ColumnsDict.Add(_cname, _column);
                                _rtable.AliasDict.Add(_mColumn.ColumnAlias,_column);
                        }
                       

                }

                public void AddExpression(string _expression)
                {
                        queryRequest.ConditionExpressions = _expression;
                }
        }
}
