using EduquayAPI.Contracts.V1.Request.Support;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.Contracts.V1.Response.Support;
using EduquayAPI.DataLayer;
using EduquayAPI.DataLayer.Support;
using EduquayAPI.Models.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.Support
{
    public class SupportService : ISupportService
    {
        private readonly ISupportData _supportData;
        private readonly ISampleCollectionData _sampleCollectionData;

        public SupportService(ISupportDataFactory supportDataFactory, ISampleCollectionDataFactory sampleCollectionDataFactory)
        {
            _supportData = new SupportDataFactory().Create();
            _sampleCollectionData = new SampleCollectionDataFactory().Create();
        }

        public async Task<CheckBarcodeResponse> CheckbarcodeExist(string barcodeNo)
        {
            CheckBarcodeResponse sResponse = new CheckBarcodeResponse();
            try
            {
                var barcode = _sampleCollectionData.FetchBarcode(barcodeNo);
                if (barcode.Count <= 0)
                {
                    sResponse.status = "true";
                    sResponse.barcodeExist = false;
                    sResponse.data = null;
                }
                else
                {
                    var barcodeDetail = _supportData.FetchBarcodeExist(barcodeNo);
                    sResponse.status = "true";
                    sResponse.barcodeExist = true;
                    sResponse.data = barcodeDetail;

                }
                return sResponse;
            }
            catch (Exception e)
            {
                sResponse.status = "false";
                sResponse.message = e.Message;
                return sResponse;
            }
        }

        public List<BarcodeErrorDetail> FetchBarcodeDetailsForErrorCorrection(string barcodeNo)
        {
            var allData = _supportData.FetchBarcodeDetailsForErrorCorrection(barcodeNo);
            return allData;
        }

        public List<BarcodeErrorDetail> FetchErrorBarcodeDetails()
        {
            var allData = _supportData.FetchErrorBarcodeDetails();
            return allData;
        }

        public async Task<ServiceResponse> UpdateErrorBarcode(UpdateBarcodeRequest bData)
        {
            ServiceResponse sResponse = new ServiceResponse();
            try
            {
                if (string.IsNullOrEmpty(bData.barcodeNo))
                {
                    sResponse.Status = "false";
                    sResponse.Message = "BarcodeNo is missing";
                    return sResponse;
                }
                else if (string.IsNullOrEmpty(bData.revisedBarcodeNo))
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Revised BarcodeNo is missing";
                    return sResponse;
                }
                else if (bData.userId <= 0)
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Invalid UserId";
                    return sResponse;
                }
                else
                {
                    var result = _supportData.UpdateErrorBarcode(bData);
                    if (string.IsNullOrEmpty(result.msg))
                    {
                        sResponse.Status = "false";
                        sResponse.Message = $"Unable to Update the Revised Barcode - {bData.revisedBarcodeNo}";
                        return sResponse;
                    }
                    else
                    {
                        sResponse.Status = "true";
                        sResponse.Message = result.msg;
                        return sResponse;
                    }
                }
            }
            catch (Exception e)
            {
                sResponse.Status = "false";
                sResponse.Message = e.Message;
                return sResponse;
            }
        }
    }
}
