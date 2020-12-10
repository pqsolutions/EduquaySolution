using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using EduquayAPI.Models.Masters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer
{
    public class RIData : IRIData
    {

        private const string FetchAllRIs = "SPC_FetchAllRI";
        private const string FetchRI = "SPC_FetchRI";
        private const string AddRI = "SPC_AddRI";
        public RIData()
        {

        }
        public AddEditMasters Add(RIRequest rData)
        {
            try
            {
                string stProc = AddRI;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@TestingCHCID", rData.testingCHCId),
                    new SqlParameter("@CHCID", rData.chcId),
                    new SqlParameter("@PHCID", rData.phcId),
                    new SqlParameter("@SCID", rData.scId),                    
                    new SqlParameter("@RI_gov_code", rData.riGovCode),
                    new SqlParameter("@RIsite", rData.riSite  ?? rData.riSite),
                    new SqlParameter("@Pincode", rData.pincode  ?? rData.pincode),
                    new SqlParameter("@ILRID" ,rData.ilrId),
                    new SqlParameter("@Isactive", rData.isActive ?? rData.isActive),
                    new SqlParameter("@Latitude", rData.latitude ?? rData.latitude),
                    new SqlParameter("@Longitude", rData.longitude ?? rData.longitude),
                    new SqlParameter("@Comments", rData.comments ?? rData.comments),
                    new SqlParameter("@Createdby", rData.createdBy),
                    new SqlParameter("@Updatedby", rData.updatedBy),
                };
                var returnData = UtilityDL.FillEntity<AddEditMasters>(stProc, pList);
                return returnData;
            }
            catch (Exception e)
            {
                throw e;

            }
        }

        public List<RI> Retrieve(int code)
        {
            string stProc = FetchRI;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", code) };
            var allData = UtilityDL.FillData<RI>(stProc, pList);
            return allData;
        }

        public List<RI> Retrieve()
        {
            string stProc = FetchAllRIs;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<RI>(stProc, pList);
            return allData;
        }
    }
}
