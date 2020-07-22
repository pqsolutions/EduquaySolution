using EduquayAPI.Contracts.V1.Request.ANMCHCPickandPack;
using EduquayAPI.Contracts.V1.Response.ANMCHCPickandPack;
using EduquayAPI.DataLayer.ANMCHCPickandPack;
using EduquayAPI.Models.ANMCHCPickandPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.ANMCHCPickandPack
{
    public class ANMCHCPickandPackService : IANMCHCPickandPackService
    {
        private readonly IANMCHCPickandPackData _anmchcPickandPackData;
        public ANMCHCPickandPackService(IANMCHCPickandPackDataFactory anmchcPickandPackDataFactory)
        {
            _anmchcPickandPackData = new ANMCHCPickandPackDataFactory().Create();
        }
        //public List<ANMCHCPickandPackSamples> Retrieve(ANMCHCPickandPackRequest acppData)
        //{
        //    var pickandPackSamples = _anmchcPickandPackData.Retrieve(acppData);
        //    return pickandPackSamples;
        //}

        public async Task<ANMCHCPickandPackResponse> Retrieve(ANMCHCPickandPackRequest acppData)
        {
            var anmchcPickPackResponse = new ANMCHCPickandPackResponse();
            try
            {
                var pickandpack = _anmchcPickandPackData.Retrieve(acppData);

                var pickpackSample = new List<ANMCHCPickandPackSample>();

                foreach (var pp in pickandpack)
                {
                    var ppSample = new ANMCHCPickandPackSample();
                    ppSample.barcodeNo = pp.barcodeNo;
                    ppSample.gestationalAge = pp.gestationalAge;
                    ppSample.rchId = pp.rchId;
                    ppSample.sampleCollectionId = pp.sampleCollectionId;
                    ppSample.subjectName = pp.subjectName;
                    ppSample.uniqueSubjectId = pp.uniqueSubjectId;
                    ppSample.sampleDateTime = pp.sampleDateTime;
                    DateTime myDate1 = DateTime.Now;
                    DateTime myDate2 = Convert.ToDateTime(pp.sampleDateTime);
                    TimeSpan difference = myDate1.Subtract(myDate2);
                    double totalHours = Math.Round(difference.TotalHours);
                    ppSample.sampleAging = Convert.ToString(totalHours); //+ " Hrs";
                    pickpackSample.Add(ppSample);
                }
                anmchcPickPackResponse.SampleList = pickpackSample;
                anmchcPickPackResponse.Status = "true";
                anmchcPickPackResponse.Message = string.Empty;
            }
            catch (Exception e)
            {
                anmchcPickPackResponse.Status = "false";
                anmchcPickPackResponse.Message = e.Message;
            }
            return anmchcPickPackResponse;
        }
    }
}
