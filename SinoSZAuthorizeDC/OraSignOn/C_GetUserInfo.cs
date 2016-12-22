using System;
using System.Collections;
using System.Data;
using System.Text;
using Oracle.DataAccess.Client;
using SinoSZDataAccessBase;
using SinoSZBaseClass.Authorize;
using System.Collections.Generic;
using SinoSZBaseClass.Misc;
using SinoSZBaseClass.SystemLog;
using System.Diagnostics;

namespace SinoSZAuthorizeDC.OraSignOn
{
    /// <summary>
    /// C_GetUserInfo ��ժҪ˵����
    /// </summary>
    public class C_GetUserInfo
    {
        public C_GetUserInfo()
        {
            //
            // TODO: �ڴ˴����ӹ��캯���߼�
            //
        }

        /// <summary>
        /// ��ȡ��������Ա��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SinoUser GetAdminInfo()
        {
            SinoUser _su = new SinoUser();

            _su.LoginName = "administrator";
            _su.Dwdm = "";
            _su.DwID = "";
            _su.DwName = "";
            _su.UserID = "0";
            _su.UserName = "ϵͳ����Ա";
            _su.SecretLevel = 1000;
            _su.QxszJB = "ֱ�����ؼ�";
            _su.Posts = new List<SinoPost>();

            SinoPost _adminPost = new SinoPost();
            _adminPost.PostID = "0";
            _adminPost.PostName = "��������Ա";
            _adminPost.PostDwID = ConfigFile.SytemDWRootID;
            _adminPost.Rights = new Dictionary<string, UserRightItem>();

            StringBuilder _sb = new StringBuilder();
            _sb.Append("SELECT zhtj_zzjg2.GETDWDM_hgjs(:DWID) dwdm,zhtj_zzjg2.GETDWMC(:DWID2) DWMC ");
            _sb.Append("FROM DUAL ");
            OracleParameter[] _param = {
                                new OracleParameter(":DWID", OracleDbType.Decimal),
                                new OracleParameter(":DWID2",OracleDbType.Decimal),
                           
                        };
            _param[0].Value = decimal.Parse(_adminPost.PostDwID);
            _param[1].Value = decimal.Parse(_adminPost.PostDwID);

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text,
                           _sb.ToString(), _param);

            while (dr.Read())
            {
                _adminPost.PostDWDM = dr.IsDBNull(0) ? "" : dr.GetString(0);
                _adminPost.PostDWMC = dr.IsDBNull(1) ? "" : dr.GetString(1);
            }
            dr.Close();

            //ȡȨ��
            DataTable _dt = GetUserRightsByYHID(_su.UserID, "");
            foreach (DataRow _row in _dt.Rows)
            {
                UserRightItem _rightItem = RightFunctions.CreateUserRightItem(_row);
                _adminPost.Rights.Add(_rightItem.Right.RightID, _rightItem);
            }
            _adminPost.SecretLevel = 1000;
            _su.Posts.Add(_adminPost);
            _su.DefaultPost = _adminPost;
            _su.CurrentPost = _adminPost;
            return _su;
        }


        /// <summary>
        /// ͨ���û�IDȡ�û���Ϣ
        /// </summary>
        /// <param name="_yhid"></param>
        /// <returns></returns>
        public static SinoUser GetUserInfoByYHID(string _yhid)
        {
            if (_yhid == "0") return C_GetUserInfo.GetAdminInfo();
            SinoUser _su = new SinoUser();
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                //ȡ�û���Ϣ
                DataTable _yhdt = new DataTable("YHTABLE");
                try
                {
                    StringBuilder _sb = new StringBuilder();
                    _sb.Append("SELECT a.yhm,a.dwid,a.xm,b.xdjb,b.aqjb,zhtj_zzjg2.GETDWDM_hgjs(a.dwid) dwdm,");
                    _sb.Append("(select jgqc from qx2_zzjg c where c.zzjgid = a.dwid) DWMC FROM qx2_yhxx a ,qx_tjyhb b ");
                    _sb.Append(" where a.yhid = b.yhid and a.yhid=:YHID ");
                    OracleCommand _cmd = new OracleCommand(_sb.ToString(), cn);
                    _cmd.Parameters.Add(":YHID", decimal.Parse(_yhid));
                    
                    OracleDataAdapter _adapter = new OracleDataAdapter(_cmd);
                    _adapter.Fill(_yhdt);
                }
                catch (Exception ex)
                {
                    SystemLogWriter.WriteLog(string.Format("ͨ��YHIDȡ�û���Ϣʧ�ܣ�YHID={0} ������Ϣ��{1}", _yhid, ex.Message), EventLogEntryType.Error);
                    throw;
                }

                if (_yhdt.Rows.Count < 1)
                {
                    //Ϊδע���û�
                    //throw new Exception(string.Format("�û���δ��ϵͳ��ע�ᣡ"));
                    return C_GetUserInfo.GetNoRegisterUserByUserID(decimal.Parse(_yhid));
                }

                try
                {
                    DataRow _dr = _yhdt.Rows[0];
                    _su.LoginName = _dr["YHM"].ToString();
                    _su.Dwdm = _dr["DWDM"].ToString();
                    _su.DwID = _dr["DWID"].ToString();
                    _su.DwName = _dr["DWMC"].ToString();
                    _su.UserID = _yhid;
                    _su.UserName = _dr["XM"].ToString();
                    _su.SecretLevel = _dr.IsNull("AQJB") ? 0 : int.Parse(_dr["AQJB"].ToString());
                    _su.QxszJB = ""; //�����޶��Ѿ����ã����ڴ���ʱ�ǰ��ո�λ���ڵļ���

                    //ȡ��λ��Ϣ
                    _su.Posts = C_GetGWInfo.Get_PostsByYHID(_su.UserID);
                    foreach (SinoPost _sp in _su.Posts)
                    {
                        _sp.Rights = C_GetGWInfo.GetRightsOfPost(_sp.PostID, "");
                        if (_sp.IsDefaultPost)
                        {
                            _su.DefaultPost = _sp;
                        }
                    }
                    if (_su.DefaultPost == null)
                    {
                        if (_su.Posts.Count > 0)
                        {
                            _su.DefaultPost = (SinoPost)_su.Posts[0];
                        }
                        else
                        {
                            _su.DefaultPost = new SinoPost();
                        }
                    }
                    _su.CurrentPost = _su.DefaultPost;
                }
                catch (Exception ex)
                {
                    SystemLogWriter.WriteLog(string.Format("ͨ��YHIDȡ�û��ĸ�λ��Ϣʧ�ܣ�YHID={0} ������Ϣ��{1}", _yhid, ex.Message), EventLogEntryType.Error);
                    throw;
                }
                cn.Close();
            }
            return _su;
        }




        /// <summary>
        /// ͨ���û���¼��ȡ�û���Ϣ
        /// </summary>
        /// <param name="_userName">�û���¼����</param>
        /// <returns></returns>
        public static SinoUser GetUserInfoByLoginName(string _userName)
        {
            if (_userName == "Administrator") return C_GetUserInfo.GetAdminInfo();
            SinoUser _su = new SinoUser();
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                //ȡ�û���Ϣ
                StringBuilder _sb = new StringBuilder();
                _sb.Append("SELECT a.yhm,a.yhid,a.dwid,a.xm,b.xdjb,b.aqjb,zhtj_zzjg2.GETDWDM_hgjs(a.dwid) dwdm,");
                _sb.Append("(select jgqc from qx2_zzjg c where c.zzjgid = a.dwid) DWMC FROM qx2_yhxx a ,qx_tjyhb b ");
                _sb.Append(" where a.yhid = b.yhid and a.yhm=:YHM ");
                OracleCommand _cmd = new OracleCommand(_sb.ToString(), cn);
                _cmd.Parameters.Add(":YHM", _userName);
                DataTable _yhdt = new DataTable("YHTABLE");
                OracleDataAdapter _adapter = new OracleDataAdapter(_cmd);
                _adapter.Fill(_yhdt);

                if (_yhdt.Rows.Count < 1)
                {
                    //Ϊδע���û�
                    throw new Exception(string.Format("�û���δ��ϵͳ��ע�ᣡ"));
                }

                DataRow _dr = _yhdt.Rows[0];
                _su.LoginName = _dr["YHM"].ToString();
                _su.Dwdm = _dr["DWDM"].ToString();
                _su.DwID = _dr["DWID"].ToString();
                _su.DwName = _dr["DWMC"].ToString();
                _su.UserID = _dr["YHID"].ToString();
                _su.UserName = _dr["XM"].ToString();
                _su.SecretLevel = _dr.IsNull("AQJB") ? 0 : int.Parse(_dr["AQJB"].ToString());
                _su.QxszJB = ""; //�����޶��Ѿ����ã����ڴ���ʱ�ǰ��ո�λ���ڵļ���

                //ȡ��λ��Ϣ
                _su.Posts = C_GetGWInfo.Get_PostsByYHID(_su.UserID);
                foreach (SinoPost _sp in _su.Posts)
                {
                    _sp.Rights = C_GetGWInfo.GetRightsOfPost(_sp.PostID, "");
                    if (_sp.IsDefaultPost)
                    {
                        _su.DefaultPost = _sp;
                    }
                }
                if (_su.DefaultPost == null)
                {
                    if (_su.Posts.Count > 0)
                    {
                        _su.DefaultPost = (SinoPost)_su.Posts[0];
                    }
                    else
                    {
                        _su.DefaultPost = new SinoPost();
                    }
                }
                _su.CurrentPost = _su.DefaultPost;
                cn.Close();
            }
            return _su;
        }

        /// <summary>
        /// ͨ���û�IDȡ�û�����Ϣ
        /// </summary>
        /// <param name="_yhid"></param>
        /// <returns></returns>
        public static SinoUser GetSimpleUserInfoByYHID(string _yhid)
        {
            SinoUser _su = new SinoUser();
            string _select1 = string.Format("SELECT a.yhm,a.dwid,a.xm,b.xdjb,b.aqjb,zhtj_zzjg2.GETDWDM_hgjs(a.dwid) dwdm,(select jgqc from qx2_zzjg c where c.zzjgid = a.dwid) DWMC FROM qx2_yhxx a ,qx_tjyhb b where a.yhid = b.yhid and a.yhid={0} ", _yhid);
            DataTable _yhdt = OracleHelper.Get_Data(_select1, "YHTABLE");
            if (_yhdt.Rows.Count < 1)
            {
                //Ϊδע���û�
                //return GetNoRegistUser(_yhid);
                throw new Exception(string.Format("�û���δ��ϵͳ��ע�ᣡ"));
            }

            DataRow _dr = _yhdt.Rows[0];
            _su.LoginName = _dr["YHM"].ToString();
            _su.Dwdm = _dr["DWDM"].ToString();
            _su.DwID = _dr["DWID"].ToString();
            _su.DwName = _dr["DWMC"].ToString();
            _su.UserID = _yhid;
            _su.UserName = _dr["XM"].ToString();
            _su.SecretLevel = _dr.IsNull("AQJB") ? 0 : int.Parse(_dr["AQJB"].ToString());
            string _xdjb = _dr["XDJB"].ToString();
            _su.QxszJB = _xdjb;

            return _su;
        }

        /// <summary>
        /// ͨ���û�IDȡ�û�Ȩ��
        /// </summary>
        /// <param name="_yhid"></param>
        /// <param name="_qxlx"></param>
        /// <returns></returns>
        private static DataTable GetUserRightsByYHID(string _yhid, string _qxlx)
        {
            DataTable _dt = new DataTable();
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleCommand _cmd = new OracleCommand();
                _cmd.CommandText = "zhtj_zzjg2.Get_YHCZQX_own";
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.Connection = cn;

                OracleParameter _p1 = _cmd.Parameters.Add("nYHID", OracleDbType.Decimal);
                _p1.Value = decimal.Parse(_yhid);

                OracleParameter _p2 = _cmd.Parameters.Add("strqxlx", OracleDbType.Varchar2, 1000);
                _p2.Value = _qxlx;

                _cmd.Parameters.Add("curQX", OracleDbType.RefCursor, DBNull.Value, ParameterDirection.Output);

                OracleDataAdapter _adapter = new OracleDataAdapter(_cmd);
                _adapter.Fill(_dt);
                cn.Close();
                return _dt;
            }
        }


        /// <summary>
        /// ͨ�����عغ�ȡ�û�ID
        /// </summary>
        /// <param name="_name">�û���</param>
        /// <param name="_pass">����</param>
        /// <returns></returns>
        public static string GetYHIDByHGGH(string _name, string _pass)
        {
            if (_name.Length < 7)
            {
                _name = _name.PadRight(7, '0');
            }
            string _select = string.Format("SELECT a.YHID FROM qx2_yhxx a where a.hggh = '{0}'", _name);
            DataTable _dt = OracleHelper.Get_Data(_select, "TABLE");
            if (_dt.Rows.Count != 1) return "";
            return _dt.Rows[0]["YHID"].ToString();
        }

        /// <summary>
        /// ͨ���û����ƺͿ���ȡ�û�ID
        /// </summary>
        /// <param name="_name">�û�����</param>
        /// <param name="_pass">�û�����</param>
        /// <returns></returns>
        public static string GetYHIDByName(string _name, string _pass)
        {
            string _select = string.Format("SELECT a.YHID FROM qx2_yhxx a where a.yhm = '{0}' or a.hggh ='{1}'", _name,
                               ((_name.Length < 7) ? _name.PadRight(7, '0') : _name));
            DataTable _dt = OracleHelper.Get_Data(_select, "TABLE");
            if (_dt == null || _dt.Rows.Count == 0)
            {
                OralceLogWriter.WriteSystemLog(string.Format("ȡδע���û�[{0}]��YHID��Ϣ", _name), "INFO");
                return "-1";
            }

            if (_dt.Rows.Count != 1)
            {
                throw new Exception(string.Format("ϵͳ�д���{1}����ͬ���û�����{0}���������Ա��ϵ��", _name, _dt.Rows.Count));
            }
            return _dt.Rows[0]["YHID"].ToString();
        }

        /// <summary>
        /// ȡ������
        /// </summary>
        /// <param name="_qxsjdwid">��λID</param>
        /// <param name="_levelNum">�㼶��</param>
        /// <returns></returns>
        public static DataTable Get_DwTree(string _qxsjdwid, decimal _levelNum)
        {
            DataTable _dt = new DataTable();
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleCommand _cmd = new OracleCommand();
                _cmd.CommandText = "zhtj_zzjg2.get_tree_js_qx";
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.Connection = cn;

                OracleParameter _p1 = _cmd.Parameters.Add("nParent", OracleDbType.Decimal);
                _p1.Value = decimal.Parse(_qxsjdwid);

                OracleParameter _p2 = _cmd.Parameters.Add("nLevel", OracleDbType.Decimal);
                _p2.Value = _levelNum;

                _cmd.Parameters.Add("curTree", OracleDbType.RefCursor, DBNull.Value, ParameterDirection.Output);

                OracleDataAdapter _adapter = new OracleDataAdapter(_cmd);
                _adapter.Fill(_dt);
                cn.Close();
            }
            return _dt;
        }

        /// <summary>
        /// ͨ��12λ��λ����ȡ������
        /// </summary>
        /// <param name="_dwdm">��λ����</param>
        /// <param name="_levelNum">�㼶��</param>
        /// <returns></returns>
        public static DataTable Get_DwTreeByDWDM(string _dwdm, decimal _levelNum)
        {
            DataTable _dt = new DataTable();
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleCommand _cmd = new OracleCommand();
                _cmd.CommandText = "zhtj_zzjg2.get_tree_js_dwdm";
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.Connection = cn;

                OracleParameter _p1 = _cmd.Parameters.Add("strparentdwdm", OracleDbType.Varchar2);
                _p1.Value = _dwdm;

                OracleParameter _p2 = _cmd.Parameters.Add("nLevel", OracleDbType.Decimal);
                _p2.Value = _levelNum;

                _cmd.Parameters.Add("curtree", OracleDbType.RefCursor, DBNull.Value, ParameterDirection.Output);

                OracleDataAdapter _adapter = new OracleDataAdapter(_cmd);
                _adapter.Fill(_dt);
                cn.Close();
            }
            return _dt;
        }

        /// <summary>
        /// ȡ�쵼�û�(ִ��������,�ݷ���)
        /// </summary>
        /// <param name="_dwid"></param>
        /// <param name="_levelNum"></param>
        /// <returns></returns>
        public static DataTable Get_ZFPG_LDYH_InNode(string _dwid, decimal _levelNum)
        {
            DataTable _dt = new DataTable();
            string _selectsql = "select a.*,b.yhm,b.xm,b.yjdz,b.ZZJGID,B.JGmc,b.zzjgdm from zfpg_kpz a,qx_yhxxst b where a.yhid = b.YHID and a.zfpgjb=:ZFPGJB";
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleCommand _cmd = new OracleCommand(_selectsql, cn);
                //��Ҫ�µĴ�������
                _cmd.CommandType = CommandType.Text;

                OracleParameter _p1 = _cmd.Parameters.Add(":ZFPGJB", OracleDbType.Varchar2);
                _p1.Value = _dwid;
                OracleDataAdapter _adapter = new OracleDataAdapter(_cmd);
                _adapter.Fill(_dt);

                cn.Close();
                return _dt;

            }
        }

        /// <summary>
        /// ȡָ����λ�µ��û�
        /// </summary>
        /// <param name="_dwid">��λID</param>
        /// <param name="_levelNum">�㼶��</param>
        /// <returns></returns>
        public static DataTable Get_YH_InNode(string _dwid, decimal _levelNum)
        {
            DataTable _dt = new DataTable();
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleCommand _cmd = new OracleCommand();
                //��Ҫ�µĴ�������
                _cmd.CommandText = "zhtj_zzjg2.Get_yhxx_JS_qx";
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.Connection = cn;

                OracleParameter _p1 = _cmd.Parameters.Add("nParent", OracleDbType.Decimal);
                _p1.Value = decimal.Parse(_dwid);

                OracleParameter _p2 = _cmd.Parameters.Add("nLevel", OracleDbType.Decimal);
                _p2.Value = _levelNum;

                _cmd.Parameters.Add("curyhxx", OracleDbType.RefCursor, DBNull.Value, ParameterDirection.Output);

                OracleDataAdapter _adapter = new OracleDataAdapter(_cmd);
                _adapter.Fill(_dt);

                cn.Close();
                return _dt;
            }
        }
        /// <summary>
        /// ȡ��ɫ�б�
        /// </summary>
        /// <returns></returns>
        public static DataTable Get_RoleList()
        {
            DataTable _dt = new DataTable("QX_JSDYB");
            string _selectsql = "select * from qx_jsdyb where (ssdwid is null) or (ssdwid = :QXID) ";
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleCommand _cmd = new OracleCommand(_selectsql, cn);
                _cmd.CommandType = CommandType.Text;
                _cmd.Parameters.Add(":QXID", decimal.Parse(SinoUserCtx.CurUser.QxszDWID));
                OracleDataAdapter _adapter = new OracleDataAdapter(_cmd);
                _adapter.Fill(_dt);
                cn.Close();
                return _dt;
            }

        }

        /// <summary>
        /// ȡָ����ɫ��Ȩ���б�
        /// </summary>
        /// <param name="_jsid">��ɫID</param>
        /// <returns></returns>
        public static DataTable Get_RightsByRoleID(string _jsid)
        {
            DataTable _dt = new DataTable();
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleCommand _cmd = new OracleCommand();
                //��Ҫ�µĴ�������
                _cmd.CommandText = "zhtj_zzjg2.get_jslb";
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.Connection = cn;

                OracleParameter _p1 = _cmd.Parameters.Add("njsid", OracleDbType.Decimal);
                _p1.Value = decimal.Parse(_jsid);

                _cmd.Parameters.Add("curqx", OracleDbType.RefCursor, DBNull.Value, ParameterDirection.Output);

                OracleDataAdapter _adapter = new OracleDataAdapter(_cmd);
                _adapter.Fill(_dt);

                cn.Close();
                return _dt;

            }

        }

        /// <summary>
        /// ȡָ����ɫ��Ȩ�޶�Ӧ��ͼ
        /// </summary>
        /// <param name="_jsid">��ɫID</param>
        /// <param name="spaces"></param>
        /// <returns></returns>
        public static DataTable Get_QVRightsByRoleID(string _jsid, string spaces)
        {
            DataTable _dt = new DataTable();
            StringBuilder _sb = new StringBuilder();
            _sb.Append("select t1.viewid,t1.namespace,t1.viewname,t1.displayname, ");
            _sb.Append("  (select DISPLAYTITLE from md_tbnamespace t2 where t2.namespace=t1.namespace) nstitle, ");
            _sb.Append(" case when t3.id is null then 0 else 1 end SFY ");
            _sb.Append(" from md_view t1 ");
            _sb.Append(" left join (select id,viewid from qx_jscxmxgxb where jsid = :JSID )t3 on t3.viewid = t1.viewid ");
            _sb.Append(" where t1.namespace in (");
            string _fg = "";
            foreach (string _s in spaces.Split(','))
            {
                _sb.Append(string.Format("{0}'{1}'", _fg, _s));
                _fg = ",";
            }
            _sb.Append(" ) ORDER BY T1.DISPLAYORDER ");
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleCommand _cmd = new OracleCommand(_sb.ToString(), cn);
                _cmd.CommandType = CommandType.Text;
                _cmd.Parameters.Add(":JSID", decimal.Parse(_jsid));
                OracleDataAdapter _adapter = new OracleDataAdapter(_cmd);
                _adapter.Fill(_dt);
                cn.Close();
                return _dt;
            }


        }

        /// <summary>
        /// ���½�ɫ����
        /// </summary>
        /// <param name="_savedt"></param>
        /// <returns></returns>
        public static bool Update_RoleData(DataTable _savedt)
        {
            string cmdStr = "SELECT * FROM QX_JSDYB";
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction tx = cn.BeginTransaction();
                OracleDataAdapter adapter = new OracleDataAdapter(cmdStr, cn);
                OracleCommandBuilder builder = new OracleCommandBuilder(adapter);
                adapter.Update(_savedt);
                tx.Commit();
                cn.Close();
            }
            return true;
        }

        /// <summary>
        /// ȡ�û��Ľ�ɫ
        /// </summary>
        /// <param name="yhid"></param>
        /// <returns></returns>
        public static ArrayList Get_RoleByYHID(string yhid)
        {
            string _sql = string.Format(" select a.jsid,a.jsmc,a.jssm,a.ssdwid from qx_yhjsgxb t,qx_jsdyb a ");
            _sql += string.Format("where a.jsid = t.jsid and yhid = {0}", yhid);
            DataTable _dt = OracleHelper.Get_Data(_sql, "ROLES");
            ArrayList roles = new ArrayList();
            foreach (DataRow _dr in _dt.Rows)
            {
                SinoRole _sr = RightFunctions.CreateRoleItem(_dr);
                roles.Add(_sr);
            }
            return roles;
        }

        /// <summary>
        /// ȡ�û���Ȩ��
        /// </summary>
        /// <param name="yhid"></param>
        /// <returns></returns>
        public static DataTable Get_RightsByYHID(string yhid)
        {
            DataTable _dt = new DataTable();
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleCommand _cmd = new OracleCommand();
                _cmd.CommandText = "zhtj_zzjg2.Get_YHCZQX";
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.Connection = cn;

                OracleParameter _p1 = _cmd.Parameters.Add("nYHID", OracleDbType.Decimal);
                _p1.Value = decimal.Parse(yhid);

                _cmd.Parameters.Add("curQX", OracleDbType.RefCursor, DBNull.Value, ParameterDirection.Output);

                OracleDataAdapter _adapter = new OracleDataAdapter(_cmd);
                _adapter.Fill(_dt);

                cn.Close();
                return _dt;

            }
        }

        /// <summary>
        /// Ϊ�û����ӽ�ɫ
        /// </summary>
        /// <param name="yhid"></param>
        /// <param name="_roles"></param>
        /// <returns></returns>
        public static bool Add_RoleToYH(string yhid, ArrayList _roles)
        {
            foreach (SinoRole _sr in _roles)
            {
                string _ins = string.Format("insert into qx_yhjsgxb (id,yhid,jsid) values (seq_qx2.nextval,{0},{1}) ", yhid, _sr.RoleID);
                OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _ins);
            }
            return true;
        }

        /// <summary>
        /// ɾ���û���ɫ
        /// </summary>
        /// <param name="yhid"></param>
        /// <param name="_jsid"></param>
        /// <returns></returns>
        public static bool Del_RoleFromYH(string yhid, string _jsid)
        {
            string _del = string.Format("delete from qx_yhjsgxb where yhid = {0} and jsid = {1} ", yhid, _jsid);
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _del);
            return true;
        }

        /// <summary>
        /// ȡָ����λ�µ���Ա��Ϣ
        /// </summary>
        /// <param name="_dwid">��λID</param>
        /// <param name="levelnum">�㼶��</param>
        /// <returns></returns>
        public static DataTable Get_RY_InNode(string _dwid, decimal levelnum)
        {
            DataTable _dt = new DataTable();
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleCommand _cmd = new OracleCommand();
                _cmd.CommandText = "zhtj_zzjg2.Get_ryxx_JS_qx";
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.Connection = cn;

                OracleParameter _p1 = _cmd.Parameters.Add("nParent", OracleDbType.Decimal);
                _p1.Value = decimal.Parse(_dwid);

                OracleParameter _p2 = _cmd.Parameters.Add("nLevel", OracleDbType.Decimal);
                _p2.Value = levelnum;

                _cmd.Parameters.Add("curryxx", OracleDbType.RefCursor, DBNull.Value, ParameterDirection.Output);

                OracleDataAdapter _adapter = new OracleDataAdapter(_cmd);
                _adapter.Fill(_dt);

                cn.Close();
                return _dt;
            }
        }

        /// <summary>
        /// �����û�
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_pass"></param>
        /// <param name="_userid"></param>
        /// <param name="_xm"></param>
        /// <param name="_des"></param>
        /// <returns></returns>
        public static bool Add_User(string _name, string _pass, string _userid, string _xm, string _des)
        {
            string _selectStr = string.Format("select count(*) from QX_TJYHB WHERE YHID ={0} and YHM = '{1}'", _userid, _name);
            Decimal i = (decimal)OracleHelper.ExecuteScalar(OracleHelper.ConnectionStringProfile, CommandType.Text, _selectStr);
            if (i > 0) return false;

            string _insertStr = string.Format("insert into QX_TJYHB (YHID,YHM,KL,XDJB,AQJB) values ({0},'{1}','{2}','���Ҽ�',0)", _userid, _name, _pass);
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _insertStr);
            return true;
        }

        /// <summary>
        /// ɾ���û�
        /// </summary>
        /// <param name="u_id"></param>
        /// <returns></returns>
        public static bool Del_YHByID(string u_id)
        {
            string _del = string.Format("delete from qx_yhjsgxb where yhid={0}", u_id);
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _del);

            _del = string.Format("delete from qx_yhqxb where yhid = {0}", u_id);
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _del);

            _del = string.Format("delete from qx_tjyhb where yhid = {0}", u_id);
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _del);
            return true;
        }

        /// <summary>
        /// �����û�����
        /// </summary>
        /// <param name="yhid"></param>
        /// <param name="_value"></param>
        /// <returns></returns>
        public static bool Update_YHJB(string yhid, string _value)
        {
            string _update = string.Format("update qx_tjyhb set xdjb = '{1}' where yhid = {0}", yhid, _value);
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _update);
            return true;
        }

        /// <summary>
        /// ���½�ɫȨ������
        /// </summary>
        /// <param name="QxData"></param>
        /// <param name="QvQxData"></param>
        /// <param name="_jsid"></param>
        /// <returns></returns>
        public static bool Update_RoleToRightData(DataTable QxData, DataTable QvQxData, string _jsid)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction tx = cn.BeginTransaction();
                string _del = "delete from qx_jsqxgxb where jsid =:JSID";
                OracleCommand _cmd = new OracleCommand(_del, cn);
                _cmd.Parameters.Add(":JSID", decimal.Parse(_jsid));
                _cmd.ExecuteNonQuery();

                foreach (DataRow _dr in QxData.Select("SFY =1"))
                {
                    string _jbstr = _dr.IsNull("QXJB") ? "null" : _dr["QXJB"].ToString();
                    string _ins = "insert into qx_jsqxgxb (ID,JSID,QXID,QXJB) values (seq_qx2.nextval,:JSID,:QXID,:QXJB)";
                    OracleCommand _cmd2 = new OracleCommand(_ins, cn);
                    _cmd2.Parameters.Add(":JSID", decimal.Parse(_jsid));
                    _cmd2.Parameters.Add(":QXID", decimal.Parse(_dr["QXID"].ToString()));
                    _cmd2.Parameters.Add(":QXJB", _jbstr);
                    _cmd2.ExecuteNonQuery();

                }
                string _delqv = string.Format("delete from qx_jscxmxgxb where jsid=:JSID", _jsid);
                _cmd = new OracleCommand(_delqv, cn);
                _cmd.Parameters.Add(":JSID", decimal.Parse(_jsid));
                _cmd.ExecuteNonQuery();

                foreach (DataRow _dr in QvQxData.Select("SFY=1"))
                {
                    string _ins = "insert into qx_jscxmxgxb (ID,JSID,NAMESPACE,VIEWID) values (seq_qx2.nextval,:JSID,:NAMESPACE,:VIEWID)";
                    OracleCommand _cmd2 = new OracleCommand(_ins, cn);
                    _cmd2.Parameters.Add(":JSID", decimal.Parse(_jsid));
                    _cmd2.Parameters.Add(":NAMESPACE", _dr["NAMESPACE"].ToString());
                    _cmd2.Parameters.Add(":VIEWID", decimal.Parse(_dr["VIEWID"].ToString()));
                    _cmd2.ExecuteNonQuery();
                }
                tx.Commit();
                cn.Close();
            }
            return true;
        }

        /// <summary>
        /// ���½�ɫȨ�޶�Ӧ������
        /// </summary>
        /// <param name="_jsid"></param>
        /// <param name="_jsmc"></param>
        /// <param name="_jssm"></param>
        /// <param name="QxData"></param>
        /// <param name="QvQxData"></param>
        /// <returns></returns>
        public static bool Update_RoleToRightData(string _jsid, string _jsmc, string _jssm, DataTable QxData, DataTable QvQxData)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction tx = cn.BeginTransaction();

                string _del = "delete from qx_jsqxgxb where jsid = :JSID";
                OracleCommand _cmd = new OracleCommand(_del, cn);
                _cmd.Parameters.Add(":JSID", decimal.Parse(_jsid));
                _cmd.ExecuteNonQuery();

                string _delqv = "delete from qx_jscxmxgxb where jsid=:JSID";
                _cmd = new OracleCommand(_delqv, cn);
                _cmd.Parameters.Add(":JSID", decimal.Parse(_jsid));
                _cmd.ExecuteNonQuery();

                string _update = string.Format("update qx_jsdyb set JSMC=:JSMC,JSSM=:JSSM where JSID=:JSID");
                OracleCommand _cmdupdate = new OracleCommand(_update, cn);
                _cmdupdate.Parameters.Add(":JSMC", _jsmc);
                _cmdupdate.Parameters.Add(":JSSM", _jssm);
                _cmdupdate.Parameters.Add(":JSID", decimal.Parse(_jsid));
                _cmdupdate.ExecuteNonQuery();

                foreach (DataRow _dr in QxData.Select("SFY =1"))
                {
                    string _jbstr = _dr.IsNull("QXJB") ? "null" : _dr["QXJB"].ToString();
                    string _ins = "insert into qx_jsqxgxb (ID,JSID,QXID,QXJB) values (seq_qx2.nextval,:JSID,:QXID,:QXJB)";
                    OracleCommand _cmd2 = new OracleCommand(_ins, cn);
                    _cmd2.Parameters.Add(":JSID", decimal.Parse(_jsid));
                    _cmd2.Parameters.Add(":QXID", decimal.Parse(_dr["QXID"].ToString()));
                    _cmd2.Parameters.Add(":QXJB", _jbstr);
                    _cmd2.ExecuteNonQuery();
                }

                foreach (DataRow _dr in QvQxData.Select("SFY=1"))
                {
                    string _ins = "insert into qx_jscxmxgxb (ID,JSID,NAMESPACE,VIEWID) values (seq_qx2.nextval,:JSID,:NAMESPACE,:VIEWID)";
                    OracleCommand _cmd2 = new OracleCommand(_ins, cn);
                    _cmd2.Parameters.Add(":JSID", decimal.Parse(_jsid));
                    _cmd2.Parameters.Add(":NAMESPACE", _dr["NAMESPACE"].ToString());
                    _cmd2.Parameters.Add(":VIEWID", decimal.Parse(_dr["VIEWID"].ToString()));
                    _cmd2.ExecuteNonQuery();
                }
                tx.Commit();
                cn.Close();
            }
            return true;
        }

        /// <summary>
        /// �����µĽ�ɫ
        /// </summary>
        /// <param name="_jsmc"></param>
        /// <param name="_ssdwid"></param>
        /// <returns></returns>
        public static bool Insert_NewRole(string _jsmc, string _ssdwid)
        {
            StringBuilder _insert = new StringBuilder();
            _insert.Append("insert into qx_jsdyb (jsid,jsmc,jssm,ssdwid) values ( ");
            _insert.Append(" seq_qx2.nextval,:JSMC,'', ");
            if (_ssdwid == "")
            {
                _insert.Append(" null)");
            }
            else
            {
                _insert.Append(_ssdwid);
            }
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleCommand _cmd = new OracleCommand(_insert.ToString(), cn);
                _cmd.Parameters.Add(":JSMC", _jsmc);
                _cmd.ExecuteNonQuery();
                cn.Close();
            }

            return true;
        }


        public static SinoUser GetNoRegisterUserByUserID(decimal _yhid)
        {
            SinoUser _su = new SinoUser();
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    StringBuilder _sb = new StringBuilder();
                    _sb.Append(" select yh.YHM,yh.YHID,yh.XM,jg.ZZJGID DWID,jg.ZZJGDM DWDM ,jg.JGQC DWMC from yw_qd_hbryxx hb ");
                    _sb.Append(" join QX2_HGJG jg on hb.PARENT_GUID= jg.DWGUID ");
                    _sb.Append(" join qx2_hgyh yh on hb.GUID=yh.YHGUID ");
                    _sb.Append(" where yh.YHID=:YHID and ROWNUM=1 ");

                    OracleCommand _cmd = new OracleCommand(_sb.ToString(), cn);
                    _cmd.Parameters.Add(":YHID", _yhid);

                    OracleDataReader dr = _cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        _su.LoginName = dr.IsDBNull(0) ? "" : dr.GetString(0);
                        _su.IsSignOn = true;
                        _su.Dwdm = dr.IsDBNull(4) ? "" : dr.GetString(4);
                        _su.DwID = dr.IsDBNull(3) ? "" : dr.GetDecimal(3).ToString();
                        _su.DwName = dr.IsDBNull(5) ? "" : dr.GetString(5);
                        _su.UserID = dr.IsDBNull(1) ? "" : dr.GetDecimal(1).ToString();
                        _su.UserName = dr.IsDBNull(2) ? "" : dr.GetString(2);
                        _su.SecretLevel = 0;
                        _su.QxszJB = ""; //�����޶��Ѿ����ã����ڴ���ʱ�ǰ��ո�λ���ڵļ���
                    }
                }
                catch (Exception ex)
                {
                    SystemLogWriter.WriteLog(string.Format("ͨ��YHIDȡ��ע���û���Ϣʧ�ܣ�YHID={0} ������Ϣ��{1}", _yhid, ex.Message), EventLogEntryType.Error);
                    throw;
                }

                try
                {
                    //ȡ��λ��Ϣ
                    _su.Posts = new List<SinoPost>();
                    SinoPost _sp = new SinoPost("δע���û���λ", "-1", _su.DwID, _su.DwName, _su.Dwdm, "δע���û���λ", 0, true);
                    _su.Posts.Add(_sp);
                    _sp.Rights = C_GetGWInfo.GetRightsOfPost("-1", "");
                    _su.DefaultPost = _sp;
                    _su.CurrentPost = _sp;
                }
                catch (Exception ex)
                {
                    SystemLogWriter.WriteLog(string.Format("ͨ��YHIDȡ��ע���û���λ��Ϣʧ�ܣ�YHID={0} ������Ϣ��{1}", _yhid, ex.Message), EventLogEntryType.Error);
                    throw;
                }
                cn.Close();
            }
            return _su;
        }

        public static SinoUser GetNoRegisterUserByUserName(string _name)
        {
            SinoUser _su = new SinoUser();
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                StringBuilder _sb = new StringBuilder();
                _sb.Append(" select yh.YHM,yh.YHID,yh.XM,jg.ZZJGID DWID,jg.ZZJGDM DWDM ,jg.JGQC DWMC from yw_qd_hbryxx hb ");
                _sb.Append(" join QX2_HGJG jg on hb.PARENT_GUID= jg.DWGUID ");
                _sb.Append(" join qx2_hgyh yh on hb.GUID=yh.YHGUID ");
                _sb.Append(" where hb.YHM=:LOGONNAME and ROWNUM=1 ");

                OracleCommand _cmd = new OracleCommand(_sb.ToString(), cn);
                _cmd.Parameters.Add(":LOGONNAME", _name);

                OracleDataReader dr = _cmd.ExecuteReader();
                while (dr.Read())
                {
                    _su.LoginName = _name;
                    _su.IsSignOn = true;
                    _su.Dwdm = dr.IsDBNull(4) ? "" : dr.GetString(4);
                    _su.DwID = dr.IsDBNull(3) ? "" : dr.GetDecimal(3).ToString();
                    _su.DwName = dr.IsDBNull(5) ? "" : dr.GetString(5);
                    _su.UserID = dr.IsDBNull(1) ? "" : dr.GetDecimal(1).ToString();
                    _su.UserName = dr.IsDBNull(2) ? "" : dr.GetString(2);
                    _su.SecretLevel = 0;
                    _su.QxszJB = ""; //�����޶��Ѿ����ã����ڴ���ʱ�ǰ��ո�λ���ڵļ���
                }

                //ȡ��λ��Ϣ
                _su.Posts = new List<SinoPost>();
                SinoPost _sp = new SinoPost("δע���û���λ", "0", _su.DwID, _su.DwName, _su.Dwdm, "δע���û���λ", 0, true);
                _su.Posts.Add(_sp);
                _sp.Rights = C_GetGWInfo.GetRightsOfPost("-1", "");
                _su.DefaultPost = _sp;
                _su.CurrentPost = _sp;
                cn.Close();
            }
            return _su;
        }
    }
}