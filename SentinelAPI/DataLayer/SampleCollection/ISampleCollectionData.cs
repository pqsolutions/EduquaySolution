using SentinelAPI.Contracts.V1.Request.SampleCollection;
using SentinelAPI.Models.SampleCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.DataLayer.SampleCollection
{
    public interface ISampleCollectionData
    {
        List<SampleCollectionList> RetriveInfantList(SampleCollectionRequest scData);
        string AddSample(AddSampleCollectionRequest scData);
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
