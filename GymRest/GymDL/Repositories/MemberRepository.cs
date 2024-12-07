using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymBL.Interfaces;
using GymBL.Models;
using GymDL.Mappers;
using GymDL.Models;

namespace GymDL.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly GymContext ctx;

        public MemberRepository(GymContext context)
        {
            ctx = context;
        }


    
        public Member GetMemberById(int id)
        {
            var member = ctx.Members.FirstOrDefault(m => m.MemberId == id );

            if (member == null) {

                throw new Exception("Member niet bestaande");
            };

            return MapMember.MapToDomain(member);
            
        }
    }
}
