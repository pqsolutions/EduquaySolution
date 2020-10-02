using SentinelAPI.Contracts.V1.Request.Baby;
using SentinelAPI.Contracts.V1.Response.Baby;
using SentinelAPI.DataLayer.Baby;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Services.Baby
{
    public class BabyService : IBabyService
    {
        private readonly IBabyData _babyData;

        public BabyService(IBabyDataFactory babyDataFactory)
        {
            _babyData = new BabyDataFactory().Create();
        }
        public async Task<AddBabyResponse> AddBabyDetail(AddBabyRequest brData)
        {
            var babyResponse = new AddBabyResponse();
            try
            {
                var msg = CheckErrorMessage(brData);
                if (msg == "")
                {
                    var babyDetail = _babyData.AddBabyDetail(brData);
                    babyResponse.Status = "true";
                    babyResponse.Message = babyDetail.responseMsg;
                    babyResponse.BabySubjectId = babyDetail.babySubjectId;
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
        public string CheckErrorMessage(AddBabyRequest brData)
        {
            var message = "";
            if (brData.mothersSubjectId == "")
            {
                message = "Missing mother Subject Id";
            }
            else if (brData.dateOfRegisteration == "")
            {
                message = "Missing date of registration";
            }
            else if (brData.hospitalId <= 0)
            {
                message = "Invallid hospital id";
            }
            else if (brData.gender == "")
            {
                message = "Missing gender";
            }
            else if (brData.babyName == "")
            {
                message = "Missing baby name";
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
