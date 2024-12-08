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



        [HttpGet("{id}")]
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

        [Route("Update/{id}")]
        [HttpPut]
        public Member Update(int id, [FromBody] MemberDTO dataIn )
        {
            Member member = new Member
                (id,
                dataIn.FirstName,                
                dataIn.LastName,
      dataIn.Email,
      dataIn.Adress,
      dataIn.Birthday,
      dataIn.Interests,
      dataIn.Membertype
      );
            return repo.UpdateMemberById(id, member);
        }

    }
}

