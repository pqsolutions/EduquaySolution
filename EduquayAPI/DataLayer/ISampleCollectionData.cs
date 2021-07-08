using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using EduquayAPI.Models.SMS;

namespace EduquayAPI.DataLayer
{
    public interface ISampleCollectionData
    {
        string AddSample(AddSubjectSampleRequest ssData);
        List<SubjectSamples> Retrieve(SubjectSampleRequest ssData);
        List<BarcodeSample> FetchBarcode(string barcodeNo);
        SMSSamplesDetails FetchSMSSamples(string barcodeNo, string subjectId);
        SMSSamplesDetails FetchSMSSamplesByBarcode(string barcodeNo);

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
