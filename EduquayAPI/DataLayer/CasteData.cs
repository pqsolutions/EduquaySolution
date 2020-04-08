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
    public class CasteData : ICasteData
    {
        private const string FetchCastes = "SPC_FetchAllCaste";
        private const string FetchCaste = "SPC_FetchCaste";
        private const string AddCaste = "SPC_AddCaste";
        public CasteData()
        {


        }

        public string Add(CasteRequest cData)
        {
            try
            {
                string stProc = AddCaste;
                var retVal = new SqlParameter("@Scope_output", 1);
                retVal.Direction = ParameterDirection.Output;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@Castename",  cData.Castename   ??  cData.Castename),
                    new SqlParameter("@Isactive",  cData.IsActive ??  cData.IsActive),
                    new SqlParameter("@Comments",  cData.Comments ??  cData.Comments),
                    new SqlParameter("@Createdby",  cData.CreatedBy),
                    new SqlParameter("@Updatedby",  cData.UpdatedBy),

                    retVal
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
                return "Caste added successfully";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Caste> Retrieve(int code)
        {
            string stProc = FetchCaste;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", code) };
            var allData = UtilityDL.FillData<Caste>(stProc, pList);
            return allData;
        }

        public List<Caste> Retrieve()
        {
            string stProc = FetchCastes;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<Caste>(stProc, pList);
            return allData;
        }
    }

}
