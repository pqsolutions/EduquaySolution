using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.DataLayer;
using EduquayAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services
{
    public class GovIDTypeService : IGovIDTypeService
    {
        private readonly IGovIDTypeData _govidTypeData;

        public GovIDTypeService(IFacilityTypeDataFactory govidtypeDataFactory)
        {
            _govidTypeData = new GovIDTypeDataFactory().Create();
        }
        public string Add(GovIDTypeRequest gtData)
        {
            try
            {
                if (gtData.isActive.ToLower() != "true")
                {
                    gtData.isActive = "false";
                }
                var result = _govidTypeData.Add(gtData);
                return string.IsNullOrEmpty(result) ? $"Unable to add GovID Type data" : result;
            }
            catch (Exception e)
            {
                return $"Unable to add GovID Type data - {e.Message}";
            }
        }

        public List<GovIDType> Retrieve(int code)
        {
            var govidType = _govidTypeData.Retrieve(code);
            return govidType;
        }

        public List<GovIDType> Retrieve()
        {
            var allGovIDTypes = _govidTypeData.Retrieve();
            return allGovIDTypes;
        }
    }
}
