using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.DataLayer;
using EduquayAPI.Models;


namespace EduquayAPI.Services
{
    public class CasteService : ICasteService
    {
        private readonly ICasteData _casteData;

        public CasteService(ICasteDataFactory casteDataFactory)
        {
            _casteData = new CasteDataFactory().Create();
        }

        public string Add(CasteRequest cData)
        {
            try
            {
                if (cData.IsActive.ToLower() != "true")
                {
                    cData.IsActive = "false";
                }
                var result = _casteData.Add(cData);
                return string.IsNullOrEmpty(result) ? $"Unable to add caste data" : result;
            }
            catch (Exception e)
            {
                return $"Unable to add caste data - {e.Message}";
            }
        }

        public List<Caste> Retrieve(int code)
        {

            var caste = _casteData.Retrieve(code);
            return caste;
        }

        public List<Caste> Retrieve()
        {
            var caste = _casteData.Retrieve();
            return caste;
        }
    }
}
