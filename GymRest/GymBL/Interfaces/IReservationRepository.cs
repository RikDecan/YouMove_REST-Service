using GymBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBL.Interfaces
{
    public interface IReservationRepository
    {
        public Reservation AddReservation(Reservation reservation);
        public Reservation UpdateReservation(int id, Reservation reservation);

        //testen hier -> doe weg als niet werken mattie je weet ze
        Equipment GetEquipmentById(int equipmentId);
        TimeSlot GetTimeSlotById(int timeSlotId);
        List<Reservation> GetReservationsByMemberAndDate(int memberId, DateTime date);
        List<Reservation> GetReservationsByEquipmentAndDate(int equipmentId, DateTime date, int timeSlotId);
        public bool RemoveReservation(int id);
    }
}
