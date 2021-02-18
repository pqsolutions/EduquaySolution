using EduquayAPI.Models.MolecularLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.MolLabResultProcess
{
    public interface IMLResultProcessService
    {
        List<MolecularSubjectsForTest> RetriveSubjectForMolecularTest(int molecularLabId);
        List<MLabSpecimenForTest> RetriveSpecimenSubjectForMolecularTest(int molecularLabId);
        List<MLabSpecimenForTestStatus> RetriveSpecimenForMolecularEditTest(int molecularLabId);
        List<MLabSpecimenForTestStatus> RetriveSpecimenForMolecularTestComplete(int molecularLabId);
    }
}
