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
    }
}
