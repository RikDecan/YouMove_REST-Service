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

        [Route("GetMemberById/{id}")]
        [HttpGet]
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

        [Route("GetMembers")]
        [HttpGet]
        public List<Member> GetMembers()
        {
            return repo.GetMembers();
        }

        [Route("RemoveMember/{id}")]
        [HttpDelete]
        public bool RemoveMember(int id)
        {
            return repo.RemoveMember(id);
        }

        [Route("NieuweMember")]
        [HttpPost]

        public Member CreateMember([FromBody] MemberDTO memberDTO)
        {
                Member member = new Member
                (
                memberDTO.FirstName,
                memberDTO.LastName,
                memberDTO.Email,
                memberDTO.Address,
                memberDTO.Birthday,
                memberDTO.Interests,
                memberDTO.Membertype
                );
                return repo.CreateMember(member);
        }

        [Route("UpdateMember/{id}")]
        [HttpPut]

        public Member UpdateMemberById(int id, [FromBody] MemberDTO memberDTO)
        {
            try
            {
                Member member = new Member(

                memberDTO.FirstName,
                memberDTO.LastName,
                memberDTO.Email,
                memberDTO.Address,
                memberDTO.Birthday,
                memberDTO.Interests,
                memberDTO.Membertype

                    );
                return repo.UpdateMemberById(id, member);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}

