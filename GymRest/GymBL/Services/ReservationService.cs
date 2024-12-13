using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymBL.Interfaces;
using GymBL.Models;

namespace GymBL.Services
{
    public class ReservationService
    {
        private IReservationRepository repo;

        public ReservationService(IReservationRepository repo) 
        {
            this.repo = repo;
        }
        public Reservation AddReservation(Reservation reservation)
        {
            try
            {
                return repo.AddReservation(reservation);

            }
            catch (Exception ex)
            {

                throw new Exception("ReservationService-AddReservation", ex);
            }
        }
        public Reservation UpdateReservation(int id, Reservation reservation)
        {
            try
            {
                return repo.UpdateReservation(id, reservation);
            }
            catch (Exception ex)
            {
                throw new Exception("ReservationService-UpdateReservation", ex);
            }
        }
    }
}
