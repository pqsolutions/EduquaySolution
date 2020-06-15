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
        private const string FetchANMCHCSampleSubjectDetail = "SPC_FetchANMCHCSampleSubjectDetail";


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
                    new SqlParameter("@SubjectID", ssData.subjectId),
                    new SqlParameter("@UniqueSubjectID", ssData.uniqueSubjectId ?? ssData.uniqueSubjectId),
                    new SqlParameter("@BarcodeNo", ssData.barcodeNo  ?? ssData.barcodeNo),
                    new SqlParameter("@SampleCollectionDate", ssData.sampleCollectionDate ?? ssData.sampleCollectionDate),
                    new SqlParameter("@SampleCollectionTime", ssData.sampleCollectionTime ?? ssData.sampleCollectionTime),
                    new SqlParameter("@Reason_Id", ssData.reasonId),
                    new SqlParameter("@CollectionFrom", ssData.collectionFrom),
                    new SqlParameter("@CollectedBy", ssData.collectedBy),
                    new SqlParameter("@Createdby", ssData.createdBy),
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
                new SqlParameter("@UserID", ssData.userId),
                new SqlParameter("@FromDate", ssData.fromDate ?? ssData.fromDate ),
                new SqlParameter("@ToDate", ssData.toDate  ?? ssData.toDate),
                new SqlParameter("@SubjectType", ssData.subjectType),
                new SqlParameter("@RegisteredFrom", ssData.registeredFrom ?? ssData.registeredFrom),
            };
            var allData = UtilityDL.FillData<SubjectSamples>(stProc, pList);
            return allData;
        }

        public List<SampleSubject> Retrieve(int code)
        {
            string stProc = FetchANMCHCSampleSubjectDetail;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@ID", code),
            };
            var allData = UtilityDL.FillData<SampleSubject>(stProc, pList);
            return allData;
        }
    }
}
