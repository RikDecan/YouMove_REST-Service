

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
        public static Cyclingsession MapToDomain(CyclingSessionEF db)
        {
            try
            {
                return new Cyclingsession(db.CyclingSessionId, db.Date, db.Duration, db.Avg_watt, db.Max_watt, db.Avg_Cadence, db.Max_Cadence, db.TrainingType, db.Comment, db.MemberId);
            }
            catch (Exception ex)
            {
                throw new MapException("MapProgram - MapToDomain", ex);
            }
        }
        public static CyclingSessionEF MapToDB(Cyclingsession g)
        {
            try
            {
                return new CyclingSessionEF(g.CyclingsessionId, g.Date, g.Duration, g.Avg_watt, g.Max_watt, g.Avg_cadence, g.Max_cadence, g.Trainingtype, g.Comment, g.MemberId);
            }
            catch (Exception ex)
            {
                throw new MapException("MapProgram - MapToDB", ex);
            }
        }
    }
}
