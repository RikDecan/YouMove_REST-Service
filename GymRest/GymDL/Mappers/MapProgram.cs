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
        public static Program MapToDomain(ProgramEF db)
        {
            try
            {
                return new Program(db.ProgramCode, db.Name, db.Target, db.startDate, db.maxMembers);
            }
            catch (Exception ex)
            {
                throw new MapException("MapProgram - MapToDomain", ex);
            }
        }
        public static ProgramEF MapToDB(Program g)
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
