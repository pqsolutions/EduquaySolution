using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.DataLayer;
using EduquayAPI.Models;

namespace EduquayAPI.Services
{
    public class BlockService : IBlockService
    {

        private readonly IBlockData _blockData;

        public BlockService(IBlockDataFactory blockDataFactory)
        {
            _blockData = new BlockDataFactory().Create();
        }
        public string AddBlock(BlockRequest bData)
        {
            try
            {
                if (bData.districtId <= 0)
                {
                    return "Invalid District Id";
                }
                if (bData.isActive.ToLower() != "true")
                {
                    bData.isActive = "false";
                }

                var result = _blockData.AddBlock(bData);
                return string.IsNullOrEmpty(result) ? $"Unable to add block data" : result;
            }
            catch (Exception e)
            {
                return $"Unable to add block data - {e.Message}";
            }

        }

        public List<Block> Retrieve(int code)
        {
            var block = _blockData.Retrieve(code);
            return block;
        }

        public List<Block> Retrieve()
        {
            var allBlocks = _blockData.Retrieve();
            return allBlocks;
        }
    }
}
