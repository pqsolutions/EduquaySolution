using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models
{
    public class ClinicalDiagnosis :IFill
    {
        public int ID { get; set; }
        public string DiagnosisName { get; set; }      
        public int Createdby { get; set; }     
        public int Updatedby { get; set; }
        public string Comments { get; set; }
        public string Isactive { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.ID = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DiagnosisName"))
                this.DiagnosisName = Convert.ToString(reader["DiagnosisName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Isactive"))
                this.Isactive = Convert.ToString(reader["Isactive"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Comments"))
                this.Comments = Convert.ToString(reader["Comments"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Createdby"))
                this.Createdby = Convert.ToInt32(reader["Createdby"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Updatedby"))
                this.Updatedby = Convert.ToInt32(reader["Updatedby"]);
        }
    }
}
