using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EduquayAPI.DataLayer
{
    public class PatientData: IPatientData
    {
        private const string GetAllpatients = "SPC_FetchAllPatients";
        private const string Fetchpatient = "SPC_FetchPatient";      
        private const string AddPatient = "SPC_AddPatient";
        public PatientData()
        {
            
        }

        public List<Patient> GetPatients()
        {
            string stProc = GetAllpatients;           
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<Patient>(stProc, pList);
            return allData;
        }

        public List<Patient> GetPatient(int pId)
        {
            //changes 18 march
            string stProc = Fetchpatient;         
            var pList = new List<SqlParameter>() { new SqlParameter("@GID", pId)};
            var allData = UtilityDL.FillData<Patient>(stProc, pList);
            return allData;
        }

        public string Add(Patient patient)
        {
            try
            {
                string stProc = AddPatient;
                var retVal = new SqlParameter("@SCOPE_OUTPUT", 1) {Direction = ParameterDirection.Output};
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@GID", patient.GovtId),
                    new SqlParameter("@FIRSTNAME", patient.FirstName ?? patient.FirstName),
                    new SqlParameter("@LASTNAME", patient.LastName ?? patient.LastName),
                    new SqlParameter("@LOCATION", patient.Location ?? patient.Location),
                    retVal
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
                return "Patient added successfully";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

      
    }
}
