using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using EduquayAPI.Models.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer
{
    public interface IClinicalDiagnosisData
    {
        AddEditMasters Add(ClinicalDiagnosisRequest cdData);
        List<ClinicalDiagnosis> Retrieve(int code);
        List<ClinicalDiagnosis> Retrieve();
    }
    public interface IClinicalDiagnosisDataFactory
    {
        IClinicalDiagnosisData Create();
    }

    public class ClinicalDiagnosisDataFactory : IClinicalDiagnosisDataFactory
    {
        public IClinicalDiagnosisData Create()
        {
            return new ClinicalDiagnosisData();
        }
    }


}
