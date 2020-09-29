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
            else if (mrData.motherLastName == "")
            {
                message = "Invalid Last name";
            }
            else if (mrData.motherGovIdTypeId <= 0)
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

                    motherResponse.Status = "true";
                    motherResponse.Message = string.Empty;
                    motherResponse.data = motherDetail;
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
