using GymBL.Models;
using GymDL.Exceptions;
using GymDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDL.Mappers
{
    public class MapMember
    {

        public static Member MapToDomain(MemberEF db)
        {
            try
            {
                return new Member(db.MemberId, db.FirstName, db.LastName, db.Email, db.Adress, db.Birthday, db.Interests, db.Membertype);
            }
            catch (Exception ex)
            {
                throw new MapException("MapProgram - MapToDomain", ex);
            }
        }
        public static MemberEF MapToDB(Member g)
        {
            try
            {
                return new MemberEF(g.MemberId, g.FirstName, g.LastName, g.Email, g.Adress, g.Birthday, g.Interests, g.Membertype);
            }
            catch (Exception ex)
            {
                throw new MapException("MapProgram - MapToDB", ex);
            }
        }

        
    }
}
