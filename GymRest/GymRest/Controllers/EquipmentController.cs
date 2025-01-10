using GymBL.Interfaces;
using GymBL.Models;
using GymBL.Services;
using GymRest.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {

        private EquipmentService service;

        public EquipmentController(EquipmentService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public Equipment GetEquipmentById(int id)
        {
            try
            {
                return service.GetEquipmentById(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("GetEquipments")]
        [HttpGet]

        public List<Equipment> GetEquipments()
        {
            return service.GetEquipments();
        }


        [HttpPost("NewEquipment")]

        public Equipment CreateEquipment([FromBody] EquipmentDTO equipmentDTO)
        {

            try
            {

                Equipment equipment = new Equipment(

                equipmentDTO.DeviceType,
                equipmentDTO.InRepair

                    );
                return service.CreateEquipment(equipment);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("ToggleEquipmentService/{id}")]
        [HttpPut]
        public Equipment ToggleEquipmentInService(int id)
        {
            try
            {
                return service.ToggleEquipmentInService(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
