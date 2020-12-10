using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Response.Masters;
using EduquayAPI.Models;

namespace EduquayAPI.Services
{
    public interface IBlockService
    {
        Task<AddEditResponse> AddBlock(BlockRequest bData);
        List<Block> Retrieve(int code);
        List<Block> Retrieve();
    }
}

