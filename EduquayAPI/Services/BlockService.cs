using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Response.Masters;
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
        public async Task<AddEditResponse> AddBlock(BlockRequest bData)
        {
            var response = new AddEditResponse();
            try
            {
                if (string.IsNullOrEmpty(bData.blockGovCode))
                {
                    response.Status = "false";
                    response.Message = "Please enter block gov code";
                }
                else
                {
                    var addEditResponse = _blockData.AddBlock(bData);
                    response.Status = "true";
                    response.Message = addEditResponse.message;
                }
                return response;
            }
            catch (Exception e)
            {
                response.Status = "false";
                response.Message = $"Unable to process - {e.Message}";
                return response;
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
