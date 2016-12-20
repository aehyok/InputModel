using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SinoSZJS.DataAccess.Sql;
using SinoSZJS.Base.MetaData.Define;

namespace aehyok.BizMetaData
{
    public class QueryModelAccessor
    {
        private const string SQL_GetView2ViewGroupOfQueryModel = @"select ID,VIEWID,DISPLAYTITLE,DISPLAYORDER from MD_VIEW2VIEWGROUP where VIEWID=@VIEWID order by DISPLAYORDER";
        public static List<MD_View2ViewGroup> GetView2ViewGroupOfQueryModel(string ViewID)
        {
            List<MD_View2ViewGroup> _ret = new List<MD_View2ViewGroup>();
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                try
                {
                    SqlCommand _cmd = new SqlCommand(SQL_GetView2ViewGroupOfQueryModel, cn);
                    _cmd.Parameters.Add("@VIEWID", decimal.Parse(ViewID));
                    using (SqlDataReader _dr = _cmd.ExecuteReader())
                    {
                        while (_dr.Read())
                        {
                            MD_View2ViewGroup _g = new MD_View2ViewGroup();
                            _g.ID = _dr.IsDBNull(0) ? "" : _dr.GetString(0);
                            _g.DisplayTitle = _dr.IsDBNull(2) ? "" : _dr.GetString(2);
                            _g.DisplayOrder = _dr.IsDBNull(3) ? 0 : Convert.ToInt32(_dr.GetDouble(3));
                            _ret.Add(_g);
                        }
                    }
                }
                catch (Exception e)
                {
                    LogWriter.WriteSystemLog(string.Format("在取查询模型{0}相关联模型分组信息时发生错误，错误信息：{1} ", ViewID, e.Message), "ERROR");
                    return null;
                }
            }
            return _ret;
        }

        private const string SQL_AddView2ViewGroup = "insert into MD_VIEW2VIEWGROUP (ID,VIEWID,DISPLAYORDER,DISPLAYTITLE) values (@ID,@VIEWID,0,'未命名分组')";
        public static string AddView2ViewGroup(string ViewID)
        {
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                try
                {
                    SqlCommand _cmd = new SqlCommand(SQL_AddView2ViewGroup, cn);
                    _cmd.Parameters.Add("@ID", Guid.NewGuid().ToString());
                    _cmd.Parameters.Add("@VIEWID", decimal.Parse(ViewID));
                    _cmd.ExecuteNonQuery();
                    return "";
                }
                catch (Exception e)
                {
                    string _msg = string.Format("在新建查询模型{0}相关联模型分组信息时发生错误，错误信息：{1} ", ViewID, e.Message);
                    LogWriter.WriteSystemLog(_msg, "ERROR");
                    return _msg;
                }
            }
        }

        private const string SQL_SaveView2ViewGroup = "update MD_VIEW2VIEWGROUP set DISPLAYORDER=@DISPLAYORDER,DISPLAYTITLE=@DISPLAYTITLE where ID=@ID";
        public static bool SaveView2ViewGroup(MD_View2ViewGroup View2ViewGroup)
        {
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                try
                {
                    SqlCommand _cmd = new SqlCommand(SQL_SaveView2ViewGroup, cn);
                    _cmd.Parameters.Add("@DISPLAYORDER", Convert.ToDecimal(View2ViewGroup.DisplayOrder));
                    _cmd.Parameters.Add("@DISPLAYTITLE", View2ViewGroup.DisplayTitle);
                    _cmd.Parameters.Add("@ID", View2ViewGroup.ID);
                    _cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    string _msg = string.Format("在保存查询模型{0}相关联模型分组信息时发生错误，错误信息：{1} ", View2ViewGroup.QueryModelID, e.Message);
                    LogWriter.WriteSystemLog(_msg, "ERROR");
                    return false;
                }
            }
        }

        private const string SQL_GetView2ViewList = @"select ID,VIEWID,TARGETVIEWNAME,RELATIONSTR,DISPLAYORDER,DISPLAYTITLE,GROUPID from MD_VIEW2VIEW WHERE VIEWID=@VIEWID and GROUPID=@GROUPID";
        public static List<MD_View2View> GetView2ViewList(string GroupID, string ViewID)
        {
            List<MD_View2View> _ret = new List<MD_View2View>();
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                try
                {
                    SqlCommand _cmd = new SqlCommand(SQL_GetView2ViewList, cn);
                    _cmd.Parameters.Add("@VIEWID", decimal.Parse(ViewID));
                    _cmd.Parameters.Add("@GROUPID", GroupID);
                    using (SqlDataReader _dr = _cmd.ExecuteReader())
                    {
                        while (_dr.Read())
                        {
                            MD_View2View _g = new MD_View2View();
                            _g.ID = _dr.IsDBNull(0) ? "" : _dr.GetString(0);
                            _g.TargetViewName = _dr.IsDBNull(2) ? "" : _dr.GetString(2);
                            _g.RelationString = _dr.IsDBNull(3) ? "" : _dr.GetString(3);
                            _g.DisplayOrder = _dr.IsDBNull(4) ? 0 : Convert.ToInt32(_dr.GetDouble(4));
                            _g.DisplayTitle = _dr.IsDBNull(5) ? "" : _dr.GetString(5);
                            _ret.Add(_g);
                        }
                    }
                }
                catch (Exception e)
                {
                    LogWriter.WriteSystemLog(string.Format("在取查询模型{0}相关联模型分组信息时发生错误，错误信息：{1} ", ViewID, e.Message), "ERROR");
                    return null;
                }
            }
            return _ret;
        }

        private const string SQL_DelView2ViewGroup = @"delete from MD_VIEW2VIEWGROUP where ID=@ID";
        private const string SQL_DelView2ViewGroup2 = @"delete from MD_VIEW2VIEW where GROUPID=@ID";
        public static string DelView2ViewGroup(string GroupID)
        {
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                SqlTransaction txn = cn.BeginTransaction();
                try
                {
                    SqlCommand _cmd = new SqlCommand(SQL_DelView2ViewGroup2, cn);
                    _cmd.Parameters.Add("@ID", GroupID);
                    _cmd.ExecuteNonQuery();

                    SqlCommand _cmd2 = new SqlCommand(SQL_DelView2ViewGroup, cn);
                    _cmd2.Parameters.Add("@ID", GroupID);
                    _cmd2.ExecuteNonQuery();
                    txn.Commit();
                    return "";
                }
                catch (Exception e)
                {
                    txn.Rollback();
                    string _msg = string.Format("删除查询相关联模型分组{0}信息时发生错误，错误信息：{1} ", GroupID, e.Message);
                    LogWriter.WriteSystemLog(_msg, "ERROR");
                    return _msg;
                }
            }
        }

        private const string SQL_AddView2View = @"insert into MD_VIEW2VIEW (ID,VIEWID,DISPLAYORDER,DISPLAYTITLE,GROUPID) values (@ID,@VIEWID,0,'未设置的关联模型',@GROUPID)";
        public static string AddView2View(string ViewID, string GroupID)
        {
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                try
                {
                    SqlCommand _cmd = new SqlCommand(SQL_AddView2View, cn);
                    _cmd.Parameters.Add("@ID", Guid.NewGuid().ToString());
                    _cmd.Parameters.Add("@VIEWID", decimal.Parse(ViewID));
                    _cmd.Parameters.Add("@GROUPID", GroupID);
                    _cmd.ExecuteNonQuery();
                    return "";
                }
                catch (Exception e)
                {
                    string _msg = string.Format("在新建查询模型{0}相关联的模型信息时发生错误，错误信息：{1} ", ViewID, e.Message);
                    LogWriter.WriteSystemLog(_msg, "ERROR");
                    return _msg;
                }
            }
        }

        private const string SQL_SaveView2View = @"update MD_VIEW2VIEW set TARGETVIEWNAME=@VIEWNAME,RELATIONSTR=@STR,DISPLAYORDER=@DISPORDER,DISPLAYTITLE=@TITLE where ID=@ID";
        public static bool SaveView2View(MD_View2View View2View)
        {
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                try
                {
                    SqlCommand _cmd = new SqlCommand(SQL_SaveView2View, cn);
                    _cmd.Parameters.Add("@VIEWNAME", View2View.TargetViewName);
                    _cmd.Parameters.Add("@STR", View2View.RelationString);
                    _cmd.Parameters.Add("@DISPORDER", Convert.ToDecimal(View2View.DisplayOrder));
                    _cmd.Parameters.Add("@TITLE", View2View.DisplayTitle);
                    _cmd.Parameters.Add("@ID", View2View.ID);
                    _cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    string _msg = string.Format("在保存关联的模型信息{0}时发生错误，错误信息：{1} ", View2View.ID, e.Message);
                    LogWriter.WriteSystemLog(_msg, "ERROR");
                    return false;
                }
            }
        }

        private const string SQL_DelView2View = @"delete from MD_VIEW2VIEW where ID=@ID";
        public static string CMD_DelView2View(string v2vid)
        {
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                try
                {
                    SqlCommand _cmd = new SqlCommand(SQL_DelView2View, cn);
                    _cmd.Parameters.Add(":ID", v2vid);
                    _cmd.ExecuteNonQuery();
                    return "";
                }
                catch (Exception e)
                {
                    string _msg = string.Format("在删除查询模型相关联的模型信息{0}时发生错误，错误信息：{1} ", v2vid, e.Message);
                    LogWriter.WriteSystemLog(_msg, "ERROR");
                    return _msg;
                }
            }
        }

        private const string SQL_GetQueryModelExRights = @"select ID,rvalue,rtitle,viewid,fid from md_view_exright where viewid=@VIEWID and fid=@FID ";
        public static List<MD_QueryModel_ExRight> GetQueryModelExRights(string QueryModelID, string FatherID)
        {
            List<MD_QueryModel_ExRight> _ret = new List<MD_QueryModel_ExRight>();
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                try
                {
                    SqlCommand _cmd = new SqlCommand(SQL_GetQueryModelExRights, cn);
                    _cmd.Parameters.Add("@VIEWID", Decimal.Parse(QueryModelID));
                    _cmd.Parameters.Add("@FID", FatherID);
                    using (SqlDataReader _dr = _cmd.ExecuteReader())
                    {
                        while (_dr.Read())
                        {
                            MD_QueryModel_ExRight _ritem = new MD_QueryModel_ExRight();
                            _ritem.ID = _dr.IsDBNull(0) ? "" : _dr.GetString(0);
                            _ritem.RightName = _dr.IsDBNull(1) ? "" : _dr.GetString(1);
                            _ritem.RightTitle = _dr.IsDBNull(2) ? "" : _dr.GetString(2);
                            _ritem.ModelID = _dr.IsDBNull(3) ? "" : _dr.GetDouble(3).ToString();
                            _ritem.FatherRightID = _dr.IsDBNull(4) ? "" : _dr.GetString(4);
                            _ret.Add(_ritem);
                        }
                    }
                }
                catch (Exception e)
                {
                    string _msg = string.Format("在取查询模型[{0}]相关联的模型扩展权限信息时发生错误，错误信息：{1} ", QueryModelID, e.Message);
                    LogWriter.WriteSystemLog(_msg, "ERROR");
                }
            }
            return _ret;
        }

        private const string SQL_AddNewViewExRight = "insert into md_view_exright (id,rvalue,rtitle,viewid,fid,displayorder) values (@ID,@RVALUE,@RTITLE,@VIEWID,@FID,0)";
        public static bool AddNewViewExRight(string RightValue, string RightTitle, string ViewID, MD_QueryModel_ExRight FatherRight)
        {
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                try
                {
                    SqlCommand _cmd = new SqlCommand(SQL_AddNewViewExRight, cn);
                    _cmd.Parameters.Add("@ID", Guid.NewGuid().ToString());
                    _cmd.Parameters.Add("@RVALUE", RightValue);
                    _cmd.Parameters.Add("@RTITLE", RightTitle);
                    _cmd.Parameters.Add("@VIEWID", decimal.Parse(ViewID));
                    _cmd.Parameters.Add("@FID", (FatherRight == null) ? "0" : FatherRight.ID);
                    _cmd.ExecuteNonQuery();
                    return true;

                }
                catch (Exception e)
                {
                    string _msg = string.Format("新建查询模型[{0}]相关联的模型扩展权限信息时发生错误，错误信息：{1} ", ViewID, e.Message);
                    LogWriter.WriteSystemLog(_msg, "ERROR");
                    return false;
                }
            }
        }

        private const string SQL_SaveQueryModelExRight = "update md_view_exright  set rvalue=@RVALUE,rtitle=@RTITLE,displayorder=@DISPLAYORDER where ID=@ID";
        public static bool SaveQueryModelExRight(MD_QueryModel_ExRight ExRight)
        {
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                try
                {
                    SqlCommand _cmd = new SqlCommand(SQL_SaveQueryModelExRight, cn);
                    _cmd.Parameters.Add("@RVALUE", ExRight.RightName);
                    _cmd.Parameters.Add("@RTITLE", ExRight.RightTitle);
                    _cmd.Parameters.Add("@DISPLAYORDER", Convert.ToDecimal(ExRight.DisplayOrder));
                    _cmd.Parameters.Add("@ID", ExRight.ID);
                    _cmd.ExecuteNonQuery();
                    return true;

                }
                catch (Exception e)
                {
                    string _msg = string.Format("保存查询模型[{0}]相关联的模型扩展权限信息时发生错误，错误信息：{1} ", ExRight.ModelID, e.Message);
                    LogWriter.WriteSystemLog(_msg, "ERROR");
                    return false;
                }
            }
        }

        private const string SQL_CheckDelViewExRight = @"select count(*) from md_view_exright where FID=@FID ";
        private const string SQL_DelViewExRight = @"DELETE from md_view_exright where ID=@ID";
        public static string CMD_DelViewExRight(MD_QueryModel_ExRight ExRight)
        {
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                try
                {
                    SqlCommand _cmdCheck = new SqlCommand(SQL_CheckDelViewExRight, cn);
                    _cmdCheck.Parameters.Add("@FID", ExRight.ID);
                    decimal _ret = (decimal)_cmdCheck.ExecuteScalar();
                    if (_ret > 0) return "请先删除子权限！";

                    SqlCommand _cmdDel = new SqlCommand(SQL_DelViewExRight, cn);
                    _cmdDel.Parameters.Add("@ID", ExRight.ID);
                    _cmdDel.ExecuteNonQuery();
                    return "";
                }
                catch (Exception e)
                {
                    string _msg = string.Format("删除查询模型[{0}]的模型扩展权限信息时发生错误，错误信息：{1} ", ExRight.ModelID, e.Message);
                    LogWriter.WriteSystemLog(_msg, "ERROR");
                    return _msg;
                }
            }
        }

        private const string SQL_CheckExistV2G = @"select count(*) from md_view2gl where id=@ID";
        private const string SQL_InsertV2G = @"insert into md_view2gl (id,viewid,targetgl,targetcs,displayorder,displaytitle) values (@ID,@VIEWID,@TARGETGL,@TARGETCS,@DISPLAYORDER,@DISPLAYTITLE)";
        private const string SQL_UpdateV2G = @"update md_view2gl set viewid=@VIEWID,targetgl=@TARGETGL,targetcs=@TARGETCS,displayorder=@DISPLAYORDER,displaytitle=@DISPLAYTITLE where id=@ID";
        public static bool SaveView2GL(string V2GID, string VIEWID, string GuideLineID, string Params, int DisplayOrder, string DisplayTitle)
        {
            SqlCommand SaveCmd;
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                SqlTransaction _txn = cn.BeginTransaction();
                try
                {
                    SqlCommand _cmd = new SqlCommand(SQL_CheckExistV2G, cn);
                    _cmd.Parameters.Add("@ID", V2GID);
                    decimal _count = (decimal)_cmd.ExecuteScalar();
                    if (_count > 0)
                    {
                        SaveCmd = new SqlCommand(SQL_UpdateV2G, cn);
                        SaveCmd.Parameters.Add("@VIEWID", VIEWID);
                        SaveCmd.Parameters.Add("@TARGETGL", GuideLineID);
                        SaveCmd.Parameters.Add("@TARGETCS", Params);
                        SaveCmd.Parameters.Add("@DISPLAYORDER", Convert.ToDecimal(DisplayOrder));
                        SaveCmd.Parameters.Add("@DISPLAYTITLE", DisplayTitle);
                        SaveCmd.Parameters.Add("@ID", V2GID);
                        SaveCmd.ExecuteNonQuery();
                    }
                    else
                    {
                        SaveCmd = new SqlCommand(SQL_InsertV2G, cn);
                        SaveCmd.Parameters.Add("@ID", V2GID);
                        SaveCmd.Parameters.Add("@VIEWID", VIEWID);
                        SaveCmd.Parameters.Add("@TARGETGL", GuideLineID);
                        SaveCmd.Parameters.Add("@TARGETCS", Params);
                        SaveCmd.Parameters.Add("@DISPLAYORDER", Convert.ToDecimal(DisplayOrder));
                        SaveCmd.Parameters.Add("@DISPLAYTITLE", DisplayTitle);
                        SaveCmd.ExecuteNonQuery();
                    }
                    _txn.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    string _msg = string.Format("保存查询模型的关联指标定义时发生错误，错误信息：{0} ", ex.Message);
                    LogWriter.WriteSystemLog(_msg, "ERROR");
                    _txn.Rollback();
                    return false;
                }
            }

        }

        private const string SQL_CMD_DelView2GL = @"delete from md_view2gl where ID=@ID";
        public static string CMD_DelView2GL(MD_View_GuideLine View2GL)
        {
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                try
                {
                    SqlCommand _cmdDel = new SqlCommand(SQL_CMD_DelView2GL, cn);
                    _cmdDel.Parameters.Add("@ID", View2GL.ID);
                    _cmdDel.ExecuteNonQuery();
                    return "";
                }
                catch (Exception e)
                {
                    string _msg = string.Format("删除查询模型[{0}]的关联指标扩展信息时发生错误，错误信息：{1} ", View2GL.ViewID, e.Message);
                    LogWriter.WriteSystemLog(_msg, "ERROR");
                    return _msg;
                }
            }
        }

        private const string SQL_GetView2ApplicationList = @"select ID,VIEWID,TITLE,INTEGRATEDAPP,DISPLAYHEIGHT,URL,DISPLAYORDER,META 
                                                                from MD_VIEW2APP where VIEWID=@VIEWID order by DISPLAYORDER";
        public static List<MD_View2App> GetView2ApplicationList(string QueryModelID)
        {
            List<MD_View2App> _ret = new List<MD_View2App>();
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                try
                {
                    SqlCommand _cmd = new SqlCommand(SQL_GetView2ApplicationList, cn);
                    _cmd.Parameters.Add("@VIEWID", decimal.Parse(QueryModelID));
                    using (SqlDataReader _dr = _cmd.ExecuteReader())
                    {
                        while (_dr.Read())
                        {
                            MD_View2App _app = new MD_View2App();
                            _app.ID = _dr.IsDBNull(0) ? "" : _dr.GetString(0);
                            _app.ViewID = _dr.IsDBNull(1) ? "" : _dr.GetString(1);
                            _app.Title = _dr.IsDBNull(2) ? "" : _dr.GetString(2);
                            _app.AppName = _dr.IsDBNull(3) ? "" : _dr.GetString(3);
                            _app.DisplayHeight = _dr.IsDBNull(4) ? 40 : Convert.ToInt32(_dr.GetDouble(4));
                            _app.RegURL = _dr.IsDBNull(5) ? "" : _dr.GetString(5);
                            _app.DisplayOrder = _dr.IsDBNull(6) ? 40 : Convert.ToInt32(_dr.GetDouble(6));
                            _app.Meta = _dr.IsDBNull(7) ? "" : _dr.GetString(7);

                            _ret.Add(_app);
                        }
                    }

                }
                catch (Exception e)
                {
                    string _err = string.Format("在获取查询模型的集成应用展示定义时发生错误，错误信息：{0}", e.Message);
                    LogWriter.WriteSystemLog(_err, "ERROR");

                }
            }
            return _ret;
        }

        private const string SQL_SaveView2App_Insert = @"insert into MD_VIEW2APP (ID,VIEWID,TITLE,INTEGRATEDAPP,DISPLAYHEIGHT,URL,DISPLAYORDER,META)
                                                            values (@ID,@VIEWID,@TITLE,@INTEGRATEDAPP,@DISPLAYHEIGHT,@URL,@DISPLAYORDER,@META)";
        public static bool SaveView2App(string V2AID, MD_View2App View2AppData)
        {
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                SqlTransaction _txn = cn.BeginTransaction();
                try
                {
                    SqlCommand _cmd = new SqlCommand(SQL_CMD_DelView2App, cn);
                    _cmd.Parameters.Add("@ID", decimal.Parse(V2AID));
                    _cmd.ExecuteNonQuery();

                    SqlCommand _ins = new SqlCommand(SQL_SaveView2App_Insert, cn);
                    _ins.Parameters.Add("@ID", decimal.Parse(V2AID));
                    _ins.Parameters.Add("@VIEWID", decimal.Parse(View2AppData.ViewID));
                    _ins.Parameters.Add("@TITLE", View2AppData.Title);
                    _ins.Parameters.Add("@INTEGRATEDAPP", View2AppData.AppName);
                    _ins.Parameters.Add("@DISPLAYHEIGHT", Convert.ToDecimal(View2AppData.DisplayHeight));
                    _ins.Parameters.Add("@URL", View2AppData.RegURL);
                    _ins.Parameters.Add("@DISPLAYORDER", Convert.ToDecimal(View2AppData.DisplayOrder));
                    _ins.Parameters.Add("@META", View2AppData.Meta);
                    _ins.ExecuteNonQuery();

                    _txn.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    string _err = string.Format("在保存查询模型的集成应用展示定义时发生错误，错误信息：{0}", e.Message);
                    LogWriter.WriteSystemLog(_err, "ERROR");
                    return false;
                }
            }
        }

        private const string SQL_CMD_DelView2App = @"DELETE FROM MD_VIEW2APP where id=@ID";
        public static string CMD_DelView2App(string V2AID)
        {
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                try
                {
                    SqlCommand _cmd = new SqlCommand(SQL_CMD_DelView2App, cn);
                    _cmd.Parameters.Add("@ID", decimal.Parse(V2AID));
                    _cmd.ExecuteNonQuery();
                    return "";
                }
                catch (Exception e)
                {
                    string _err = string.Format("在删除查询模型的集成应用展示定义时发生错误，错误信息：{0}", e.Message);
                    LogWriter.WriteSystemLog(_err, "ERROR");
                    return _err;
                }
            }
        }

        private const string SQL_CMD_ClearView2App = @"DELETE FROM MD_VIEW2APP where VIEWID=@VIEWID";
        public static string CMD_ClearView2App(string QueryModelID)
        {
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                try
                {
                    SqlCommand _cmd = new SqlCommand(SQL_CMD_ClearView2App, cn);
                    _cmd.Parameters.Add("@VIEWID", QueryModelID);
                    _cmd.ExecuteNonQuery();
                    return "";
                }
                catch (Exception e)
                {
                    string _err = string.Format("在清空查询模型的集成应用展示定义时发生错误，错误信息：{0}", e.Message);
                    LogWriter.WriteSystemLog(_err, "ERROR");
                    return _err;
                }
            }
        }
    }
}
