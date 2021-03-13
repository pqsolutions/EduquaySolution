using EduquayAPI.Contracts.V1.Request.Support;
using EduquayAPI.Models.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.Support
{
    public interface ISupportData
    {
        List<BarcodeErrorDetail> FetchErrorBarcodeDetails();
        List<BarcodeErrorDetail> FetchBarcodeDetailsForErrorCorrection(string barcodeNo);
        BarcodeErrorDetail FetchBarcodeExist(string barcodeNo);
        UpdateBarcodeMsg UpdateErrorBarcode(UpdateBarcodeRequest bData);
    }
    public interface ISupportDataFactory
    {
        ISupportData Create();
    }
    public class SupportDataFactory : ISupportDataFactory
    {
        public ISupportData Create()
        {
            return new SupportData();
        }
    }
}
