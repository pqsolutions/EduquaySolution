using EduquayAPI.DataLayer.MolLabResultProcess;
using EduquayAPI.Models.MolecularLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.MolLabResultProcess
{
    public class MLResultProcessService : IMLResultProcessService
    {

        private readonly IMLResultProcessData _mlResultProcessData;

        public MLResultProcessService(IMLResultProcessDataFactory mlReultProcessDataFactory)
        {
            _mlResultProcessData = new MLResultProcessDataFactory().Create();
        }

        public List<MLabSpecimenForTestStatus> RetriveSpecimenForMolecularEditTest(int molecularLabId)
        {
            var allSubject = _mlResultProcessData.RetriveSpecimenForMolecularEditTest(molecularLabId);
            return allSubject;
        }

        public List<MLabSpecimenForTestStatus> RetriveSpecimenForMolecularTestComplete(int molecularLabId)
        {
            var allSubject = _mlResultProcessData.RetriveSpecimenForMolecularTestComplete(molecularLabId);
            return allSubject;
        }

        public List<MLabSpecimenForTest> RetriveSpecimenSubjectForMolecularTest(int molecularLabId)
        {
            var allSubject = _mlResultProcessData.RetriveSpecimenSubjectForMolecularTest(molecularLabId);
            return allSubject;
        }

        public List<MolecularSubjectsForTest> RetriveSubjectForMolecularTest(int molecularLabId)
        {
            var allSubject = _mlResultProcessData.RetriveSubjectForMolecularTest(molecularLabId);
            return allSubject;
        }
    }
}
