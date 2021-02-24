using EduquayAPI.Contracts.V1.Request.Haematologist;
using EduquayAPI.Models.Haematologist;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.Haematologist
{
    public class HaematologistData : IHaematologistData
    {

        private const string FetchSubjectsForHematologistUpdation = "SPC_FetchSubjectsForHematologistUpdation";
        private const string UpdatePregnancyDecisionPNDT = "SPC_UpdatePregnancyDecisionPNDT";

        public CVSSampleRefIdDetail AddDecision(PregnancyDecisionRequest pdData)
        {
            string stProc = UpdatePregnancyDecisionPNDT;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@PNDTestId", pdData.pndTestId),
                new SqlParameter("@PNDTFoetusId", pdData.pndtFoetusId),
                new SqlParameter("@PlanForPregnencyContinue", pdData.planForPregnencyContinue),
                new SqlParameter("@UserId", pdData.userId),
            };
            var allData = UtilityDL.FillEntity<CVSSampleRefIdDetail>(stProc, pList);
            return allData;
        }

        public CompletedMolTestDetail RetrieveCompletedMolecularDetail(int molecularLabId)
        {
            string stProc = FetchSubjectsForHematologistUpdation;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@MolecularLabId", molecularLabId),
            };
            var allANWDetail = UtilityDL.FillData<CompletedMolTestANWDetails>(stProc, pList);
            var allFoetusDetail = UtilityDL.FillData<CompletedFoetusMolTestDetail>(stProc, pList);
            var allMolTestDetail = new CompletedMolTestDetail();
            allMolTestDetail.anwDetail = allANWDetail;
            allMolTestDetail.foetusDetail = allFoetusDetail;
            return allMolTestDetail;
        }
    }
}
