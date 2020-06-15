using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.DataLayer;
using EduquayAPI.Models;

namespace EduquayAPI.Services
{
    public class ClinicalDiagnosisService : IClinicalDiagnosisService
    {
        private readonly IClinicalDiagnosisData _clinicalDiagnosisData;

        public ClinicalDiagnosisService(IClinicalDiagnosisDataFactory clinicalDiagnosisDataFactory)
        {
            _clinicalDiagnosisData = new ClinicalDiagnosisDataFactory().Create();
        }

        public string Add(ClinicalDiagnosisRequest cdData)
        {
            try
            {
                if (cdData.isActive.ToLower() != "true")
                {
                    cdData.isActive = "false";
                }
                var result = _clinicalDiagnosisData.Add(cdData);
                return string.IsNullOrEmpty(result) ? $"Unable to add clinical diagnosis data" : result;
            }
            catch (Exception e)
            {
                return $"Unable to add clinical diagnosis data - {e.Message}";
            }
        }

        public List<ClinicalDiagnosis> Retrieve(int code)
        {
            var clinicalDiagnosis = _clinicalDiagnosisData.Retrieve(code);
            return clinicalDiagnosis;
        }

        public List<ClinicalDiagnosis> Retrieve()
        {
            var clinicalDiagnosis = _clinicalDiagnosisData.Retrieve();
            return clinicalDiagnosis;
        }
    }
}
