using EduquayAPI.Contracts.V1.Request.CentralLab;
using EduquayAPI.Models.CentralLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.CentralLab
{
    public interface ICentralLabData
    {
        CentralLabReceipts RetrieveCentralLabReceipts(int centralLabId);
        void AddReceivedShipment(AddCentralShipmentRequest csData);
        List<HPLCTest> RetrieveHPLC(int centralLabId);
        void AddHPLCTest(AddHPLCTestRequest hplcData);


    }

    public interface ICentralLabDataFactory
    {
        ICentralLabData Create();
    }
    public class CentralLabDataFactory : ICentralLabDataFactory
    {
        public ICentralLabData Create()
        {
            return new CentralLabData();
        }
    }
}
