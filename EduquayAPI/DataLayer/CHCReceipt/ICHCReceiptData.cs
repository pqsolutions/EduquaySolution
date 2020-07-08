using EduquayAPI.Contracts.V1.Request.CHCReceiptProcessing;
using EduquayAPI.Models.CHCReceipt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.CHCReceipt
{
    public interface ICHCReceiptData
    {
        CHCReceipts RetrieveCHCReceipts(int testingCHCId);

        void AddReceivedShipment(AddReceivedShipmentRequest rsData);
    }
    public interface ICHCReceiptDataFactory
    {
        ICHCReceiptData Create();
    }
    public class CHCReceiptDataFactory : ICHCReceiptDataFactory
    {
        public ICHCReceiptData Create()
        {
            return new CHCReceiptData();
        }
    }
}
