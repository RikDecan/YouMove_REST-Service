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
using GymDL.Exceptions;
using Microsoft.IdentityModel.Tokens;

namespace GymDL.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly GymContext _context;

        public MemberRepository(GymContext context)
        {
            _context = context;
        }

        public Member GetMemberById(int id)
        {
            try
            {
                var member = _context.Members.FirstOrDefault(m => m.MemberId == id);

                if (member == null)
                {
                    throw new Exception("Member not found");
                }

                return MapMember.MapToDomain(member);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public Member CreateMember(Member member)
        {
            var memberEF = MapMember.MapToDL(member);          

            _context.Members.Add(memberEF);

            _context.SaveChanges();

            return member;
        }

        public Member UpdateMemberById(int id, Member member)
        {
            if (member == null)
            {
                throw new ArgumentNullException(nameof(member), "Member cannot be null");
            }

            try
            {
                var memberDB = _context.Members.Find(id);

                if (memberDB == null)
                {
                    throw new MemberNotFoundException(id);
                }
                member.MemberId = id;
                _context.Entry(memberDB).CurrentValues.SetValues(MapMember.MapToDL(member));
                _context.SaveChanges();

                return MapMember.MapToDomain(memberDB);
            }
            catch (Exception ex)
            {
                throw new Exception("Member not found");
            }
        }
    }

}
