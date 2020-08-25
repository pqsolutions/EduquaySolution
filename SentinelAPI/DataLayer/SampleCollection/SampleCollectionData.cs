using SentinelAPI.Contracts.V1.Request.SampleCollection;
using SentinelAPI.Models.SampleCollection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.DataLayer.SampleCollection
{
    public class SampleCollectionData : ISampleCollectionData
    {
        private const string FetchInfantNotSampleCollected = "SPC_FetchInfantNotSampleCollected";
        private const string AddSampleCollection = "SPC_AddSampleCollection";
        private const string FetchBarcodeSample = "SPC_FetchBarcodeSample";

        public SampleCollectionData()
        {

        }

        public string AddSample(AddSampleCollectionRequest scData)
        {
            try
            {
                string stProc = AddSampleCollection;
                var retVal = new SqlParameter("@Scope_output", 1);
                retVal.Direction = ParameterDirection.Output;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@UniqueSubjectID", scData.uniqueSubjectId ?? scData.uniqueSubjectId),
                    new SqlParameter("@BarcodeNo", scData.barcodeNo  ?? scData.barcodeNo),
                    new SqlParameter("@SampleCollectionDate", scData.sampleCollectionDate ?? scData.sampleCollectionDate),
                    new SqlParameter("@SampleCollectionTime", scData.sampleCollectionTime ?? scData.sampleCollectionTime),
                    new SqlParameter("@Reason", scData.reason ?? scData.reason),
                    new SqlParameter("@CollectedBy", scData.collectedBy),
                    new SqlParameter("@HospitalId", scData.hospitalId),
                    retVal
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
                return $"Sample collected successfully";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<BarcodeSample> FetchBarcode(string barcodeNo)
        {
            string stProc = FetchBarcodeSample;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@Barcode", barcodeNo),

            };
            var allData = UtilityDL.FillData<BarcodeSample>(stProc, pList);
            return allData;
        }

        public List<SampleCollectionList> RetriveInfantList(SampleCollectionRequest scData)
        {
            string stProc = FetchInfantNotSampleCollected;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@HospitalId", scData.hospitalId),
                new SqlParameter("@FromDate", scData.fromDate ?? scData.fromDate),
                new SqlParameter("@ToDate", scData.toDate ?? scData.toDate),
            };
            var infantDetail = UtilityDL.FillData<SampleCollectionList>(stProc, pList);
            return infantDetail;
        }
    }
}
