using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymBL.Interfaces;
using GymBL.Models;
using GymDL.Mappers;
using GymDL.Models;
using Microsoft.EntityFrameworkCore;

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
            try
            {
                var member = ctx.Members
                    .Include(m => m.Programs)
                    .Include(m => m.Reservations)
                    .Include(m => m.CyclingSessions)
                    .Include(m => m.RunningSessionMains)
                    .FirstOrDefault(m => m.MemberId == id);

                return member != null ? MapMember.MapToDomain(member) : throw new Exception("Member is null");
            }
            catch (Exception ex)
            {
                throw new Exception("GetMember", ex);
            }

        }

        public Member UpdateMemberById(int id, Member member)
        {
            try
            {
                var memberDB = ctx.Members.Find(id);

                if (memberDB == null) { throw new Exception("UpdateMember - Member not found"); }

                ctx.Entry(memberDB).CurrentValues.SetValues(MapMember.MapToDL(member));
                ctx.SaveChanges();
                return MapMember.MapToDomain(memberDB);
            }
            catch (Exception ex)
            {

                throw new Exception("UpdateMember - Member not found", ex);
            }
            //Member member1 = new Member();
            //return member1;
        }





    }
}
