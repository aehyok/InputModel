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
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "GetSequence";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlParameter p6 = cmd.Parameters.Add("@value", SqlDbType.Decimal);
                p6.Direction = ParameterDirection.Output;

                cmd.ExecuteScalar();
                flag = p6.Value.ToString();
            }
            return flag;
        }
    }
}
