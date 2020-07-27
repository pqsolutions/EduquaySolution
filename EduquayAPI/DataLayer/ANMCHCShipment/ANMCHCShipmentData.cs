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
        private const string AddShipment = "SPC_AddANMCHCShipments";
        private const string FetchANMCHCShipmentLog = "SPC_FetchANMCHCShipmentLog";
        private const string AddCHCShipments = "SPC_AddCHCCHCShipments";

        public ANMCHCShipmentData()
        {

        }

        public List<ANMCHCShipmentID> AddANMCHCShipment(AddShipmentANMCHCRequest asData)
        {
            try
            {
                string stProc = AddShipment;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@BarcodeNo", asData.barcodeNo ?? asData.barcodeNo),
                    new SqlParameter("@ShipmentFrom", asData.shipmentFrom),
                    new SqlParameter("@ANM_ID", asData.anmId),
                    new SqlParameter("@RIID", asData.riId),
                    new SqlParameter("@ILR_ID", asData.ilrId),
                    new SqlParameter("@AVDID", asData.avdId),
                    new SqlParameter("@AVDContactNo", asData.avdContactNo ?? asData.avdContactNo),
                    new SqlParameter("@AlternateAVD", asData.alternateAVD.ToCheckNull()),
                    new SqlParameter("@AlternateAVDContactNo", asData.alternateAVDContactNo.ToCheckNull()),
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

        public List<ANMCHCShipmentID> AddCHCCHCShipment(AddShipmentCHCCHCRequest csData)
        {
            try
            {
                string stProc = AddCHCShipments;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@BarcodeNo", csData.barcodeNo ?? csData.barcodeNo),
                    new SqlParameter("@ShipmentFrom", csData.shipmentFrom),
                    new SqlParameter("@CHCUserID", csData.chcUserId),
                    new SqlParameter("@CollectionCHCID", csData.collectionCHCId),
                    new SqlParameter("@LogicsProviderID", csData.logisticsProviderId),
                    new SqlParameter("@DeliveryExecutiveName", csData.deliveryExecutiveName ?? csData.deliveryExecutiveName),
                    new SqlParameter("@ExecutiveContactNo", csData.executiveContactNo ?? csData.executiveContactNo),
                    new SqlParameter("@TestingCHCID", csData.testingCHCId),
                    new SqlParameter("@DateofShipment", csData.dateOfShipment ?? csData.dateOfShipment),
                    new SqlParameter("@TimeofShipment", csData.timeOfShipment ?? csData.timeOfShipment),
                    new SqlParameter("@Createdby", csData.createdBy),
                    new SqlParameter("@Source",csData.source ?? csData.source),
                };
                var allData = UtilityDL.FillData<ANMCHCShipmentID>(stProc, pList);
                return allData;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public CHCCHCShipments RetrieveCHCShipmentLog(ANMCHCShipmentLogRequest asData)
        {
            string stProc = FetchANMCHCShipmentLog;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@UserID", asData.userId),
                new SqlParameter("@ShipmentFrom", asData.shipmentFrom),
            };
            var allCHCCHCShipmentLogs = UtilityDL.FillData<CHCCHCShipmentLogs>(stProc, pList);
            var allCHCCHCShipmentSubjects = UtilityDL.FillData<CHCCHCShipmentLogsDetail>(stProc, pList);
            var shiplogDetail = new CHCCHCShipments();
            shiplogDetail.ShipmentLog = allCHCCHCShipmentLogs;
            shiplogDetail.ShipmentSubjectDetail = allCHCCHCShipmentSubjects;
            return shiplogDetail;
        }

        public ANMCHCShipments RetrieveShipmentLog(ANMCHCShipmentLogRequest asData)
        {
            string stProc = FetchANMCHCShipmentLog;
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
