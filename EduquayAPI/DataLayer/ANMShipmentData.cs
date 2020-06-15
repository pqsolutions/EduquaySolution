using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Request.ANMShipment;
using EduquayAPI.Models;
using EduquayAPI.Models.ANMShipment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer
{
    public class ANMShipmentData : IANMShipmentData
    {
        private const string FetchSampleCollectionbyANM = "SPC_FetchSampleCollectionbyANM";
        private const string FetchShipmentDetailbyANM = "SPC_FetchShipmentDetailbyANM";
        private const string FetchShipmentDetailbyShipmentID = "SPC_FetchANMShipmentDetailbyShipmentID";
        private const string AddShipment = "SPC_AddANMShipment";
        private const string ANMShipmentID = "SPC_GenerateANMShipmentId";
        public ANMShipmentData()
        {

        }

        public string AddANMShipment(AddANMShipmentRequest asData)
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
                    new SqlParameter("@ContactNo", asData.ContactNo ?? asData.ContactNo),
                    new SqlParameter("@DateofShipment", asData.DateofShipment ?? asData.DateofShipment),
                    new SqlParameter("@TimeofShipment", asData.TimeofShipment ?? asData.TimeofShipment),
                    new SqlParameter("@Createdby", asData.CreatedBy),
                    retVal
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
                return "ANM Shipment added successfully";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<ANMShipmentID> GenerateANMShipmentID(GenerateShipmentIdRequest sgData)
        {
            string stProc = ANMShipmentID;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@SenderId", sgData.SenderId),
                new SqlParameter("@Source",sgData.Source ?? sgData.Source),
                new SqlParameter("@ShipmentFrom",sgData.ShipmentFrom ?? sgData.ShipmentFrom),
            };
            var allData = UtilityDL.FillData<ANMShipmentID>(stProc, pList);
            return allData;
        }

        public List<ANMPickandPackSamples> Retrieve(int anmCode)
        {
            string stProc = FetchSampleCollectionbyANM;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@ANMID", anmCode),
            };
            var allData = UtilityDL.FillData<ANMPickandPackSamples>(stProc, pList);
            return allData;
        }

        public List<ANMShipments> Retrieve(string shipmentId)
        {
            string stProc = FetchShipmentDetailbyShipmentID;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@ShipmentID", shipmentId),
            };
            var allData = UtilityDL.FillData<ANMShipments>(stProc, pList);
            return allData;
        }

        public List<ANMShipmentLog> RetrieveShipmentLog(int anmCode)
        {
            string stProc = FetchShipmentDetailbyANM;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@ANMID", anmCode),
            };
            var allData = UtilityDL.FillData<ANMShipmentLog>(stProc, pList);
            return allData;
        }
    }
}
