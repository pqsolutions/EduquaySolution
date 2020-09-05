using SentinelAPI.Models.Shipment;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.DataLayer.Shipments
{
    public class ShipmentData:IShipmentData
    {
        private const string FetchShipmentLog = "SPC_FetchShipmentLog";
        public ShipmentData()
        {

        }

        public ShipmentsLogs RetrieveShipmentLog(int userId)
        {
            string stProc = FetchShipmentLog;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@UserId", userId),
            };
            var allShipmentLogs = UtilityDL.FillData<ShipmentLogs>(stProc, pList);
            var allShipmentSubjects = UtilityDL.FillData<ShipmentDetail>(stProc, pList);
            var shiplogDetail = new ShipmentsLogs();
            shiplogDetail.ShipmentLog = allShipmentLogs;
            shiplogDetail.ShipmentSubjectDetail = allShipmentSubjects;
            return shiplogDetail;
        }
    }
}
