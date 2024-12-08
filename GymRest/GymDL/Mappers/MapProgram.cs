using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymBL.Models;
using GymDL.Models;
using GymDL.Exceptions;

namespace GymDL.Mappers
{
    public static class MapProgram
    {
        public static ProgramBL MapToDomain(ProgramEF db)
        {
            try
            {
                return new ProgramBL(db.ProgramCode, db.Name, db.Target, db.StartDate, db.MaxMembers);
            }
            catch (Exception ex)
            {
                throw new MapException("MapProgram - MapToDomain", ex);
            }
        }
        public static ProgramEF MapToDB(ProgramBL g)
        {
            try
            {
                return new ProgramEF(g.ProgramCode, g.Name, g.Target, g.StartDate, g.MaxMembers);
            }
            catch (Exception ex)
            {
                throw new MapException("MapProgram - MapToDB", ex);
            }
        }
    }
}
