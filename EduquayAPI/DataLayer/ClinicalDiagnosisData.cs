using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using EduquayAPI.Models.Masters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer
{
    public class ClinicalDiagnosisData : IClinicalDiagnosisData
    {

        private const string FetchAllClinicalDiagnosis = "SPC_FetchAllClinicalDiagnosis";
        private const string FetchClinicalDiagnosis = "SPC_FetchClinicalDiagnosis";
        private const string AddClinicalDiagnosis = "SPC_AddClinicalDiagnosis";

        public ClinicalDiagnosisData()
        {


        }

        public AddEditMasters Add(ClinicalDiagnosisRequest cdData)
        {
            try
            {
                string stProc = AddClinicalDiagnosis;
                var pList = new List<SqlParameter>
                {
                   
                    new SqlParameter("@Diagnosisname",  cdData.diagnosisName    ??  cdData.diagnosisName),
                    new SqlParameter("@Isactive",  cdData.isActive ??  cdData.isActive),
                    new SqlParameter("@Comments",  cdData.comments ??  cdData.comments),
                    new SqlParameter("@Createdby",  cdData.createdBy),
                    new SqlParameter("@Updatedby",  cdData.updatedBy),
                };
                var returnData = UtilityDL.FillEntity<AddEditMasters>(stProc, pList);
                return returnData;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<ClinicalDiagnosis> Retrieve(int code)
        {
            string stProc = FetchClinicalDiagnosis;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", code) };
            var allData = UtilityDL.FillData<ClinicalDiagnosis>(stProc, pList);
            return allData;
        }

        public List<ClinicalDiagnosis> Retrieve()
        {
            string stProc = FetchAllClinicalDiagnosis;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<ClinicalDiagnosis>(stProc, pList);
            return allData;
        }
    }
}
