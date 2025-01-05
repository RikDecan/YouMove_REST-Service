using GymRest.Controllers;
using GymBL.Models;
using GymBL.Services;
using GymRest.DTO;
using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace GymRest.Tests.Controllers
{
    public class EquipmentControllerTests
    {
        private readonly Mock<EquipmentService> _mockService;
        private readonly EquipmentController  _controller;

        public EquipmentControllerTests()
        {
            _mockService = new Mock<EquipmentService>();
            _controller = new EquipmentController(_mockService.Object);
        }

        [Fact]
        public void CreateEquipment_ReturnsCreatedEquipment()
        {
            var equipmentDTO = new EquipmentDTO("Treadmill", false); 
            var expectedEquipment = new Equipment("Treadmill", false);

            _mockService.Setup(service => service.CreateEquipment(It.IsAny<Equipment>()))
                        .Returns(expectedEquipment);

            var result = _controller.CreateEquipment(equipmentDTO);

            var actionResult = Assert.IsType<Equipment>(result);
            Assert.Equal(expectedEquipment.DeviceType, actionResult.DeviceType);
            Assert.Equal(expectedEquipment.InRepair, actionResult.InRepair);
        }

        [Fact]
        public void CreateEquipment_ThrowsException_ReturnsServerError()
        {
            var equipmentDTO = new EquipmentDTO("Treadmill", false);  

            _mockService.Setup(service => service.CreateEquipment(It.IsAny<Equipment>()))
                        .Throws(new Exception("Error occurred"));

            var exception = Assert.Throws<Exception>(() => _controller.CreateEquipment(equipmentDTO));
            Assert.Equal("Error occurred", exception.Message);
        }
    }
}
