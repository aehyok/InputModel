using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSZJS.Base.MetaData.Define;
using System.Data.SqlClient;
using System.Data;
using SinoSZJS.DataAccess.Sql;
using aehyok.Dapper;

namespace aehyok.BizMetaData
{
    public class NameSpaceAccessor
    {
        /// <summary>
        /// 获取节点下面的所有命名空间
        /// </summary>
        private const string SqlGetNameSpaceAtNode = @"SELECT NAMESPACE,DESCRIPTION,MENUPOSITION,DISPLAYTITLE,OWNER,DISPLAYORDER,DWDM,CONCEPTS FROM MD_TBNAMESPACE
                                                        where DWDM = @DWDM order by DISPLAYORDER ASC";
        public static IList<MD_Namespace> GetNameSpace(string nodeCode)
        {
            SqlParameter[] sqlParameter = {
                                new SqlParameter("@DWDM", SqlDbType.NVarChar, 12),
                        };
            sqlParameter[0].Value = nodeCode;

            //SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.Text, SqlGetNameSpaceAtNode, sqlParameter);

            //IList<MD_Namespace> nodeItems = new List<MD_Namespace>();

            //while (dr.Read())
            //{
            //    MD_Namespace nodeInfo = new MD_Namespace();
            //    nodeInfo.NameSpace = dr.GetString(0);
            //    nodeInfo.Description = dr.IsDBNull(1) ? "" : dr.GetString(1);
            //    nodeInfo.MenuPosition = dr.IsDBNull(2) ? "" : dr.GetString(2);
            //    nodeInfo.DisplayTitle = dr.IsDBNull(3) ? "" : dr.GetString(3);
            //    nodeInfo.Owner = dr.IsDBNull(4) ? "" : dr.GetString(4);
            //    nodeInfo.DisplayOrder = dr.IsDBNull(5) ? 0 : Convert.ToInt32(dr.GetDouble(5));
            //    nodeInfo.DWDM = dr.IsDBNull(6) ? "" : dr.GetString(6);
            //    nodeInfo.Concepts = dr.IsDBNull(7) ? "" : dr.GetString(7);
            //    nodeItems.Add(nodeInfo);
            //}
            //dr.Close();
            //return nodeItems;
            IDbConnection conn = new SqlConnection(SqlHelper.ConnectionStringProfile);
            return conn.Query<MD_Namespace>(SqlGetNameSpaceAtNode, new { DWDM=nodeCode }).ToList();
        }

        /// <summary>
        /// 修改命名空间
        /// </summary>
        /// <param name="_ns"></param>
        /// <returns></returns>
        public static bool UpdateNameSapce(MD_Namespace nameSpace)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append("update MD_TBNAMESPACE set DESCRIPTION = @DESCRIPTION,MENUPOSITION=@MENUPOSTION,");
            _sb.Append(" DISPLAYTITLE = @DISPLAYTITLE,OWNER = @OWNER,DISPLAYORDER =@DISPLAYORDER,DWDM =@DWDM,CONCEPTS =@CONCEPTS ");
            _sb.Append(" where NAMESPACE =@NAMESPACE");
            SqlParameter[] _param = {                                
                                new SqlParameter("@DESCRIPTION", SqlDbType.NVarChar, 100),
                                new SqlParameter("@MENUPOSTION", SqlDbType.NVarChar, 50),
                                new SqlParameter("@DISPLAYTITLE", SqlDbType.NVarChar, 50),
                                new SqlParameter("@OWNER", SqlDbType.NVarChar, 50),
                                new SqlParameter("@DISPLAYORDER", SqlDbType.Decimal),
                                new SqlParameter("@DWDM", SqlDbType.NVarChar, 12),
                                new SqlParameter("@CONCEPTS", SqlDbType.NVarChar, 1000),
                                new SqlParameter("@NAMESPACE", SqlDbType.NVarChar, 50)                         
                        };

            _param[0].Value = nameSpace.Description;
            _param[1].Value = nameSpace.MenuPosition;
            _param[2].Value = nameSpace.DisplayTitle;
            _param[3].Value = nameSpace.Owner;
            _param[4].Value = nameSpace.DisplayOrder;
            _param[5].Value = nameSpace.DWDM;
            _param[6].Value = nameSpace.Concepts;
            _param[7].Value = nameSpace.NameSpace;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);
            return true;
        }

        private const string SqlDeleteNamespace = "delete MD_TBNAMESPACE where NAMESPACE=@NAMESPACE  ";
        /// <summary>
        /// 删除命名空间
        /// </summary>
        /// <param name="_ns"></param>
        /// <returns></returns>
        public static bool DelelteNamespace(MD_Namespace _ns)
        {
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                SqlTransaction txn = cn.BeginTransaction();
                try
                {
                    SqlParameter[] _param = {
                                                         new SqlParameter("@NAMESPACE", SqlDbType.NVarChar, 100)   
                                                };
                    _param[0].Value = _ns.NameSpace;
                    SqlHelper.ExecuteNonQuery(cn, CommandType.Text, SqlDeleteNamespace, _param);
                    txn.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    txn.Rollback();
                    return false;
                }
            }
        }

        /// <summary>
        /// 添加新的命名空间
        /// </summary>
        /// <param name="_ns"></param>
        /// <returns></returns>
        public static bool AddNewNameSapce(MD_Namespace _ns)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append("insert into  MD_TBNAMESPACE (NAMESPACE,DESCRIPTION,MENUPOSITION,DISPLAYTITLE,OWNER,DISPLAYORDER,DWDM,CONCEPTS) ");
            _sb.Append(" values (@NAMESPACE,@DESCRIPTION,@MENUPOSITION,@DISPLAYTITLE,@OWNER,@DISPLAYORDER,@DWDM,@CONCEPTS) ");
            SqlParameter[] _param = {
                                 new SqlParameter("@NAMESPACE", SqlDbType.NVarChar, 50),
                                new SqlParameter("@DESCRIPTION", SqlDbType.NVarChar, 100),
                                new SqlParameter("@MENUPOSITION", SqlDbType.NVarChar, 50),
                                new SqlParameter("@DISPLAYTITLE", SqlDbType.NVarChar, 50),
                                new SqlParameter("@OWNER", SqlDbType.NVarChar, 50),
                                new SqlParameter("@DISPLAYORDER", SqlDbType.Decimal),
                                new SqlParameter("@DWDM", SqlDbType.NVarChar, 12),
                                new SqlParameter("@CONCEPTS", SqlDbType.NVarChar, 1000)
                        };
            _param[0].Value = _ns.NameSpace;
            _param[1].Value = _ns.Description;
            _param[2].Value = _ns.MenuPosition;
            _param[3].Value = _ns.DisplayTitle;
            _param[4].Value = _ns.Owner;
            _param[5].Value = _ns.DisplayOrder;
            _param[6].Value = _ns.DWDM;
            _param[7].Value = _ns.Concepts;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);
            return true;
        }
    }
}
