using SentinelAPI.Contracts.V1.Request.PickandPack;
using SentinelAPI.Models.PickandPack;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.DataLayer.PickandPack
{
    public class PickandPackData : IPickandPackData
    {

        private const string FetchSampleCollection = "SPC_FetchSampleCollection";
        private const string AddShipments = "SPC_AddShipments";

        public PickandPackData()
        {

        }

        public List<ShipmentsId> AddShipment(AddPickandPackRequest asData)
        {
            try
            {
                string stProc = AddShipments;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@BarcodeNo", asData.barcodeNo ?? asData.barcodeNo),
                    new SqlParameter("@HospitalId", asData.hospitalId),
                    new SqlParameter("@MolecularLabId", asData.molecularLabId),
                    new SqlParameter("@SenderName", asData.senderName ?? asData.senderName),
                    new SqlParameter("@ContactNo", asData.contactNo ?? asData.contactNo),
                    new SqlParameter("@DateofShipment", asData.dateOfShipment ?? asData.dateOfShipment),
                    new SqlParameter("@TimeofShipment", asData.timeOfShipment ?? asData.timeOfShipment),
                    new SqlParameter("@Createdby", asData.userId),
                };
                var allData = UtilityDL.FillData<ShipmentsId>(stProc, pList);
                return allData;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<PickandPackDetails> RetrivePickandPackSamples(int hospitalId)
        {
            string stProc = FetchSampleCollection;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@HospitalId", hospitalId),

            };
            var allData = UtilityDL.FillData<PickandPackDetails>(stProc, pList);
            return allData;
        }
    }
}
