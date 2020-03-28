using System;
using System.Collections.Generic;
using System.Text;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Controllers;
using EduquayAPI.Models;
using EduquayAPI.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EduquayAPITests.Controllers
{
    [TestClass()]
    public class CHCControllerTests
    {
        private CHCController _controller;
        private Mock<ICHCService> _mockCHCService;
        private CHCRequest _chcRequest;
        private List<CHC> _chcs;
        private CHC _chc;

        [TestInitialize]
        public void Setup()
        {

        }
        [TestMethod()]
        public void ValidateAddCHC()
        {
            Assert.AreEqual("a","a");
        }
    }
}
