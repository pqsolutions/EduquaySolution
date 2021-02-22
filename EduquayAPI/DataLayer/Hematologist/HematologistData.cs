using EduquayAPI.Models.Hematologist;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.Hematologist
{
    public class HematologistData : IHematologistData
    {

        private const string FetchSubjectsForHematologistUpdation = "SPC_FetchSubjectsForHematologistUpdation";
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
