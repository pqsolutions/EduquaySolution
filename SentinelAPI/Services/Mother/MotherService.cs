using SentinelAPI.Contracts.V1.Request.Mother;
using SentinelAPI.Contracts.V1.Response.Mother;
using SentinelAPI.DataLayer.Mother;
using SentinelAPI.Models.Mother;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Services.Mother
{
    public class MotherService : IMotherService
    {
        private readonly IMotherData _motherData;

        public MotherService(IMotherDataFactory motherDataFactory)
        {
            _motherData = new MotherDataFactory().Create();
        }

        public async Task<AddMotherResponse> AddMotherDetail(AddMotherRequest mrData)
        {
            var motherResponse = new AddMotherResponse();
            try
            {
                var msg = CheckErrorMessage(mrData);
                if (msg == "")
                {
                    var motherDetail = _motherData.AddMotherDetail(mrData);

                    motherResponse.Status = "true";
                    motherResponse.Message = motherDetail.responseMsg;
                    motherResponse.MotherSubjectId = motherDetail.subjectId;

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

        public string CheckErrorMessage(AddMotherRequest mrData)
        {
            var message = "";
            if (mrData.districtId <= 0)
            {
                message = "Invalid District Id";
            }
            else if (mrData.hospitalId <= 0)
            {
                message = "Invalid Hospital Id";
            }
            else if (mrData.hospitalNo == "")
            {
                message = "Invalid Hospital No";
            }
            else if (mrData.dateofRegistration == "")
            {
                message = "Invalid date of registration";
            }
            else if (mrData.motherFirstName == "")
            {
                message = "Invalid Mother name";
            }
            else if (mrData.stateId <= 0)
            {
                message = "Invalid state";
            }
            return message;
        }

        public async Task<FetchMotherResponse> RetrieveMother(FetchMotherRequest fmData)
        {

            var motherResponse = new FetchMotherResponse();
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
                    var motherDetail = _motherData.RetrieveMother(fmData);
                    var moms = new List<MomDetail>();
                    var motherUniqueSubjectId = "";
                    foreach (var mother in motherDetail.motherDetail)
                    {
                        var mom = new MomDetail();
                        if (motherUniqueSubjectId != mother.motherSubjectId)
                        {
                            var baby = motherDetail.babyDetail.Where(sd => sd.motherSubjectId == mother.motherSubjectId).ToList();
                            mom.motherSubjectId = mother.motherSubjectId;
                            mom.dateofRegistration = mother.dateofRegistration;
                            mom.districtId = mother.districtId;

                            mom.hospitalId = mother.hospitalId;
                            mom.hospitalNo = mother.hospitalNo;
                            mom.collectionSiteId= mother.collectionSiteId;
                            mom.motherFirstName= mother.motherFirstName;
                            mom.motherLastName= mother.motherLastName;
                            mom.dob= mother.dob;
                            mom.age= mother.age;
                            mom.rchId= mother.rchId;
                            mom.motherGovIdTypeId= mother.motherGovIdTypeId;
                            mom.motherGovIdDetail= mother.motherGovIdDetail;
                            mom.motherGovIdDetail= mother.motherGovIdDetail;
                            mom.motherContactNo= mother.motherContactNo;
                            mom.g= mother.g;
                            mom.p= mother.p;
                            mom.l= mother.l;
                            mom.a= mother.a;
                            mom.ecNumber= mother.ecNumber;
                            mom.address1= mother.address1;
                            mom.address2= mother.address2;
                            mom.address3= mother.address3;
                            mom.stateId= mother.stateId;
                            mom.pincode= mother.pincode;
                            mom.religionId= mother.religionId;
                            mom.casteId= mother.casteId;
                            mom.communityId= mother.communityId;
                            mom.fatherFirstName= mother.fatherFirstName;
                            mom.fatherLastName= mother.fatherLastName;
                            mom.fatherContactNo = mother.fatherContactNo;
                            mom.guardianFirstName = mother.guardianFirstName;
                            mom.guardianLastName = mother.guardianLastName;
                            mom.guardianContactNo = mother.guardianContactNo;
                            if(baby[0].babySubjectId == null)
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
    }
}
