using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;


namespace EduquayAPI.DataLayer
{
    public interface IBlockData
    {
        string AddBlock(BlockRequest bData);
        List<Block> Retrieve(int code);
        List<Block> Retrieve();
    }

    public interface IBlockDataFactory
    {
        IBlockData Create();
    }

    public class BlockDataFactory : IBlockDataFactory
    {
        public IBlockData Create()
        {
            return new BlockData();
        }
    }
}
