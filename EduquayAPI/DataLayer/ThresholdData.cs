using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer
{
    public class ThresholdData : IThresholdData
    {
        private const string FetchThresholdValues = "SPC_FetchAllThresholdValue";
        private const string FetchThresholdValue = "SPC_FetchThresholdValue";
        private const string AddThresholdValue = "SPC_AddThresholdValue";
        public ThresholdData()
        {

        }
        public string Add(ThresholdRequest tData)
        {
            try
            {
                string stProc = AddThresholdValue;
                var retVal = new SqlParameter("@Scope_output", 1);
                retVal.Direction = ParameterDirection.Output;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@TestTypeID", tData.TestTypeID),
                    new SqlParameter("@TestName", tData.TestName ?? tData.TestName),
                    new SqlParameter("@ThresholdValue", tData.ThresholdValue),
                    new SqlParameter("@Isactive", tData.Isactive ?? tData.Isactive),
                    new SqlParameter("@Comments", tData.Comments ?? tData.Comments),
                    new SqlParameter("@Createdby", tData.Createdby),
                    new SqlParameter("@Updatedby", tData.Updatedby),

                    retVal
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
                return "Threshold added successfully";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Threshold> Retrieve(int code)
        {
            string stProc = FetchThresholdValue;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", code) };
            var allData = UtilityDL.FillData<Threshold>(stProc, pList);
            return allData;
        }

        public List<Threshold> Retrieve()
        {
            string stProc = FetchThresholdValues;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<Threshold>(stProc, pList);
            return allData;
        }
    }
}
