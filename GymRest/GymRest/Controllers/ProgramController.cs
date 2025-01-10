using GymBL.Interfaces;
using GymRest.DTO;
using GymBL.Models;
using GymDL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GymBL.Services;

namespace GymRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        private ProgramService service;

        public ProgramController(ProgramService service) 
        {
            this.service = service;
        }


        [Route("NewProgram")]
        [HttpPost]

        public ProgramBL AddProgram([FromBody] ProgramDTO programDTO)
        {
            try
            {

                ProgramBL programBL = new ProgramBL
                (
           
                    programDTO.Name,
                    programDTO.Target,
                    programDTO.StartDate, 
                    programDTO.MaxMembers
                );

                return service.AddProgram(programBL);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [Route("UpdateProgram/{id}")]
        [HttpPut]

        public ProgramBL UpdateProgram(int id, [FromBody] ProgramDTO programDTO)
        {
            try
            {
                ProgramBL programBL = new ProgramBL
                (
                    programDTO.Name,
                    programDTO.Target,
                    programDTO.StartDate,
                    programDTO.MaxMembers
                );

                return service.UpdateProgram(id, programBL);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
