﻿using EduquayAPI.Models.AdminiSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.AdminSupport
{
    public class SACHCResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<CHCDetail> data { get; set; }
    }
}
