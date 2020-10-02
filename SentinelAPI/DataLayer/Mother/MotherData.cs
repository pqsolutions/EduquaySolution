using SentinelAPI.Contracts.V1.Request.Mother;
using SentinelAPI.Models;
using SentinelAPI.Models.Mother;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.DataLayer.Mother
{
    public class MotherData : IMotherData
    {
        private const string AddMothersDetail = "SPC_AddMothersDetail";
        private const string FetchMotherDetail = "SPC_FetchMotherDetail";

        public MotherData()
        {

        }

        public MotherRegistration AddMotherDetail(AddMotherRequest mrData)
        {
            try
            {
                string stProc = AddMothersDetail;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@MotherSubjectId", mrData.motherSubjectId.ToCheckNull()),
                    new SqlParameter("@DateofRegistration", mrData.dateofRegistration),
                    new SqlParameter("@DistrictID", mrData.districtId),
                    new SqlParameter("@HospitalId", mrData.hospitalId),
                    new SqlParameter("@HospitalNo", mrData.hospitalNo ?? mrData.hospitalNo),
                    new SqlParameter("@CollectionSiteId", mrData.collectionSiteId),
                    new SqlParameter("@MotherFirstName", mrData.motherFirstName),
                    new SqlParameter("@MotherLastName", mrData.motherLastName.ToCheckNull()),
                    new SqlParameter("@DOB", mrData.dob.ToCheckNull()),
                    new SqlParameter("@Age", mrData.age),
                    new SqlParameter("@RCHID", mrData.rchId),
                    new SqlParameter("@MotherGovIdTypeId", mrData.motherGovIdTypeId),
                    new SqlParameter("@MotherGovIdDetail", mrData.motherGovIdDetail.ToCheckNull()),
                    new SqlParameter("@MotherContactNo", mrData.motherContactNo.ToCheckNull()), 
                    new SqlParameter("@G", mrData.g),
                    new SqlParameter("@P", mrData.p),
                    new SqlParameter("@L", mrData.l),
                    new SqlParameter("@A", mrData.a),
                    new SqlParameter("@ECNumber", mrData.ecNumber.ToCheckNull()),
                    new SqlParameter("@Address1", mrData.address1.ToCheckNull()),
                    new SqlParameter("@Address2", mrData.address2.ToCheckNull()),
                    new SqlParameter("@Address3", mrData.address3.ToCheckNull()),
                    new SqlParameter("@StateId", mrData.stateId),
                    new SqlParameter("@Pincode", mrData.pincode.ToCheckNull()),
                    new SqlParameter("@ReligionId", mrData.religionId),
                    new SqlParameter("@CasteId", mrData.casteId),
                    new SqlParameter("@CommunityId", mrData.communityId),
                    new SqlParameter("@FatherFirstName", mrData.fatherFirstName.ToCheckNull()),
                    new SqlParameter("@FatherLastName", mrData.fatherLastName.ToCheckNull()),
                    new SqlParameter("@FatherContactNo", mrData.fatherContactNo.ToCheckNull()),
                    new SqlParameter("@GuardianFirstName", mrData.guardianFirstName.ToCheckNull()),
                    new SqlParameter("@GuardianLastName", mrData.guardianLastName.ToCheckNull()),
                    new SqlParameter("@GuardianContactNo", mrData.guardianContactNo.ToCheckNull()),
                    new SqlParameter("@UserId", mrData.userId),
                };
                var motherDet = UtilityDL.FillEntity<MotherRegistration>(stProc, pList);
                return motherDet;

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public MotherDetails RetrieveMother(FetchMotherRequest fmData)
        {
            string stProc = FetchMotherDetail;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@HospitalId", fmData.hospitalId),
                new SqlParameter("@MothersRchSubHospID", fmData.motherInput ?? fmData.motherInput),
            };
            var motherDetail = UtilityDL.FillData<MotherDetail>(stProc, pList);
            var babyDetail = UtilityDL.FillData<MothersBabyDetail>(stProc, pList);
            var mother = new MotherDetails();
            mother.motherDetail = motherDetail;
            mother.babyDetail = babyDetail;
            return mother;
        }
    }
}
