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
                    new SqlParameter("@TestTypeID", tData.testTypeID),
                    new SqlParameter("@TestName", tData.testName ?? tData.testName),
                    new SqlParameter("@ThresholdValue", tData.thresholdValue),
                    new SqlParameter("@Isactive", tData.isActive ?? tData.isActive),
                    new SqlParameter("@Comments", tData.comments ?? tData.comments),
                    new SqlParameter("@Createdby", tData.createdBy),
                    new SqlParameter("@Updatedby", tData.updatedBy),

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
