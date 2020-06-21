using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;

namespace EduquayAPI.DataLayer
{
    public interface ISampleCollectionData
    {
        string AddSample(AddSubjectSampleRequest ssData);
        List<SubjectSamples> Retrieve(SubjectSampleRequest ssData);
        List<SampleSubject> Retrieve(SampleSubjectRequest ssData);
        List<BarcodeSample> FetchBarcode(string barcodeNo);

    }
    public interface ISampleCollectionDataFactory
    {
        ISampleCollectionData Create();
    }
    public class SampleCollectionDataFactory : ISampleCollectionDataFactory
    {
        public ISampleCollectionData Create()
        {
            return new SampleCollectionData();
        }
    }
}
