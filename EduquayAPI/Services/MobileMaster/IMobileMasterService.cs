using EduquayAPI.Contracts.V1.Request.Mobile;
using EduquayAPI.Contracts.V1.Response.MobileMster;
using EduquayAPI.Models.LoadMasters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.MobileMaster
{
    public interface IMobileMasterService
    {
        List<LoadCommunity> RetrieveCommunity(int id);
        Task<MobileMasterResponse> RetrieveMasters(MobileRetrieveRequest mrData);
    }
}
