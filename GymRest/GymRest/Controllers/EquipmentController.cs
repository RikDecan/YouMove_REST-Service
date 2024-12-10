using GymBL.Interfaces;
using GymBL.Models;
using GymRest.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {

        private IEquipmentRepository repo;

        public EquipmentController(IEquipmentRepository repo)
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


        [HttpPost("NewEquipment")]

        public Equipment CreateEquipment([FromBody] EquipmentDTO equipmentDTO)
        {

            try
            {

                Equipment equipment = new Equipment(

                equipmentDTO.DeviceType,
                equipmentDTO.InService

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

        //[Route("UpdateEquipment/{id}")]
        //[HttpPut]

        //public Equipment UpdateEquipmentById(int id, [FromBody] EquipmentDTO equipmentDTO) 
        //{
        //    try
        //    {
        //        Equipment equipment = new Equipment(

        //        equipmentDTO.InService


        //            );
        //        return repo.UpdateEquipmentById(id, equipment);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}



    }
}
