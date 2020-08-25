﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Models.PickandPack
{
    public class PickandPackDetails : IFill
    {
        public int mothersId { get; set; }
        public string motherName { get; set; }
        public string motherSubjectId { get; set; }
        public string motherRCHID { get; set; }
        public string infantSubjectId { get; set; }
        public string infantName { get; set; }
        public string sampleCollectionDateTime { get; set; }
        public string barcodeNo { get; set; }
      

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MID"))
                this.mothersId = Convert.ToInt32(reader["MID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MotherName"))
                this.motherName = Convert.ToString(reader["MotherName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MotherSubjectId"))
                this.motherSubjectId = Convert.ToString(reader["MotherSubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectId"))
                this.infantSubjectId = Convert.ToString(reader["UniqueSubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "InfantName"))
                this.infantName = Convert.ToString(reader["InfantName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleDateTime"))
                this.sampleCollectionDateTime = Convert.ToString(reader["SampleDateTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RCHID"))
                this.motherRCHID = Convert.ToString(reader["RCHID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BarcodeNo"))
                this.barcodeNo = Convert.ToString(reader["BarcodeNo"]);
        }
    }
}
