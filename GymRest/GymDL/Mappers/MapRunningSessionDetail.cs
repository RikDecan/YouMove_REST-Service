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
    internal class MapRunningSessionDetail
    {
             public static RunningSessionDetail MapToDomain(RunningSessionDetailEF db)
        {
            try
            {
                return new RunningSessionDetail(db.RunningSessionId, db.SeqNr, db.IntervalTime, db.IntervalSpeed);
            }
            catch (Exception ex)
            {
                throw new MapException("MapProgram - MapToDomain", ex);
            }
        }
        public static RunningSessionDetailEF MapToDL(RunningSessionDetail g)
        {
            try
            {
                return new RunningSessionDetailEF(g.RunningSessionId, g.SeqNr, g.IntervalTime, g.IntervalSpeed);
            }
            catch (Exception ex)
            {
                throw new MapException("MapProgram - MapToDB", ex);
            }
        }
    }
}
