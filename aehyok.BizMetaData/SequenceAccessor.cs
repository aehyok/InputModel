using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using SinoSZJS.DataAccess.Sql;

namespace aehyok.BizMetaData
{
    public class SequenceAccessor
    {
        public static string GetNewId()
        {
            string flag = string.Empty;
            using (SqlConnection conn = SqlHelper.OpenConnection())
            {
                var obj = SqlHelper.ExecuteScalar(conn, CommandType.Text, "select next value for GetSequence");
                flag = obj.ToString();
            }
            return flag;
        }
    }
}
