using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.DataLayer;
using EduquayAPI.Models;

namespace EduquayAPI.Services
{
    public class RIService : IRIService
    {

        private readonly IRIData _riData;

        public RIService(IRIDataFactory riDataFactory)
        {
            _riData = new RIDataFactory().Create();
        }
        public string Add(RIRequest rData)
        {
            try
            {

                if (rData.isActive.ToLower() != "true")
                {
                    rData.isActive = "false";
                }
                if (rData.phcId <= 0)
                {
                    return "Invalid PHC id";
                }
                if (rData.scId <= 0)
                {
                    return "Invalid SC id";
                }
                if (rData.ilrId <= 0)
                {
                    return "Invalid ILR id";
                }
                var result = _riData.Add(rData);
                return string.IsNullOrEmpty(result) ? $"Unable to add RI data" : result;
            }
            catch (Exception e)
            {
                return $"Unable to add RI data - {e.Message}";
            }
        }

        public List<RI> Retrieve(int code)
        {
            var ri = _riData.Retrieve(code);
            return ri;
        }

        public List<RI> Retrieve()
        {
            var allRIs = _riData.Retrieve();
            return allRIs;
        }
    }
}
