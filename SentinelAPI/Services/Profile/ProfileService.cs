using SentinelAPI.Contracts.V1.Request.Mother;
using SentinelAPI.Contracts.V1.Request.Profile;
using SentinelAPI.Contracts.V1.Response.Baby;
using SentinelAPI.Contracts.V1.Response.Mother;
using SentinelAPI.Contracts.V1.Response.Profile;
using SentinelAPI.DataLayer.Profile;
using SentinelAPI.Models.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Services.Profile
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileData _profileData;

        public ProfileService(IProfileDataFactory profilerDataFactory)
        {
            _profileData = new ProfileDataFactory().Create();
        }

        public async Task<MotherProfileResponse> RetrieveMother(FetchMotherRequest fmData)
        {
            var motherResponse = new MotherProfileResponse();
            try
            {

                if (fmData.motherInput == "")
                {
                    motherResponse.Status = "true";
                    motherResponse.Message = "Enter SubjectId or RCH Id or Hospital File Id";
                }
                else if (fmData.hospitalId <= 0)
                {
                    motherResponse.Status = "false";
                    motherResponse.Message = "Invalid hospital";
                }
                else
                {
                    var motherDetail = _profileData.RetrieveMother(fmData);
                    var moms = new List<MOMProfile>();
                    var motherUniqueSubjectId = "";
                    foreach (var mother in motherDetail.motherDetail)
                    {
                        var mom = new MOMProfile();
                        if (motherUniqueSubjectId != mother.motherSubjectId)
                        {
                            var baby = motherDetail.babyDetail.Where(sd => sd.motherSubjectId == mother.motherSubjectId).ToList();
                            mom.motherSubjectId = mother.motherSubjectId;
                            mom.dateofRegistration = mother.dateofRegistration;
                            mom.districtId = mother.districtId;
                            mom.hospitalNo = mother.hospitalNo;
                            mom.motherFirstName = mother.motherFirstName;
                            mom.motherLastName = mother.motherLastName;
                            mom.dob = mother.dob;
                            mom.age = mother.age;
                            mom.rchId = mother.rchId;
                            mom.g = mother.g;
                            mom.p = mother.p;
                            mom.l = mother.l;
                            mom.a = mother.a;
                            mom.motherGovIdTypeId = mother.motherGovIdTypeId;
                            mom.motherGovIdDetail = mother.motherGovIdDetail;
                            mom.motherContactNo = mother.motherContactNo;
                            mom.gpla = mother.gpla;
                            mom.ecNumber = mother.ecNumber;
                            mom.address1 = mother.address1;
                            mom.address2 = mother.address2;
                            mom.address3 = mother.address3;
                            mom.stateId = mother.stateId;
                            mom.stateName = mother.stateName;
                            mom.districtName = mother.districtName;
                            mom.pincode = mother.pincode;
                            mom.religionName = mother.religionName;
                            mom.casteName = mother.casteName;
                            mom.communityName = mother.communityName;
                            mom.fatherFirstName = mother.fatherFirstName;
                            mom.fatherLastName = mother.fatherLastName;
                            mom.fatherContactNo = mother.fatherContactNo;
                            mom.guardianFirstName = mother.guardianFirstName;
                            mom.guardianLastName = mother.guardianLastName;
                            mom.guardianContactNo = mother.guardianContactNo;
                            mom.motherHospitalName = mother.motherHospitalName;
                            mom.motherHospitalAddress = mother.motherHospitalAddress;
                            mom.motherHospitalContactNo = mother.motherHospitalContactNo;
                            if (baby[0].babySubjectId == null)
                            {
                                mom.babyDetail = null;
                            }
                            else
                            {
                                mom.babyDetail = baby;
                            }
                            motherUniqueSubjectId = mother.motherSubjectId;
                            moms.Add(mom);
                        }
                    }
                    motherResponse.Status = "true";
                    motherResponse.Message = string.Empty;
                    motherResponse.data = moms;
                }
            }
            catch (Exception e)
            {
                motherResponse.Status = "false";
                motherResponse.Message = e.Message;
            }
            return motherResponse;
        }

        public async Task<AddMotherResponse> UpdateMother(MotherUpdateRequest mrData)
        {
            var motherResponse = new AddMotherResponse();
            try
            {
                var msg = CheckErrorMessage(mrData);
                if (msg == "")
                {
                    var motherDetail = _profileData.UpdateMother(mrData);
                    if (motherDetail.success == true)
                    {
                        motherResponse.Status = "true";
                        motherResponse.Message = motherDetail.responseMsg;
                        motherResponse.MotherSubjectId = motherDetail.subjectId;
                    }
                    else
                    {
                        motherResponse.Status = "false";
                        motherResponse.Message = motherDetail.responseMsg;
                        motherResponse.MotherSubjectId = motherDetail.subjectId;
                    }
                }
                else
                {
                    motherResponse.Status = "false";
                    motherResponse.Message = msg;
                }
            }
            catch (Exception e)
            {
                motherResponse.Status = "false";
                motherResponse.Message = e.Message;
            }
            return motherResponse;
        }

        public string CheckErrorMessage(MotherUpdateRequest mrData)
        {
            var message = "";
           
            if (mrData.motherFirstName == "")
            {
                message = "Invalid Mother name";
            }
            else if (mrData.motherLastName == "")
            {
                message = "Invalid Last name";
            }
            else if (mrData.address1 == "")
            {
                message = "Invalid address1 (House No or Plot No)";
            }
            else if (mrData.address2 == "")
            {
                message = "Invalid address2 (Street or Locality)";
            }
            else if (mrData.address3 == "")
            {
                message = "Invalid address3 (city or Village)";
            }
            else if (mrData.pincode == "")
            {
                message = "Invalid pincode";
            }
            else if (mrData.stateId <= 0)
            {
                message = "Invalid state";
            }
            return message;
        }

        public async Task<MotherProfileResponse> RetrieveAllMother(FetchAllMotherRequest fmData)
        {
            var motherResponse = new MotherProfileResponse();
            try
            {
                if (fmData.hospitalId <= 0)
                {
                    motherResponse.Status = "false";
                    motherResponse.Message = "Invalid hospital";
                }
                else
                {
                    var motherDetail = _profileData.RetrieveAllMother(fmData);
                    var moms = new List<MOMProfile>();
                    var motherUniqueSubjectId = "";
                    foreach (var mother in motherDetail.motherDetail)
                    {
                        var mom = new MOMProfile();
                        if (motherUniqueSubjectId != mother.motherSubjectId)
                        {
                            var baby = motherDetail.babyDetail.Where(sd => sd.motherSubjectId == mother.motherSubjectId).ToList();
                            mom.motherSubjectId = mother.motherSubjectId;
                            mom.dateofRegistration = mother.dateofRegistration;
                            mom.districtId = mother.districtId;
                            mom.hospitalNo = mother.hospitalNo;
                            mom.motherFirstName = mother.motherFirstName;
                            mom.motherLastName = mother.motherLastName;
                            mom.dob = mother.dob;
                            mom.age = mother.age;
                            mom.rchId = mother.rchId;
                            mom.g = mother.g;
                            mom.p = mother.p;
                            mom.l = mother.l;
                            mom.a = mother.a;
                            mom.motherGovIdTypeId = mother.motherGovIdTypeId;
                            mom.motherGovIdDetail = mother.motherGovIdDetail;
                            mom.motherContactNo = mother.motherContactNo;
                            mom.gpla = mother.gpla;
                            mom.ecNumber = mother.ecNumber;
                            mom.address1 = mother.address1;
                            mom.address2 = mother.address2;
                            mom.address3 = mother.address3;
                            mom.stateId = mother.stateId;
                            mom.stateName = mother.stateName;
                            mom.districtName = mother.districtName;
                            mom.pincode = mother.pincode;
                            mom.religionName = mother.religionName;
                            mom.casteName = mother.casteName;
                            mom.communityName = mother.communityName;
                            mom.fatherFirstName = mother.fatherFirstName;
                            mom.fatherLastName = mother.fatherLastName;
                            mom.fatherContactNo = mother.fatherContactNo;
                            mom.guardianFirstName = mother.guardianFirstName;
                            mom.guardianLastName = mother.guardianLastName;
                            mom.guardianContactNo = mother.guardianContactNo;
                            mom.motherHospitalName = mother.motherHospitalName;
                            mom.motherHospitalAddress = mother.motherHospitalAddress;
                            mom.motherHospitalContactNo = mother.motherHospitalContactNo;
                            if (baby[0].babySubjectId == null)
                            {
                                mom.babyDetail = null;
                            }
                            else
                            {
                                mom.babyDetail = baby;
                            }
                            motherUniqueSubjectId = mother.motherSubjectId;
                            moms.Add(mom);
                        }
                    }
                    motherResponse.Status = "true";
                    motherResponse.Message = string.Empty;
                    motherResponse.data = moms;
                }
            }
            catch (Exception e)
            {
                motherResponse.Status = "false";
                motherResponse.Message = e.Message;
            }
            return motherResponse;
        }

        public List<BabyProfile> RetrieveAllBabies(FetchAllMotherRequest fmData)
        {
            var babiesDetail = _profileData.RetrieveAllBabies(fmData);
            return babiesDetail;
        }

        public List<BabyProfile> RetrieveBabies(FetchBabiesRequest fmData)
        {
            var babiesDetail = _profileData.RetrieveBabies(fmData);
            return babiesDetail;
        }

        public async  Task<AddBabyResponse> UpdateBaby(UpdateBabyRequest brData)
        {
            var babyResponse = new AddBabyResponse();
            try
            {
                var msg = CheckBabyErrorMessage(brData);
                if (msg == "")
                {
                    var babyDetail = _profileData.UpdateBaby(brData);
                    if (babyDetail.success == true)
                    {
                        babyResponse.Status = "true";
                        babyResponse.Message = babyDetail.responseMsg;
                        babyResponse.BabySubjectId = babyDetail.subjectId;
                    }
                    else
                    {
                        babyResponse.Status = "false";
                        babyResponse.Message = babyDetail.responseMsg;
                        babyResponse.BabySubjectId = babyDetail.subjectId;
                    }
                }
                else
                {
                    babyResponse.Status = "false";
                    babyResponse.Message = msg;
                }
            }
            catch (Exception e)
            {
                babyResponse.Status = "false";
                babyResponse.Message = e.Message;
            }
            return babyResponse;
        }

        public string CheckBabyErrorMessage(UpdateBabyRequest brData)
        {
            var message = "";
            if (brData.babySubjectId == "")
            {
                message = "Missing baby Subject Id";
            }
            else if (brData.gender == "")
            {
                message = "Missing gender";
            }
            else if (brData.birthWeight == "")
            {
                message = "Missing birth weight";
            }
            else if (brData.deliveryDateTime == "")
            {
                message = "Missing delivery date and time";
            }
            else if (brData.statusOfBirth <= 0)
            {
                message = "Invalid status of birth";
            }
            else if (brData.userId <= 0)
            {
                message = "Invalid  user id";
            }

            return message;
        }

    }
}
