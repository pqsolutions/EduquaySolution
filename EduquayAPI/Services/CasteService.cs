using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Response.Masters;
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

        public async Task<AddEditResponse> Add(CasteRequest cData)
        {
            var response = new AddEditResponse();
            try
            {
                if (cData.isActive.ToLower() != "true")
                {
                    cData.isActive = "false";
                }
                if (string.IsNullOrEmpty(cData.casteName))
                {
                    response.Status = "false";
                    response.Message = "Please enter caste name";
                }
                else
                {
                    var addEditResponse = _casteData.Add(cData);
                    response.Status = "true";
                    response.Message = addEditResponse.message;
                }
                return response;
            }
            catch (Exception e)
            {
                response.Status = "false";
                response.Message = $"Unable to process - {e.Message}";
                return response;
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
