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
    internal class MapTimeSlot
    {
        public static TimeSlot MapToDomain(TimeSlotEF db)
        {
            try
            {
                return new TimeSlot(db.TimeSlotId, db.StartTime, db.EndTime, db.PartOfDay);
            }
            catch (Exception ex)
            {
                throw new MapException("MapProgram - MapToDomain", ex);
            }
        }
        public static TimeSlotEF MapToDB(TimeSlot g)
        {
            try
            {
                return new TimeSlotEF(g.TimeSlotId, g.StartTime, g.EndTime, g.PartOfDay);
            }
            catch (Exception ex)
            {
                throw new MapException("MapProgram - MapToDB", ex);
            }
        }
    }
}
