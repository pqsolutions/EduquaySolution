using EduquayAPI.Contracts.V1.Request.MolecularLab;
using EduquayAPI.Models.MolecularLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.MolecularLab
{
    public interface IMolecularLabData
    {
        MolecularLabReceipts RetrieveMolecularLabReceipts(int molecularLabId);
        void AddReceivedShipment(AddMolecularReceiptRequest mrData);
    }

    public interface IMolecularLabDataFactory
    {
        IMolecularLabData Create();
    }
    public class MolecularLabDataFactory : IMolecularLabDataFactory
    {
        public IMolecularLabData Create()
        {
            return new MolecularLabData();
        }
    }
}
