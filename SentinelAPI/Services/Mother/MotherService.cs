using SentinelAPI.Contracts.V1.Request.Mother;
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

        public string AddMotherDetail(AddMotherRequest mrData)
        {
            try
            {
                if (mrData.districtId <= 0)
                {
                    return "Invalid District Id";
                }
                if (mrData.motherFirstName == "")
                {
                    return "Invalid Mother name";
                }
                if (mrData.motherLastName == "")
                {
                    return "Invalid Last name";
                }
                var result = _motherData.AddMotherDetail(mrData);
                return string.IsNullOrEmpty(result) ? $"Unable to add mother detail" : result;
            }
            catch (Exception e)
            {
                return $"Unable to add mother detail - {e.Message}";
            }

        }
    }
}
