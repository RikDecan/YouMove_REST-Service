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

        private EquipmentService repo;

        public EquipmentController(EquipmentService repo)
        {
            this.repo = repo;
        }



        [HttpGet("{id}")]
        public Equipment GetEquipmentById(int id)
        {
            try
            {
                return repo.GetEquipmentById(id);
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
            return repo.GetEquipments();
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
                return repo.CreateEquipment(equipment);
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
                return repo.ToggleEquipmentInService(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
