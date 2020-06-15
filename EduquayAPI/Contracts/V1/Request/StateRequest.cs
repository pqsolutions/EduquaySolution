﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request
{
    public class StateRequest
    {
        public string stateGovCode { get; set; }
        public string stateName { get; set; }
        public string shortName { get; set; }
        public string isActive { get; set; }
        public string comments { get; set; }
        public int createdBy { get; set; }
        public int updatedBy { get; set; }
    }
}
