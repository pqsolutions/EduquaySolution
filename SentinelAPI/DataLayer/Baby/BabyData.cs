using SentinelAPI.Contracts.V1.Request.Baby;
using SentinelAPI.Models;
using SentinelAPI.Models.Baby;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.DataLayer.Baby
{
    public class BabyData : IBabyData
    {
        private const string AddBabysDetail = "SPC_AddBabyDetail";

        public BabyData()
        {

        }
        public BabyRegistration AddBabyDetail(AddBabyRequest brData)
        {
            try
            {
                string stProc = AddBabysDetail;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@MothersSubjectId", brData.mothersSubjectId ?? brData.mothersSubjectId),
                    new SqlParameter("@TypeofBaby", brData.typeofBaby),
                    new SqlParameter("@BabySubjectId", brData.babySubjectId.ToCheckNull()),
                    new SqlParameter("@DateOfRegistration", brData.dateOfRegisteration ?? brData.dateOfRegisteration),
                    new SqlParameter("@HospitalId", brData.hospitalId),
                    new SqlParameter("@HospitalNo", brData.hospitalNo ?? brData.hospitalNo),
                    new SqlParameter("@BabyName", brData.babyName ?? brData.babyName),
                    new SqlParameter("@Gender", brData.gender.ToCheckNull()),
                    new SqlParameter("@BirthWeight", brData.birthWeight ?? brData.birthWeight),
                    new SqlParameter("@DeliveryDateTime", brData.deliveryDateTime ?? brData.deliveryDateTime),
                    new SqlParameter("@StatusofBirth", brData.statusOfBirth),
                    new SqlParameter("@CreatedBy", brData.userId),
                };
                var babyDetail = UtilityDL.FillEntity<BabyRegistration>(stProc, pList);
                return babyDetail;

            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
