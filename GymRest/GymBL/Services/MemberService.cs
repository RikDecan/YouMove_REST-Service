using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymBL.Interfaces;
using GymBL.Models;

namespace GymBL.Services
{
    public class MemberService
    {
        private IMemberRepository repo;

        public MemberService(IMemberRepository repo)
        {
            this.repo = repo;
        }

        public Member GetMember(int id)
        {
            try
            {
                return repo.GetMemberById(id);
            }
            catch (Exception ex)
            {
                throw new Exception("GeefAdres", ex);
            }
        }




    }
}
