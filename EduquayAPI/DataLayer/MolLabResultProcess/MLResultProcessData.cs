using EduquayAPI.Models.MolecularLab;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.MolLabResultProcess
{
    public class MLResultProcessData : IMLResultProcessData
    {

        private const string FetchSubjectsForMolecularTest = "SPC_FetchSubjectsForMolecularTest";
        private const string FetchSubjectsForMolecularSpecimenTest = "SPC_FetchSubjectsForMolecularSpecimenTest";
        private const string FetchSubjectsForMolecularSpecimenEditTest = "SPC_FetchSubjectsForMolecularSpecimenEditTest";
        private const string FetchSubjectsForMolecularSpecimenTestComplete = "SPC_FetchSubjectsForMolecularSpecimenTestComplete";

        public MLResultProcessData()
        {

        }

        public List<MLabSpecimenForTestStatus> RetriveSpecimenForMolecularEditTest(int molecularLabId)
        {
            string stProc = FetchSubjectsForMolecularSpecimenEditTest;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@MolecularLabId", molecularLabId),
            };
            var allReceivedSubject = UtilityDL.FillData<MLabSpecimenForTestStatus>(stProc, pList);
            return allReceivedSubject;
        }

        public List<MLabSpecimenForTestStatus> RetriveSpecimenForMolecularTestComplete(int molecularLabId)
        {
            string stProc = FetchSubjectsForMolecularSpecimenTestComplete;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@MolecularLabId", molecularLabId),
            };
            var allReceivedSubject = UtilityDL.FillData<MLabSpecimenForTestStatus>(stProc, pList);
            return allReceivedSubject;
        }

        public List<MLabSpecimenForTest> RetriveSpecimenSubjectForMolecularTest(int molecularLabId)
        {
            string stProc = FetchSubjectsForMolecularSpecimenTest;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@MolecularLabId", molecularLabId),
            };
            var allReceivedSubject = UtilityDL.FillData<MLabSpecimenForTest>(stProc, pList);
            return allReceivedSubject;
        }

        public List<MolecularSubjectsForTest> RetriveSubjectForMolecularTest(int molecularLabId)
        {
            string stProc = FetchSubjectsForMolecularTest;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@MolecularLabId", molecularLabId),
            };
            var allReceivedSubject = UtilityDL.FillData<MolecularSubjectsForTest>(stProc, pList);
            return allReceivedSubject;
        }
    }
}
