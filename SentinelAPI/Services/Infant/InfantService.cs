using SentinelAPI.Contracts.V1.Request.Infant;
using SentinelAPI.Contracts.V1.Response.Infant;
using SentinelAPI.Controllers;
using SentinelAPI.DataLayer.Infant;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public string AddInfantDetail(AddInfantRequest irData)
        {
            try
            {
                if (irData.mothersId <= 0)
                {
                    return "Invalid mother Id";
                }
                if (irData.districtId <= 0)
                {
                    return "Invalid District Id";
                }
                if (irData.hospitalId <= 0)
                {
                    return "Invalid Hospital Id";
                }
                if (irData.subTitle == "")
                {
                    return "Invalid subject Title ";
                }
                if (irData.firstName == "")
                {
                    return "Invalid First name";
                }
                if (irData.lastName == "")
                {
                    return "Invalid Last name";
                }
                if (irData.gender == "")
                {
                    return "Invalid Gender ";
                }
                if (irData.dateOfRegister == "")
                {
                    return "Invalid register date ";
                }
                if (irData.dateOfDelivery == "")
                {
                    return "Invalid date of delivery ";
                }
                if (irData.timeOfDelivery == "")
                {
                    return "Invalid time of delivery ";
                }
                if (irData.statusOfBirth <= 0)
                {
                    return "Invalid Status of Birth";
                }

                var result = _infantData.AddInfantDetail(irData);
                return string.IsNullOrEmpty(result) ? $"Unable to add infant detail" : result;
            }
            catch (Exception e)
            {
                return $"Unable to add infant detail - {e.Message}";
            }
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
    }
}
