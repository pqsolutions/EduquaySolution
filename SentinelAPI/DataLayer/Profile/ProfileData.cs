using SentinelAPI.Contracts.V1.Request.Mother;
using SentinelAPI.Contracts.V1.Request.Profile;
using SentinelAPI.Models;
using SentinelAPI.Models.Profile;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.DataLayer.Profile
{
    public class ProfileData : IProfileData
    {
        private const string FetchParticularMotherProfile = "SPC_FetchParticularMotherProfile";
        private const string UpdateMotherProfile = "SPC_UpdateMotherProfile";
        private const string FetchAllMotherProfiles = "SPC_FetchAllMotherProfiles";
        private const string FetchAllBabyProfile = "SPC_FetchAllBabyProfile";
        private const string FetchParticularBabyProfile = "SPC_FetchParticularBabyProfile";
        private const string UpdateBabyProfile = "SPC_UpdateBabyProfile";



        public ProfileData()
        {

        }

        public List<BabyProfile> RetrieveAllBabies(FetchAllMotherRequest fmData)
        {
            string stProc = FetchAllBabyProfile;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@HospitalId", fmData.hospitalId),
                new SqlParameter("@FromDate", fmData.fromDate.ToCheckNull()),
                new SqlParameter("@toDate", fmData.toDate.ToCheckNull()),

            };
            var babiesDetail = UtilityDL.FillData<BabyProfile>(stProc, pList);
            return babiesDetail;
        }

        public ProfileMotherDetails RetrieveAllMother(FetchAllMotherRequest fmData)
        {
            string stProc = FetchAllMotherProfiles;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@HospitalId", fmData.hospitalId),
                new SqlParameter("@FromDate", fmData.fromDate.ToCheckNull()),
                new SqlParameter("@toDate", fmData.toDate.ToCheckNull()),

            };
            var motherDetail = UtilityDL.FillData<MotherProfile>(stProc, pList);
            var babyDetail = UtilityDL.FillData<MotherBabiesDetail>(stProc, pList);
            var mother = new ProfileMotherDetails();
            mother.motherDetail = motherDetail;
            mother.babyDetail = babyDetail;
            return mother;
        }

        public List<BabyProfile> RetrieveBabies(FetchBabiesRequest fmData)
        {
            string stProc = FetchParticularBabyProfile;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@HospitalId", fmData.hospitalId),
                new SqlParameter("@BabySubHosNameId", fmData.babyInput ?? fmData.babyInput),
            };
            var babiesDetail = UtilityDL.FillData<BabyProfile>(stProc, pList);
            return babiesDetail;
        }

        public ProfileMotherDetails RetrieveMother(FetchMotherRequest fmData)
        {
            string stProc = FetchParticularMotherProfile;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@HospitalId", fmData.hospitalId),
                new SqlParameter("@MothersRchSubHospID", fmData.motherInput ?? fmData.motherInput),
            };
            var motherDetail = UtilityDL.FillData<MotherProfile>(stProc, pList);
            var babyDetail = UtilityDL.FillData<MotherBabiesDetail>(stProc, pList);
            var mother = new ProfileMotherDetails();
            mother.motherDetail = motherDetail;
            mother.babyDetail = babyDetail;
            return mother;
        }

        public BabyReturnDetail UpdateBaby(UpdateBabyRequest brData)
        {
            try
            {
                string stProc = UpdateBabyProfile;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@BabySubjectId", brData.babySubjectId),
                    new SqlParameter("@HospitalNo", brData.hospitalNo ?? brData.hospitalNo),
                    new SqlParameter("@BabyFirstName", brData.babyFirstName.ToCheckNull()),
                    new SqlParameter("@BabyLastName", brData.babyLastName.ToCheckNull()),
                    new SqlParameter("@Gender", brData.gender.ToCheckNull()),
                    new SqlParameter("@BirthWeight", brData.birthWeight ?? brData.birthWeight),
                    new SqlParameter("@DeliveryDateTime", brData.deliveryDateTime ?? brData.deliveryDateTime),
                    new SqlParameter("@StatusofBirth", brData.statusOfBirth),
                    new SqlParameter("@UserId", brData.userId),
                };
                var babyDetail = UtilityDL.FillEntity<BabyReturnDetail>(stProc, pList);
                return babyDetail;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public MotherReturnDetail UpdateMother(MotherUpdateRequest mrData)
        {
            try
            {
                string stProc = UpdateMotherProfile;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@MotherSubjectId", mrData.motherSubjectId.ToCheckNull()),
                    new SqlParameter("@MotherFirstName", mrData.motherFirstName),
                    new SqlParameter("@MotherLastName", mrData.motherLastName.ToCheckNull()),
                    new SqlParameter("@DOB", mrData.dob.ToCheckNull()),
                    new SqlParameter("@Age", mrData.age),
                    new SqlParameter("@G", mrData.g),
                    new SqlParameter("@P", mrData.p),
                    new SqlParameter("@L", mrData.l),
                    new SqlParameter("@A", mrData.a),
                    new SqlParameter("@RCHID", mrData.rchId),
                    new SqlParameter("@MotherGovIdTypeId", mrData.motherGovIdTypeId),
                    new SqlParameter("@MotherGovIdDetail", mrData.motherGovIdDetail.ToCheckNull()),
                    new SqlParameter("@MotherContactNo", mrData.motherContactNo.ToCheckNull()),
                    new SqlParameter("@ECNumber", mrData.ecNumber.ToCheckNull()),
                    new SqlParameter("@Address1", mrData.address1.ToCheckNull()),
                    new SqlParameter("@Address2", mrData.address2.ToCheckNull()),
                    new SqlParameter("@Address3", mrData.address3.ToCheckNull()),
                    new SqlParameter("@StateId", mrData.stateId),
                    new SqlParameter("@Pincode", mrData.pincode.ToCheckNull()),
                    new SqlParameter("@FatherFirstName", mrData.fatherFirstName.ToCheckNull()),
                    new SqlParameter("@FatherLastName", mrData.fatherLastName.ToCheckNull()),
                    new SqlParameter("@FatherContactNo", mrData.fatherContactNo.ToCheckNull()),
                    new SqlParameter("@GuardianFirstName", mrData.guardianFirstName.ToCheckNull()),
                    new SqlParameter("@GuardianLastName", mrData.guardianLastName.ToCheckNull()),
                    new SqlParameter("@GuardianContactNo", mrData.guardianContactNo.ToCheckNull()),
                    new SqlParameter("@UserId", mrData.userId),
                };
                var motherDet = UtilityDL.FillEntity<MotherReturnDetail>(stProc, pList);
                return motherDet;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

      
    }
}
