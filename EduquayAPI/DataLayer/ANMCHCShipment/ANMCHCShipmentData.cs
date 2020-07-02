using EduquayAPI.Contracts.V1.Request.ANMCHCShipment;
using EduquayAPI.Models;
using EduquayAPI.Models.ANMCHCShipment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.ANMCHCShipment
{
    public class ANMCHCShipmentData : IANMCHCShipmentData
    {
        private const string addShipment = "SPC_AddANMCHCShipments";
        private const string fetchANMCHCShipmentLog = "SPC_FetchANMCHCShipmentLog";
        public ANMCHCShipmentData()
        {

        }

        public List<ANMCHCShipmentID> AddANMCHCShipment(AddShipmentANMCHCRequest asData)
        {
            try
            {
                string stProc = addShipment;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@BarcodeNo", asData.barcodeNo ?? asData.barcodeNo),
                    new SqlParameter("@ShipmentFrom", asData.shipmentFrom),
                    new SqlParameter("@ANM_ID", asData.anmId),
                    new SqlParameter("@RIID", asData.riId),
                    new SqlParameter("@ILR_ID", asData.ilrId),
                    new SqlParameter("@AVDID", asData.avdId),
                    new SqlParameter("AVDContactNo", asData.avdContactNo.ToCheckNull()),
                    new SqlParameter("@TestingCHCID", asData.testingCHCId),
                    new SqlParameter("@DateofShipment", asData.dateOfShipment ?? asData.dateOfShipment),
                    new SqlParameter("@TimeofShipment", asData.timeOfShipment ?? asData.timeOfShipment),
                    new SqlParameter("@Createdby", asData.createdBy),
                    new SqlParameter("@Source",asData.source ?? asData.source),
                };
                var allData = UtilityDL.FillData<ANMCHCShipmentID>(stProc, pList);
                return allData;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ANMCHCShipments RetrieveShipmentLog(ANMCHCShipmentLogRequest asData)
        {
            string stProc = fetchANMCHCShipmentLog;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@UserID", asData.userId),
                new SqlParameter("@ShipmentFrom", asData.shipmentFrom),
            };
            var allANMCHCShipmentLogs = UtilityDL.FillData<ANMCHCShipmentLogs>(stProc, pList);
            var allANMCHCShipmentSubjects = UtilityDL.FillData<ANMCHCShipmentLogsDetail>(stProc, pList);
            var shiplogDetail = new ANMCHCShipments();
            shiplogDetail.ShipmentLog = allANMCHCShipmentLogs;
            shiplogDetail.ShipmentSubjectDetail = allANMCHCShipmentSubjects;
            return shiplogDetail;
        }
   }
}
