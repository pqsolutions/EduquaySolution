﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MolecularLab
{
    public class MolecularSubjectsForTest : IFill
    {
        public string subjectName { get; set; }
        public string uniqueSubjectId { get; set; }
        public string subjectType { get; set; }
        public string rchId { get; set; }
        public string age { get; set; }
        public string gender { get; set; }
        public string dob { get; set; }
        public string contactNo { get; set; }
        public string ecNumber { get; set; }
        public string lmpDate { get; set; }
        public string ga { get; set; }
        public string obstetricScore { get; set; }
        public string barcodeNo { get; set; }
        public string district { get; set; }
        public string cbcResult { get; set; }
        public string mcv { get; set; }
        public string rdw { get; set; }
        public string sstResult { get; set; }
        public string hplcResult { get; set; }
        public string hbA0 { get; set; }
        public string hbA2 { get; set; }
        public string hbC { get; set; }
        public string hbD { get; set; }
        public string hbF { get; set; }
        public string hbS { get; set; }
        public string hplcDiagnosis { get; set; }


        public void Fill(SqlDataReader reader)
        {

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectName"))
                this.subjectName = Convert.ToString(reader["SubjectName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectType"))
                this.subjectType = Convert.ToString(reader["SubjectType"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.uniqueSubjectId = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RCHID"))
                this.rchId  = Convert.ToString(reader["RCHID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ContactNo"))
                this.contactNo = Convert.ToString(reader["ContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ECNumber"))
                this.ecNumber = Convert.ToString(reader["ECNumber"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "LMPDate"))
                this.lmpDate = Convert.ToString(reader["LMPDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GestationalAge"))
                this.ga = Convert.ToString(reader["GestationalAge"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ObstetricScore"))
                this.obstetricScore = Convert.ToString(reader["ObstetricScore"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Age"))
                this.age = Convert.ToString(reader["Age"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Gender"))
                this.gender = Convert.ToString(reader["Gender"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DOB"))
                this.dob = Convert.ToString(reader["DOB"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BarcodeNo"))
                this.barcodeNo = Convert.ToString(reader["BarcodeNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Districtname"))
                this.district = Convert.ToString(reader["Districtname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CBCResult"))
                this.cbcResult = Convert.ToString(reader["CBCResult"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MCV"))
                this.mcv = Convert.ToString(reader["MCV"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RDW"))
                this.rdw = Convert.ToString(reader["RDW"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SSTResult"))
                this.sstResult = Convert.ToString(reader["SSTResult"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HPLCTestResult"))
                this.hplcResult = Convert.ToString(reader["HPLCTestResult"]);


            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HbA0"))
                this.hbA0 = Convert.ToString(reader["HbA0"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HbA2"))
                this.hbA2 = Convert.ToString(reader["HbA2"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HbC"))
                this.hbC = Convert.ToString(reader["HbC"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HbD"))
                this.hbD = Convert.ToString(reader["HbD"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HbF"))
                this.hbF = Convert.ToString(reader["HbF"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HbS"))
                this.hbS = Convert.ToString(reader["HbS"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HPLCDiagnosis"))
                this.hplcDiagnosis = Convert.ToString(reader["HPLCDiagnosis"]);

        }
    }
}