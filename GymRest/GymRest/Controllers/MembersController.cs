using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;
using GymBL.Models;
using GymBL.Services;
using GymRest.DTO;
using GymDL.Models;
using GymDL.Mappers;
using System.Diagnostics.Metrics;
using GymBL.Interfaces;

namespace GymRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private IMemberRepository repo;

        public MemberController(IMemberRepository repo)
        {
            this.repo = repo;
        }


        //[HttpGet]
        //[HttpHead]
        //public IEnumerable<Country> Get()
        //{
        //    return repo.GetAll();
        //}

        [HttpGet("{id}")]
        [HttpHead("{id}")]
        public ActionResult<Member> GetMemberById(int id)
        {
            try
            {
                return repo.GetMemberById(id);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

