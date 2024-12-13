using GymBL.Interfaces;
using GymRest.DTO;
using GymBL.Models;
using GymDL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        private IProgramRepository repo;

        public ProgramController(IProgramRepository repo) 
        {
            this.repo = repo;
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

                return repo.AddProgram(programBL);
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

                return repo.UpdateProgram(id, programBL);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
