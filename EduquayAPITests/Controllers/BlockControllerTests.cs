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
                districtId = 1,
                blockGovCode = "101",
                blockName = "TestBlockName",
                isActive = "true",
                comments = "TestComments",
                createdBy = 11,
                updatedBy = 10
            };

            _blocks = new List<Block> {
                    new Block
                    {
                      id= 1,
                      districtId= 1,
                      districtName= "Vellore",
                      blockGovCode= "121",
                      blockName= "pop",
                      isActive= "True",
                      comments= "TestCommentToValidate",
                      createdBy= 20,
                      updatedBy= 30
                    },
                    new Block
                    {
                      id= 2,
                      districtId= 1,
                      districtName= "Madurai",
                      blockGovCode= "1212",
                      blockName= "pop1",
                      isActive= "True",
                      comments= "string123",
                      createdBy= 10,
                      updatedBy= 20
                    }
                };

            _block = new Block
            {
                id = 2,
                districtId = 1,
                districtName = "Madurai",
                blockGovCode = "1212",
                blockName = "pop1",
                isActive = "True",
                comments = "TestComments",
                createdBy = 10,
                updatedBy = 20
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
            Assert.AreEqual("Vellore", response.Blocks[0].districtName);
            Assert.AreEqual("pop", response.Blocks[0].blockName);
            Assert.AreEqual("TestCommentToValidate", response.Blocks[0].comments);
            Assert.AreEqual("True", response.Blocks[0].isActive);
            Assert.AreEqual(20, response.Blocks[0].createdBy);
        }

        [TestMethod()]
        public void ValidateGetBlockTestById()
        {
            var response = _controller.GetBlock(2);
            Assert.AreEqual("true", response.Status);
            Assert.AreEqual("Madurai", response.Blocks[0].districtName);
            Assert.AreEqual("pop1", response.Blocks[0].blockName);
            Assert.AreEqual("TestComments", response.Blocks[0].comments);
            Assert.AreEqual("True", response.Blocks[0].isActive);
            Assert.AreEqual(10, response.Blocks[0].createdBy);
        }
    }
}
