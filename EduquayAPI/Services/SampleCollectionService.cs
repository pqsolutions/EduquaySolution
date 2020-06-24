using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.DataLayer;
using EduquayAPI.Models;

namespace EduquayAPI.Services
{
    public class SampleCollectionService : ISampleCollectionService
    {
        private readonly ISampleCollectionData _sampleCollectionData;

        public SampleCollectionService(ISampleCollectionDataFactory sampleCollectionDataFactory)
        {
            _sampleCollectionData = new SampleCollectionDataFactory().Create();
        }

        public  string AddSample(AddSubjectSampleRequest ssData)
        {
            try
            {
                if (string.IsNullOrEmpty(ssData.uniqueSubjectId))
                {
                    return "Invalid UniqueSubjectID";
                }
                if (string.IsNullOrEmpty(ssData.barcodeNo))
                {
                    return "Invalid BarcodeNo";
                }
                if (string.IsNullOrEmpty(ssData.sampleCollectionDate))
                {
                    return "Invalid SampleCollection Date";
                }
                if (string.IsNullOrEmpty(ssData.sampleCollectionTime))
                {
                    return "Invalid SampleCollection Time";
                }
                if (ssData.collectionFrom <= 0)
                {
                    return "Invalid Collection From data";
                }
                if (ssData.collectedBy <= 0)
                {
                    return "Invalid Collection By";
                }

                var barcode =  _sampleCollectionData.FetchBarcode(ssData.barcodeNo);
                if (barcode.Count <= 0)
                {
                    var result = _sampleCollectionData.AddSample(ssData);
                    return string.IsNullOrEmpty(result) ? $"Unable to collect sampele for this uniquesubjectid - {ssData.uniqueSubjectId}" : result;
                }
                else
                {
                    return $"This Barcode No - {ssData.barcodeNo} already exist";
                }
            }
            catch (Exception e)
            {
                return $"Unable to collect sampele for this uniquesubjectid - {ssData.uniqueSubjectId} - {e.Message}";
            }
        }

        public List<SubjectSamples> Retrieve(SubjectSampleRequest ssData)
        {
            var subjectSamples = _sampleCollectionData.Retrieve(ssData);
            return subjectSamples;
        }

        public List<SampleSubject> Retrieve(SampleSubjectRequest ssData)
        {
            var sampleSubject = _sampleCollectionData.Retrieve(ssData);
            return sampleSubject;
        }
    }
}
