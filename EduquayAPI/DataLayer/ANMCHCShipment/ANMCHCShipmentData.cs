using EduquayAPI.Contracts.V1.Request.ANMCHCShipment;
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
        private const string generateANMCHCShipmentId = "SPC_GenerateANMCHCShipmentId";
        private const string addShipment = "SPC_AddANMCHCShipment";
        private const string fetchANMCHCShipmentLog = "SPC_FetchANMCHCShipmentDetail";
        private const string fetchANMCHCShipmentDetail = "SPC_FetchANMCHCShipmentDetailbyShipmentID";
        public ANMCHCShipmentData()
        {

        }

        public string AddANMCHCShipment(AddANMCHCShipmentRequest asData)
        {
            try
            {
                string stProc = addShipment;
                var retVal = new SqlParameter("@Scope_output", 1);
                retVal.Direction = ParameterDirection.Output;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@SubjectID", asData.subjectId),
                    new SqlParameter("@UniqueSubjectID", asData.uniqueSubjectId ?? asData.uniqueSubjectId),
                    new SqlParameter("@SampleCollectionID", asData.sampleCollectionId),
                    new SqlParameter("@ShipmentFrom", asData.shipmentFrom ?? asData.shipmentFrom),
                    new SqlParameter("@ShipmentID", asData.shipmentId ?? asData.shipmentId),
                    new SqlParameter("@ANM_ID", asData.anmId),
                    new SqlParameter("@TestingCHCID", asData.testingCHCId),
                    new SqlParameter("@RIID", asData.riId),
                    new SqlParameter("@ILR_ID", asData.ilrId),
                    new SqlParameter("@AVDID", asData.avdId),
                    new SqlParameter("@DeliveryExecutiveName", asData.deliveryExecutiveName ?? asData.deliveryExecutiveName),
                    new SqlParameter("@ContactNo", asData.contactNo ?? asData.contactNo),
                    new SqlParameter("@DateofShipment", asData.dateOfShipment ?? asData.dateOfShipment),
                    new SqlParameter("@TimeofShipment", asData.timeOfShipment ?? asData.timeOfShipment),
                    new SqlParameter("@Createdby", asData.createdBy),
                    retVal
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
                return "Shipment added successfully";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<ANMCHCShipmentID> ANMCHCGenerateShipmentId(ShipmentIdGenerateRequest sgData)
        {
            string stProc = generateANMCHCShipmentId;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@SenderId", sgData.senderId),
                new SqlParameter("@Source",sgData.source ?? sgData.source),
                new SqlParameter("@ShipmentFrom",sgData.shipmentFrom ?? sgData.shipmentFrom),
            };
            var allData = UtilityDL.FillData<ANMCHCShipmentID>(stProc, pList);
            return allData;
        }

        public List<ANMCHCShipmentDetail> RetrieveShipmentDetail(ANMCHCShipmentDetailRequest asData)
        {
            string stProc = fetchANMCHCShipmentDetail;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@ShipmentID", asData.shipmentId ?? asData.shipmentId),
                new SqlParameter("@ShipmentFrom", asData.shipmentFrom ?? asData.shipmentFrom),
            };
            var allData = UtilityDL.FillData<ANMCHCShipmentDetail>(stProc, pList);
            return allData;
        }

        public List<ANMCHCShipmentLogs> RetrieveShipmentLog(ANMCHCShipmentLogRequest asData)
        {
            string stProc = fetchANMCHCShipmentLog;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@UserID", asData.userId),
                new SqlParameter("@ShipmentFrom", asData.shipmentFrom ?? asData.shipmentFrom),
            };
            var allData = UtilityDL.FillData<ANMCHCShipmentLogs>(stProc, pList);
            return allData;
        }
    }
}
