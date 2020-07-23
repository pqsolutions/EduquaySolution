using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.LoadMasters
{
    public class AssociatedSCRIANM : IFill
    {
        public int scId { get; set; }
        public string scName { get; set; }
        public string scAddress { get; set; }
        public string scPincode { get; set; }
        public int riId { get; set; }
        public string riPoint { get; set; }
        public int associatedANMId { get; set; }
        public string anmName { get; set; }
        public string anmContactNo { get; set; }
        public int testingCHCId { get; set; }
        public string testingCHC { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SCID"))
                this.scId = Convert.ToInt32(reader["SCID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SCName"))
                this.scName = Convert.ToString(reader["SCName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SCAddress"))
                this.scAddress = Convert.ToString(reader["SCAddress"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Pincode"))
                this.scPincode = Convert.ToString(reader["Pincode"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RIID"))
                this.riId = Convert.ToInt32(reader["RIID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RIPoint"))
                this.riPoint = Convert.ToString(reader["RIPoint"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "AssignANMID"))
                this.associatedANMId = Convert.ToInt32(reader["AssignANMID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANMName"))
                this.anmName = Convert.ToString(reader["ANMName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ContactNo"))
                this.anmContactNo = Convert.ToString(reader["ContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "TestingCHCID"))
                this.testingCHCId = Convert.ToInt32(reader["TestingCHCID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "TestingCHC"))
                this.testingCHC = Convert.ToString(reader["TestingCHC"]);
        }
    }
}
