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
        private const string AddMothersDetail = "SPC_AddMothersDetails";

        public MotherData()
        {

        }

        public string AddMotherDetail(AddMotherRequest mrData)
        {
            MotherRegistration motherRegDetails = MotherDetail(mrData);
            if (motherRegDetails != null)
            {
                return $"{motherRegDetails.responseMsg} successfully. The Unique ID is: {motherRegDetails.subjectId}";

            }
            else
            {
                return $"Unable to register mother details for {mrData.motherFirstName}";

            }
        }
        public MotherRegistration MotherDetail(AddMotherRequest mrData)
        {
            try
            {
                string stProc = AddMothersDetail;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@DistrictID", mrData.districtId),
                    new SqlParameter("@HospitalId", mrData.hospitalId),
                    new SqlParameter("@MotherSubjectId", mrData.motherSubjectId.ToCheckNull()),
                    new SqlParameter("@HospitalFileId", mrData.hospitalFileId),
                    new SqlParameter("@DateofRegistration", mrData.dateofRegistration),
                    new SqlParameter("@Mother_FirstName", mrData.motherFirstName),
                    new SqlParameter("@Mother_MiddleName", mrData.motherMiddleName.ToCheckNull()),
                    new SqlParameter("@Mother_LastName", mrData.motherLastName.ToCheckNull()),
                    new SqlParameter("@Mother_GovIdTypeId", mrData.motherGovIdTypeId),
                    new SqlParameter("@Mother_GovIdDetail", mrData.motherGovIdDetail.ToCheckNull()),
                    new SqlParameter("@Mother_ContactNo", mrData.motherContactNo.ToCheckNull()),
                    new SqlParameter("@Father_FirstName", mrData.fatherFirstName.ToCheckNull()),
                    new SqlParameter("@Father_MiddleName", mrData.fatherMiddleName.ToCheckNull()),
                    new SqlParameter("@Father_LastName", mrData.fatherLastName.ToCheckNull()),
                    new SqlParameter("@Father_GovIdTypeId", mrData.fatherGovIdTypeId),
                    new SqlParameter("@Father_GovIdDetail", mrData.fatherGovIdDetail.ToCheckNull()),
                    new SqlParameter("@Father_ContactNo", mrData.fatherContactNo.ToCheckNull()),
                    new SqlParameter("@Gaurdian_FirstName", mrData.gaurdianFirstName.ToCheckNull()),
                    new SqlParameter("@Gaurdian_MiddleName", mrData.gaurdianMiddleName.ToCheckNull()),
                    new SqlParameter("@Gaurdian_LastName", mrData.gaurdianLastName.ToCheckNull()),
                    new SqlParameter("@Gaurdian_GovIdTypeId", mrData.gaurdianGovIdTypeId),
                    new SqlParameter("@Gaurdian_GovIdDetail", mrData.gaurdianGovIdDetail.ToCheckNull()),
                    new SqlParameter("@Gaurdian_ContactNo", mrData.gaurdianContactNo.ToCheckNull()),
                    new SqlParameter("@ReligionId", mrData.religionId),
                    new SqlParameter("@CasteId", mrData.casteId),
                    new SqlParameter("@CommunityId", mrData.communityId),
                    new SqlParameter("@ECNumber", mrData.ecNumber.ToCheckNull()),
                    new SqlParameter("@RCHID", mrData.rchId),
                    new SqlParameter("@Address1", mrData.address1.ToCheckNull()),
                    new SqlParameter("@Address2", mrData.address2.ToCheckNull()),
                    new SqlParameter("@Address3", mrData.address3.ToCheckNull()),
                    new SqlParameter("@State", mrData.state.ToCheckNull()),
                    new SqlParameter("@Pincode", mrData.pincode.ToCheckNull()),
                    new SqlParameter("@CreatedBy", mrData.createdBy),
                    new SqlParameter("@Comments", mrData.comments.ToCheckNull()),

                };
                var motherDet = UtilityDL.FillEntity<MotherRegistration>(stProc, pList);
                return motherDet;

            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
