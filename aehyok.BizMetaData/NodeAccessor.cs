using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSZJS.Base.MetaData.Define;
using System.Data.SqlClient;
using SinoSZJS.DataAccess.Sql;
using System.Data;
using aehyok.Dapper;

namespace aehyok.BizMetaData
{
    public class NodeAccessor
    {
        /// <summary>
        /// 查询数据库中所有的节点信息（MD_Nodes）
        /// </summary>
        private const string SqlGetNodeList = @"SELECT ID,NODENAME,DISPLAYTITLE,DESCRIPT,DWDM FROM MD_NODES";
        public static IList<MD_Nodes> GetNodeList()
        {
            //SqlDataReader sqlDataReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.Text, SqlGetNodeList);
            //IList<MD_Nodes> nodeItems = new List<MD_Nodes>();
            //while (sqlDataReader.Read())
            //{
            //    MD_Nodes nodeInfo = new MD_Nodes(sqlDataReader.GetString(0), sqlDataReader.GetString(1), sqlDataReader.GetString(2), sqlDataReader.GetString(3), sqlDataReader.GetString(4));
            //    nodeItems.Add(nodeInfo);
            //}
            //sqlDataReader.Close();
            //return nodeItems;

            IDbConnection conn = new SqlConnection(SqlHelper.ConnectionStringProfile);
            return conn.Query<MD_Nodes>(SqlGetNodeList).ToList();
        }

        /// <summary>
        /// 修改节点信息
        /// </summary>
        /// <param name="_nodes"></param>
        /// <returns></returns>
        private const string SqlUpdateNode = @"update MD_NODES set NODENAME=@NODENAME,DISPLAYTITLE=@DISPLAYTITLE,DESCRIPT=@DESCRIPT,DWDM=@DWDM where ID = @ID";
        public static bool SaveNodes(MD_Nodes mdNode)
        {
            //SqlParameter[] _param = {
            //                    new SqlParameter("@NODENAME", SqlDbType.NVarChar, 100),
            //                    new SqlParameter("@DISPLAYTITLE", SqlDbType.NVarChar, 200),
            //                    new SqlParameter("@DESCRIPT", SqlDbType.NVarChar, 2000),
            //                    new SqlParameter("@DWDM", SqlDbType.NVarChar, 100),
            //                     new SqlParameter("@ID", SqlDbType.NVarChar, 100)
            //            };
            //_param[0].Value = mdNode.NodeName;
            //_param[1].Value = mdNode.DisplayTitle;
            //_param[2].Value = mdNode.Descript;
            //_param[3].Value = mdNode.DWDM;
            //_param[4].Value = mdNode.ID;

            //SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, SqlUpdateNode, _param);
            //return true;
            IDbConnection conn = new SqlConnection(SqlHelper.ConnectionStringProfile);
            conn.Execute(SqlUpdateNode, mdNode);
            return true;
        }

        /// <summary>
        /// 新增节点信息
        /// </summary>
        /// <param name="_nodes"></param>
        /// <returns></returns>
        public static bool AddNewNode(MD_Nodes node)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append("insert into  MD_NODES (ID,NODENAME,DISPLAYTITLE,DESCRIPT,DWDM) ");
            _sb.Append(" values (@ID,@NODENAME,@DISPLAYTITLE,@DESCRIPT,@DWDM) ");
            SqlParameter[] _param = {
                                 new SqlParameter("@ID", SqlDbType.NVarChar, 100),
                                new SqlParameter("@NODENAME", SqlDbType.NVarChar, 100),
                                new SqlParameter("@DISPLAYTITLE", SqlDbType.NVarChar, 200),
                                new SqlParameter("@DESCRIPT", SqlDbType.NVarChar, 2000),
                                new SqlParameter("@DWDM", SqlDbType.NVarChar, 100)       
                        };
            _param[0].Value = node.ID;
            _param[1].Value = node.NodeName;
            _param[2].Value = node.DisplayTitle;
            _param[3].Value = node.Descript;
            _param[4].Value = node.DWDM;

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);
            return true;
        }


        private const string SQL_DelNodes = @"delete  MD_NODES where ID=@ID ";
        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="_nodeID"></param>
        /// <returns></returns>
        public static bool DelelteNode(string _nodeID)
        {
            SqlParameter[] _param = {
                                 new SqlParameter("@ID", SqlDbType.NVarChar, 100)   
                        };
            _param[0].Value = _nodeID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, SQL_DelNodes, _param);
            return true;
        }
    }
}
