using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace SinoSZJS.DataAccess.Sql
{
    public abstract class SqlHelper
    {
        /// <summary>
        /// 从配置文件中取得到SQL数据库连接字串.
        /// 连接字串放于configuration - connectionStrings 节下,示例
        /// </summary>
        public static readonly string ConnectionStringProfile = ConfigurationManager.ConnectionStrings["SQLProfileConnString"].ConnectionString;

        /// <summary>
        /// 打开一个ORACLE连接
        /// </summary>
        /// <returns></returns>
        public static SqlConnection OpenConnection()
        {
            SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringProfile);
            conn.Open();
            return conn;
        }
    }
}
