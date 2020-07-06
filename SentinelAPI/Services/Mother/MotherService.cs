using SentinelAPI.Contracts.V1.Request.Mother;
using SentinelAPI.Contracts.V1.Response.Mother;
using SentinelAPI.DataLayer.Mother;
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
                    foreach (var mom in motherDetail)
                    {
                        motherResponse.Status = "true";
                        motherResponse.Message = mom.responseMsg;
                        motherResponse.MotherSubjectId = mom.subjectId;
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
            else if (mrData.hospitalFileId == "")
            {
                message = "Invalid Hospital File Id";
            }
            else if (mrData.dateofRegistration == "")
            {
                message = "Invalid date of registration";
            }
            else if (mrData.motherFirstName == "")
            {
                message = "Invalid Mother name";
            }
            else if (mrData.motherLastName == "")
            {
                message = "Invalid Last name";
            }
            else if (mrData.motherGovIdTypeId  <= 0)
            {
                message = "Invalid Mother Gov.Id Type";
            }
            else if (mrData.motherGovIdDetail == "")
            {
                message = "Invalid Mother GovId Detail";
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
            else if (mrData.state == "")
            {
                message = "Invalid state";
            }
            return message;
        }


        //public string AddMotherDetail(AddMotherRequest mrData)
        //{
        //    try
        //    {
        //        if (mrData.districtId <= 0)
        //        {
        //            return "Invalid District Id";
        //        }
        //        if (mrData.motherFirstName == "")
        //        {
        //            return "Invalid Mother name";
        //        }
        //        if (mrData.motherLastName == "")
        //        {
        //            return "Invalid Last name";
        //        }
        //        var result = _motherData.AddMotherDetail(mrData);
        //        return string.IsNullOrEmpty(result) ? $"Unable to add mother detail" : result;
        //    }
        //    catch (Exception e)
        //    {
        //        return $"Unable to add mother detail - {e.Message}";
        //    }

        //}
    }
}
