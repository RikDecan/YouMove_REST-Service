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

        [HttpPost("NieuweMember")]

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



    }
}
