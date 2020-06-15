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
                    new SqlParameter("@ContactNo", asData.contactNo ?? asData.contactNo),
                    new SqlParameter("@DateofShipment", asData.dateOfShipment ?? asData.dateOfShipment),
                    new SqlParameter("@TimeofShipment", asData.timeOfShipment ?? asData.timeOfShipment),
                    new SqlParameter("@Createdby", asData.createdBy),
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
                new SqlParameter("@SenderId", sgData.senderId),
                new SqlParameter("@Source",sgData.source ?? sgData.source),
                new SqlParameter("@ShipmentFrom",sgData.shipmentFrom ?? sgData.shipmentFrom),
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
