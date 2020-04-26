using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;

namespace EduquayAPI.Services
{
    public interface IBlockService
    {
        string AddBlock(BlockRequest bData);
        List<Block> Retrieve(int code);
        List<Block> Retrieve();
    }
}

