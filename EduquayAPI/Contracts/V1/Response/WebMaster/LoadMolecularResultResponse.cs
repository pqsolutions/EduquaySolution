using EduquayAPI.Models.LoadMasters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.WebMaster
{
    public class LoadMolecularResultResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<LoadMolecularResult> MolecularResults { get; set; }
    }
}
