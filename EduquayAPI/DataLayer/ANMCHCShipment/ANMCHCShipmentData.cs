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
        private const string GenerateANMCHCShipmentId = "SPC_GenerateANMCHCShipmentId";
        private const string AddShipment = "SPC_AddANMCHCShipment";
        private const string FetchANMCHCShipmentLog = "SPC_FetchANMCHCShipmentDetail";
        private const string FetchANMCHCShipmentDetail = "SPC_FetchANMCHCShipmentDetailbyShipmentID";
        public ANMCHCShipmentData()
        {

        }

        public string AddANMCHCShipment(AddANMCHCShipmentRequest asData)
        {
            try
            {
                string stProc = AddShipment;
                var retVal = new SqlParameter("@Scope_output", 1);
                retVal.Direction = ParameterDirection.Output;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@SubjectID", asData.SubjectID),
                    new SqlParameter("@UniqueSubjectID", asData.UniqueSubjectID ?? asData.UniqueSubjectID),
                    new SqlParameter("@SampleCollectionID", asData.SampleCollectionID),
                    new SqlParameter("@ShipmentFrom", asData.ShipmentFrom ?? asData.ShipmentFrom),
                    new SqlParameter("@ShipmentID", asData.ShipmentID ?? asData.ShipmentID),
                    new SqlParameter("@ANM_ID", asData.ANM_ID),
                    new SqlParameter("@TestingCHCID", asData.TestingCHCID),
                    new SqlParameter("@RIID", asData.RIID),
                    new SqlParameter("@ILR_ID", asData.ILR_ID),
                    new SqlParameter("@AVDID", asData.AVDID),
                    new SqlParameter("@DeliveryExecutiveName", asData.DeliveryExecutiveName ?? asData.DeliveryExecutiveName),
                    new SqlParameter("@ContactNo", asData.ContactNo ?? asData.ContactNo),
                    new SqlParameter("@DateofShipment", asData.DateofShipment ?? asData.DateofShipment),
                    new SqlParameter("@TimeofShipment", asData.TimeofShipment ?? asData.TimeofShipment),
                    new SqlParameter("@Createdby", asData.CreatedBy),
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
            string stProc = GenerateANMCHCShipmentId;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@SenderId", sgData.SenderId),
                new SqlParameter("@Source",sgData.Source ?? sgData.Source),
                new SqlParameter("@ShipmentFrom",sgData.ShipmentFrom ?? sgData.ShipmentFrom),
            };
            var allData = UtilityDL.FillData<ANMCHCShipmentID>(stProc, pList);
            return allData;
        }

        public List<ANMCHCShipmentDetail> RetrieveShipmentDetail(ANMCHCShipmentDetailRequest asData)
        {
            string stProc = FetchANMCHCShipmentDetail;
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
            string stProc = FetchANMCHCShipmentLog;
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
