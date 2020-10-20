using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Models.Masters.User
{
    public class MsgDetail : IFill
    {
        public string msg { get; set; }
        public bool msgRespone { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MSG"))
                this.msg = Convert.ToString(reader["MSG"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MsgResponse"))
                this.msgRespone = Convert.ToBoolean(reader["MsgResponse"]);
        }
    }
}
