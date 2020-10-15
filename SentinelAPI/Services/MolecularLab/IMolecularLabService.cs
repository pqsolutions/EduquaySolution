using SentinelAPI.Contracts.V1.Request.MolecularLab;
using SentinelAPI.Contracts.V1.Response.MolecularLab;
using SentinelAPI.Models.MolecularLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Services.MolecularLab
{
    public interface IMolecularLabService
    {
        Task<MolecularLabReceiptResponse> RetrieveMolecularLabReceipts(int MolecularLabId);
        Task<MolecularReceiptResponse> AddReceivedShipment(AddMolecularLabReceiptRequest mlRequest);
        List<SubjectDetailsForTest> RetriveSubjectForMolecularTest(int molecularLabId);
        Task<AddMolecularResultResponse> AddMolecularResult(AddMolecularResultRequest mrData);
    }
}
