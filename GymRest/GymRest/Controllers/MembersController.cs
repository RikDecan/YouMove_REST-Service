using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;
using GymBL.Models;
using GymBL.Services;
using GymRest.DTO;

namespace GymRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        [HttpGet(Name = "GetMemberById")]
        public ActionResult<MemberRESToutputDTO> GetMemberById(int MemberId)
        {
            Member member = MemberService.GetMember(MemberId);
            MemberRESToutputDTO dto = MapFromDomain.MapFromGemeenteDomein(url, gemeente, straatService);
            return Ok(dto);
        }




    }
}
