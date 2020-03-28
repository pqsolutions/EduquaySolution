using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models
{
    public interface IFill
    {
        void Fill(SqlDataReader reader);
    }
}
