using EduquayAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using EduquayAPI.Services;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EduquayAPITests.Controllers
{
    [TestClass()]
    public class BlockControllerTests
    {
        private BlockController _controller;
        private Mock<IBlockService> _mockBlockService;
        private BlockRequest _blockRequest;
        private List<Block> _blocks;
        private Block _block;

        [TestInitialize]
        public void SetUp()
        {
            _blockRequest = new BlockRequest
            {
                DistrictId = 1,
                Block_gov_code = "101",
                Blockname = "TestBlockName",
                IsActive = "true",
                Comments = "TestComments",
                CreatedBy = 11,
                UpdatedBy = 10
            };

            _blocks = new List<Block> {
                    new Block
                    {
                      Id= 1,
                      DistrictId= 1,
                      DistrictName= "Vellore",
                      Block_gov_code= "121",
                      Blockname= "pop",
                      IsActive= "True",
                      Comments= "TestCommentToValidate",
                      CreatedBy= 20,
                      UpdatedBy= 30
                    },
                    new Block
                    {
                      Id= 2,
                      DistrictId= 1,
                      DistrictName= "Madurai",
                      Block_gov_code= "1212",
                      Blockname= "pop1",
                      IsActive= "True",
                      Comments= "string123",
                      CreatedBy= 10,
                      UpdatedBy= 20
                    }
                };

            _block = new Block
            {
                Id = 2,
                DistrictId = 1,
                DistrictName = "Madurai",
                Block_gov_code = "1212",
                Blockname = "pop1",
                IsActive = "True",
                Comments = "TestComments",
                CreatedBy = 10,
                UpdatedBy = 20
            };


            //Arrange
            _mockBlockService = new Mock<IBlockService>();
            _mockBlockService.Setup(_ => _.AddBlock(It.IsAny<BlockRequest>())).Returns(() => "Data successfully added");
            _mockBlockService.Setup(_ => _.Retrieve()).Returns(_blocks);
            _mockBlockService.Setup(_ => _.Retrieve(It.IsAny<int>())).Returns(_blocks);
            _mockBlockService.Setup(_ => _.Retrieve(It.IsAny<int>())).Returns(new List<Block> { _block });
            _controller = new BlockController(_mockBlockService.Object);
        }


        [TestMethod()]
        public void ValidateAddBlock()
        {
            var expected = "Data successfully added";
            var result = _controller.AddBlock(_blockRequest);
            Assert.AreEqual(expected, result.Value);
        }

        [TestMethod()]
        public void ValidateAddBlockReturnsException()
        {
            //Arrange
            _mockBlockService.Setup(_ => _.AddBlock(It.IsAny<BlockRequest>())).Throws(new Exception("Invalid input"));
            var expected = "Unable to add block data - Invalid input";
            //Act
            var result = _controller.AddBlock(_blockRequest);
            //Assert
            Assert.AreEqual(expected, result.Value);
        }

        [TestMethod()]
        public void ValidateGetBlocksTest()
        {
            var response = _controller.GetBlocks();
            Assert.IsNotNull(response);
            Assert.AreEqual("true", response.Status);
            Assert.AreEqual(2, response.Blocks.Count);
            Assert.AreEqual("Vellore", response.Blocks[0].DistrictName);
            Assert.AreEqual("pop", response.Blocks[0].Blockname);
            Assert.AreEqual("TestCommentToValidate", response.Blocks[0].Comments);
            Assert.AreEqual("True", response.Blocks[0].IsActive);
            Assert.AreEqual(20, response.Blocks[0].CreatedBy);
        }

        [TestMethod()]
        public void ValidateGetBlockTestById()
        {
            var response = _controller.GetBlock(2);
            Assert.AreEqual("true", response.Status);
            Assert.AreEqual("Madurai", response.Blocks[0].DistrictName);
            Assert.AreEqual("pop1", response.Blocks[0].Blockname);
            Assert.AreEqual("TestComments", response.Blocks[0].Comments);
            Assert.AreEqual("True", response.Blocks[0].IsActive);
            Assert.AreEqual(10, response.Blocks[0].CreatedBy);
        }
    }
}
