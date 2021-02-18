using EduquayAPI.Models.MolecularLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.MolLabResultProcess
{
    public interface IMLResultProcessData
    {
        List<MolecularSubjectsForTest> RetriveSubjectForMolecularTest(int molecularLabId);
        List<MLabSpecimenForTest> RetriveSpecimenSubjectForMolecularTest(int molecularLabId);
        List<MLabSpecimenForTestStatus> RetriveSpecimenForMolecularEditTest(int molecularLabId);
        List<MLabSpecimenForTestStatus> RetriveSpecimenForMolecularTestComplete(int molecularLabId);
    }

    public interface IMLResultProcessDataFactory
    {
        IMLResultProcessData Create();
    }
    public class MLResultProcessDataFactory : IMLResultProcessDataFactory
    {
        public IMLResultProcessData Create()
        {
            return new MLResultProcessData();
        }
    }
}
