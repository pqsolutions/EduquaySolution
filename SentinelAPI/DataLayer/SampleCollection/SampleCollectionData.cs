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
        private const string FetchBabiesNotSampleCollected = "SPC_FetchBabiesNotSampleCollected";
        private const string AddSampleCollection = "SPC_AddSampleCollection";
        private const string FetchBarcodeSample = "SPC_FetchBarcodeSample";

        public SampleCollectionData()
        {

        }
        public BabySampleCollection AddSample(AddSampleCollectionRequest scData)
        {
            try
            {
                string stProc = AddSampleCollection;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@BabySubjectId", scData.babySubjectId ?? scData.babySubjectId),
                    new SqlParameter("@HospitalId", scData.hospitalId),
                    new SqlParameter("@BarcodeNo", scData.barcodeNo  ?? scData.barcodeNo),
                    new SqlParameter("@SampleCollectionDate", scData.sampleCollectionDate ?? scData.sampleCollectionDate),
                    new SqlParameter("@SampleCollectionTime", scData.sampleCollectionTime ?? scData.sampleCollectionTime),
                    new SqlParameter("@CollectedBy", scData.collectedBy),
                };
                var samplecollection = UtilityDL.FillEntity<BabySampleCollection>(stProc, pList);
                return samplecollection;
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

        public List<SampleCollectionList> RetriveBabiesList(SampleCollectionRequest scData)
        {
            string stProc = FetchBabiesNotSampleCollected;
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
