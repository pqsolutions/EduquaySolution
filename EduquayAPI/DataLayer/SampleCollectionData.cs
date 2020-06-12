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
    public class SampleCollectionData : ISampleCollectionData
    {
        private const string FetchSubjectNotSampleCollected = "SPC_FetchSubjectNotSampleCollected";
        private const string AddSampleCollection = "SPC_AddSampleCollection";
       

        public SampleCollectionData()
        {

        }

        public string AddSample(AddSubjectSampleRequest ssData)
        {
            try
            {
                string stProc = AddSampleCollection;
                var retVal = new SqlParameter("@Scope_output", 1);
                retVal.Direction = ParameterDirection.Output;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@SubjectID", ssData.SubjectID),
                    new SqlParameter("@UniqueSubjectID", ssData.UniqueSubjectID ?? ssData.UniqueSubjectID),
                    new SqlParameter("@BarcodeNo", ssData.BarcodeNo  ?? ssData.BarcodeNo),
                    new SqlParameter("@SampleCollectionDate", ssData.SampleCollectionDate ?? ssData.SampleCollectionDate),
                    new SqlParameter("@SampleCollectionTime", ssData.SampleCollectionTime ?? ssData.SampleCollectionTime),
                    new SqlParameter("@Reason_Id", ssData.Reason_Id),
                    new SqlParameter("@CollectionFrom", ssData.CollectionFrom),
                    new SqlParameter("@CollectedBy", ssData.CollectedBy),
                    new SqlParameter("@Createdby", ssData.CreatedBy),
                    retVal
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
                return "Subject samples added successfully";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<SubjectSamples> Retrieve(SubjectSampleRequest ssData)
        {
            string stProc = FetchSubjectNotSampleCollected;
            var pList = new List<SqlParameter>() 
            {
                new SqlParameter("@UserID", ssData.UserID),
                new SqlParameter("@FromDate", ssData.FromDate ?? ssData.FromDate ),
                new SqlParameter("@ToDate", ssData.ToDate  ?? ssData.ToDate),
                new SqlParameter("@SubjectType", ssData.SubjectType),
                new SqlParameter("@RegisteredFrom", ssData.RegisteredFrom ?? ssData.RegisteredFrom),
            };
            var allData = UtilityDL.FillData<SubjectSamples>(stProc, pList);
            return allData;
        }
    }
}
