﻿using GymBL.Models;
using GymDL.Exceptions;
using GymDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDL.Mappers
{
    internal class MapReservation
    {
        public static Reservation MapToDomain(ReservationEF db)
        {
            try
            {
                return new Reservation(db.ReservationId, db.EquipmentId, db.TimeSlotId, db.Date, db.MemberId);
            }
            catch (Exception ex)
            {
                throw new MapException("MapProgram - MapToDomain", ex);
            }
        }
        public static ReservationEF MapToDL(Reservation g)
        {
            try
            {
                return new ReservationEF(g.reservationId, g.EquipmentId, g.TimeSlotId, g.Date, g.MemberId);
            }
            catch (Exception ex)
            {
                throw new MapException("MapProgram - MapToDB", ex);
            }
        }
    }
}
