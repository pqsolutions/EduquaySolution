﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Models.Shipment
{
    public class ShipmentDetail:IFill
    {
        public int shipmentId { get; set; }
        public string babyName { get; set; }
        public string babySubjectId { get; set; }
        public string babyDOB { get; set; }
        public string gender { get; set; }
        public string motherRCHID { get; set; }
        public string motherSubjectId { get; set; }
        public string motherHospitalNo { get; set; }
        public string motherName { get; set; }
        public string fatherName { get; set; }
        public string barcodeNo { get; set; }
        public string sampleCollectionDateTime { get; set; }


        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentId"))
                this.shipmentId = Convert.ToInt32(reader["ShipmentId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BabyName"))
                this.babyName = Convert.ToString(reader["BabyName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BabySubjectId"))
                this.babySubjectId = Convert.ToString(reader["BabySubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DateOfBirth"))
                this.babyDOB = Convert.ToString(reader["DateOfBirth"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Gender"))
                this.gender = Convert.ToString(reader["Gender"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RCHID"))
                this.motherRCHID = Convert.ToString(reader["RCHID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MotherSubjectId"))
                this.motherSubjectId = Convert.ToString(reader["MotherSubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MotherHospitalNo"))
                this.motherHospitalNo = Convert.ToString(reader["MotherHospitalNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "FatherName"))
                this.fatherName = Convert.ToString(reader["FatherName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Barcode"))
                this.barcodeNo = Convert.ToString(reader["Barcode"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MotherName"))
                this.motherName = Convert.ToString(reader["MotherName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleCollectionDateTime"))
                this.sampleCollectionDateTime = Convert.ToString(reader["SampleCollectionDateTime"]);

        }
    }
}
