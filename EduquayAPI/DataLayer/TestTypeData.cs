﻿using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer
{
    public class TestTypeData : ITestTypeData
    {
        private const string FetchTestTypes = "SPC_FetchAllTestType";
        private const string FetchTestType = "SPC_FetchTestType";
        private const string AddTestType = "SPC_AddTestType";
        public TestTypeData()
        {

        }
        public string Add(TestTypeRequest ttData)
        {
            try
            {
                string stProc = AddTestType;
                var retVal = new SqlParameter("@Scope_output", 1);
                retVal.Direction = ParameterDirection.Output;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@TestType", ttData.TestTypeName ?? ttData.TestTypeName),
                    new SqlParameter("@Isactive", ttData.Isactive ?? ttData.Isactive),
                    new SqlParameter("@Comments", ttData.Comments ?? ttData.Comments),
                    new SqlParameter("@Createdby", ttData.Createdby),
                    new SqlParameter("@Updatedby", ttData.Updatedby),

                    retVal
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
                return "Test Type added successfully";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<TestType> Retrieve(int code)
        {
            string stProc = FetchTestType;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", code) };
            var allData = UtilityDL.FillData<TestType>(stProc, pList);
            return allData;
        }

        public List<TestType> Retrieve()
        {
            string stProc = FetchTestTypes;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<TestType>(stProc, pList);
            return allData;
        }
    }
}
