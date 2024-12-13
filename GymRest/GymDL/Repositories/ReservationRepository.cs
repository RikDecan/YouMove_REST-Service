using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymBL.Interfaces;
using GymBL.Models;
using GymDL.Mappers;

namespace GymDL.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly GymContext _context;


        public ReservationRepository(GymContext context)
        {
            _context = context;
        }

        public Reservation AddReservation(Reservation reservation)
        {
            try
            {
                var reservationEF = MapReservation.MapToDL(reservation);
                _context.Reservations.Add(reservationEF);
                _context.SaveChanges();

                return reservation;
            }
            catch (Exception ex)
            {
                throw new Exception("ReservationRepository-AddReservation", ex);
            }
        }

        public Reservation UpdateReservation(int id, Reservation reservation)
        {

            var reservationDB = _context.Reservations.Find(id);


            if (reservation == null)
            {
                throw new Exception("reservation can't be null");
            }

            reservation.reservationId = id;
            _context.Entry(reservationDB).CurrentValues.SetValues
                (MapReservation.MapToDL(reservation));
            _context.SaveChanges();

            return MapReservation.MapToDomain(reservationDB);
        }
    }
}
