using SentinelAPI.Contracts.V1.Request.SampleCollection;
using SentinelAPI.Contracts.V1.Response;
using SentinelAPI.DataLayer.SampleCollection;
using SentinelAPI.Models.SampleCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Services.SampleCollection
{
    public class SampleCollectionService : ISampleCollectionService
    {
        private readonly ISampleCollectionData _sampleCollectionData;

        public SampleCollectionService(ISampleCollectionDataFactory sampleCollectionDataFactory)
        {
            _sampleCollectionData = new SampleCollectionDataFactory().Create();
        }

        public async Task<ServiceResponse> AddSample(AddSampleCollectionRequest scData)
        {
            ServiceResponse sResponse = new ServiceResponse();
            try
            {
                if (string.IsNullOrEmpty(scData.uniqueSubjectId))
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Uniquesubjectid is missing";
                    return sResponse;
                }
                if (string.IsNullOrEmpty(scData.barcodeNo))
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Barcode is missing";
                    return sResponse;
                }
                if (string.IsNullOrEmpty(scData.sampleCollectionDate))
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Sample collection date is missing";
                    return sResponse;
                }
                if (string.IsNullOrEmpty(scData.sampleCollectionTime))
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Sample collection time is missing";
                    return sResponse;
                }
                if (scData.hospitalId <= 0)
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Invalid hospitalId";
                    return sResponse;
                }
                if (scData.collectedBy <= 0)
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Invalid collection by data";
                    return sResponse;
                }

                var barcode = _sampleCollectionData.FetchBarcode(scData.barcodeNo);
                if (barcode.Count <= 0)
                {
                    var result = _sampleCollectionData.AddSample(scData);
                    if (string.IsNullOrEmpty(result))
                    {
                        sResponse.Status = "false";
                        sResponse.Message = $"Unable to collect sampele for this uniquesubjectid - {scData.uniqueSubjectId}";
                        return sResponse;
                    }
                    else
                    {
                        sResponse.Status = "true";
                        sResponse.Message = result;
                        return sResponse;
                    }
                }
                else
                {
                    sResponse.Status = "false";
                    sResponse.Message = $" This barcode no- {scData.barcodeNo} is already associated with another infant subject";
                    return sResponse;
                }
            }
            catch (Exception e)
            {
                sResponse.Status = "false";
                sResponse.Message = $"Unable to collect sampele for this uniquesubjectid - {scData.uniqueSubjectId} - {e.Message}";
                return sResponse;
            }
        }

        public List<SampleCollectionList> RetriveInfantList(SampleCollectionRequest scData)
        {
            var infantSamples = _sampleCollectionData.RetriveInfantList(scData);
            return infantSamples;
        }
    }
}
