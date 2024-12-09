using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;
using GymBL.Models;
using GymBL.Services;
using GymRest.DTO;
using GymDL.Models;
using GymDL.Mappers;
using System.Diagnostics.Metrics;
using GymBL.Interfaces;
using System.Linq.Expressions;
using System.Reflection;

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
        public Member GetMemberById(int id)
        {
            try
            {
                return repo.GetMemberById(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost("NieuweMember")]

        public Member CreateMember([FromBody] MemberDTO memberDTO)
        {



            try
            {

                Member member = new Member(

                memberDTO.FirstName,
                memberDTO.LastName,
                memberDTO.Email,
                memberDTO.Adress,
                memberDTO.Birthday,
                memberDTO.Interests,
                memberDTO.Membertype

                    );
                return repo.CreateMember(member);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        //public ActionResult<Member> GetMemberById(int id)
        //{
        //    try
        //    {
        //        var member = repo.GetMemberById(id);

        //        if (member == null)
        //        {
        //            return NotFound($"No member found with id {id}");
        //        }

        //        // Log the value for debugging
        //        Console.WriteLine($"Returning member: {System.Text.Json.JsonSerializer.Serialize(member)}");

        //        return Ok(member);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Exception: {ex.Message}");
        //        return StatusCode(500, "Internal server error");
        //    }
        //}


        //  [Route("Update/{id}")]
        //  [HttpPut]
        //  public Member Update(int id, [FromBody] MemberDTO dataIn )
        //  {
        //      Member member = new Member
        //          (id,
        //          dataIn.FirstName,                
        //          dataIn.LastName,
        //          dataIn.Email,
        //          dataIn.Adress,
        //          dataIn.Birthday,
        //          dataIn.Interests,
        //          dataIn.Membertype
        //);
        //      return repo.UpdateMemberById(id, member);
        //  }

    }
}

