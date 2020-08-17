using EduquayAPI.Contracts.V1.Request.MolecularLab;
using EduquayAPI.Contracts.V1.Response.MolecularLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.MolecularLab
{
    public interface IMolecularLabService
    {
        Task<MolecularLabReceiptResponse> RetrieveMolecularLabReceipts(int MolecularLabId);
        Task<MolecularReceiptResponse> AddReceivedShipment(AddMolecularLabReceiptRequest mlRequest);

    }
}
