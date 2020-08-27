﻿using EduquayAPI.Contracts.V1.Response.PMMasters;
using EduquayAPI.Models.PMMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.PNDTandMTPMaster
{
    public interface IPMMasterService
    {
        List<PMMaster> GetUserDistrict(int userId);
        List<PMMaster> GetCHCbyDistrict(int id);
        List<PMMaster> GetPHCbyCHC(int id);
        List<PMMaster> GetANMbyPHC(int id);
    }
}
