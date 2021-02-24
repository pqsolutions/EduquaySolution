using EduquayAPI.Models.Haematologist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.Haematologist
{
    public class ReviewResultResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<CVSSampleRefIdDetail> data { get; set; }
    }
}
