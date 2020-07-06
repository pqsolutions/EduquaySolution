using SentinelAPI.Contracts.V1.Request.Infant;
using SentinelAPI.Contracts.V1.Response.Infant;
using SentinelAPI.Controllers;
using SentinelAPI.DataLayer.Infant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;

namespace SentinelAPI.Services.Infant
{
    public class InfantService : IInfantService
    {

        private readonly IInfantData _infantData;

        public InfantService(IInfantDataFactory infantDataFactory)
        {
            _infantData = new InfantDataFactory().Create();
        }

        public string CheckErrorMessage(AddInfantRequest irData)
        {
            var message = "";
            if (irData.mothersId <= 0)
            {
                message= "Invalid mother Id";
            }
            else if (irData.districtId <= 0)
            {
                message = "Invalid District Id";
            }
            else if (irData.hospitalId <= 0)
            {
                message = "Invalid Hospital Id";
            }
            else if (irData.subTitle == "")
            {
                message = "Invalid subject Title ";
            }
            else if (irData.firstName == "")
            {
                message = "Invalid First name";
            }
            else if (irData.lastName == "")
            {
                message = "Invalid Last name";
            }
            else if (irData.gender == "")
            {
                message = "Invalid Gender ";
            }
            else if (irData.dateOfRegister == "")
            {
                message = "Invalid register date ";
            }
            else if (irData.dateOfDelivery == "")
            {
                message = "Invalid date of delivery ";
            }
            else if (irData.timeOfDelivery == "")
            {
                message = "Invalid time of delivery ";
            }
            else if (irData.statusOfBirth <= 0)
            {
                message = "Invalid Status of Birth";
            }
            return message;

        }
       
        public async Task<InfantMotherResponse> RetrieveMother(GetMotherRequest mData)
        {
            var motherdet = _infantData.RetrieveMother(mData);
            var motherResponse = new InfantMotherResponse();
            var moms = new List<InfantMom>();
            try
            {
                var motherUniqueSubjectId = "";
                foreach (var mother in motherdet.MotherDetail)
                {
                    var mom = new InfantMom();
                    if (motherUniqueSubjectId != mother.motherSubjectId)
                    {
                        var infant = motherdet.InfantsDetail.Where(sd => sd.mothersId == mother.motherId).ToList();
                        mom.motherId = mother.motherId;
                        mom.motherSubjectId = mother.motherSubjectId;
                        mom.MothersName = mother.MothersName;
                        mom.hospitalId = mother.hospitalId;
                        mom.districtId = mother.districtId;
                        mom.rchId = mother.rchId;
                        mom.InfantDetail = infant;
                        motherUniqueSubjectId = mother.motherSubjectId;
                        moms.Add(mom);
                    }
                }
                motherResponse.Status = "true";
                motherResponse.Message = string.Empty;
                motherResponse.MotherDetail = moms;
            }
            catch (Exception e)
            {
                motherResponse.Status = "false";
                motherResponse.Message = e.Message;
            }
            return motherResponse;
        }

        public async Task<AddInfantResponse> AddInfantDetail(AddInfantRequest irData)
        {
            var infantResponse = new AddInfantResponse();
            try
            {
                var msg = CheckErrorMessage(irData);
                if (msg == "")
                {
                    var infantDetail = _infantData.AddInfantDetail(irData);
                    foreach (var infant in infantDetail)
                    {
                        infantResponse.Status = "true";
                        infantResponse.Message = infant.responseMsg;
                        infantResponse.InfantSubjectId = infant.infantSubjectId;
                    }
                }
                else
                {
                    infantResponse.Status = "false";
                    infantResponse.Message = msg;
                }
            }
            catch (Exception e)
            {
                infantResponse.Status = "false";
                infantResponse.Message = e.Message;
            }
            return infantResponse;
        }
    }
}
