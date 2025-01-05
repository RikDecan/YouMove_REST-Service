using Moq;
using Xunit;
using GymRest.Controllers;
using GymBL.Services;
using GymRest.DTO;
using GymBL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GymRest.Tests.Controllers
{
    public class MemberControllerTests
    {
        private readonly Mock<MemberService> _mockService;
        private readonly MemberController _controller;

        public MemberControllerTests()
        {
            _mockService = new Mock<MemberService>();
            _controller = new MemberController(_mockService.Object);
        }

        [Fact]
        public void CreateMember_ReturnsCreatedMember()
        {
            var memberDTO = new MemberDTO(
                "John",
                "Doe",
                "john.doe@example.com",
                "123 Main St",
                new DateTime(1990, 1, 1),
                new List<string> { "Cycling", "Running" },  
                "Regular"
            );

            var expectedMember = new Member(
                "John",
                "Doe",
                "john.doe@example.com",
                "123 Main St",
                new DateTime(1990, 1, 1),
                new List<string> { "Cycling", "Running" },
                "Regular"
            );

            _mockService.Setup(service => service.CreateMember(It.IsAny<Member>()))
                        .Returns(expectedMember);

            var result = _controller.CreateMember(memberDTO);

            var actionResult = Assert.IsType<Member>(result);
            Assert.Equal(expectedMember.FirstName, actionResult.FirstName);
            Assert.Equal(expectedMember.LastName, actionResult.LastName);
            Assert.Equal(expectedMember.Email, actionResult.Email);
        }
    }
}
