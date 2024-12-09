

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymBL.Models;
using GymDL.Exceptions;
using GymDL.Models;

namespace GymDL.Mappers
{
    internal class MapCyclingsession
    {
        public static Cyclingsession MapToDomain(CyclingsessionEF db)
        {
            try
            {
                return new Cyclingsession(db.CyclingsessionId, db.Date, db.Duration, db.Avg_watt, db.Max_watt, db.Avg_cadence, db.Max_cadence, db.Trainingtype, db.Comment, db.Member_id);
            }
            catch (Exception ex)
            {
                throw new MapException("MapProgram - MapToDomain", ex);
            }
        }
        public static CyclingsessionEF MapToDB(Cyclingsession g)
        {
            try
            {
                return new CyclingsessionEF(g.CyclingsessionId, g.Date, g.Duration, g.Avg_watt, g.Max_watt, g.Avg_cadence, g.Max_cadence, g.Trainingtype, g.Comment, g.Member_id);
            }
            catch (Exception ex)
            {
                throw new MapException("MapProgram - MapToDB", ex);
            }
        }
    }
}
