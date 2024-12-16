using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymBL.Interfaces;
using GymBL.Models;
using GymDL.Mappers;
using GymDL.Models;
using Microsoft.EntityFrameworkCore;

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
        public List<Reservation> GetReservationsByMemberAndDate( int memberId, DateTime date)
        {
            var reservations = _context.Reservations.Include(r => r.TimeSlot).Include(r => r.Equipment).Where(r => r.Date == date && r.MemberId == memberId).Select(r => MapReservation.MapToDomain(r)).ToList();

            return reservations;
        }

        public List<Reservation> GetReservationsByEquipmentAndDate(int equipmentId, DateTime date, int timeSlotId)
        {
            var reservations = _context.Reservations.Include(r => r.TimeSlot).Include(r => r.Equipment).Where(r => r.Date == date  && r.EquipmentId == equipmentId).Select(r => MapReservation.MapToDomain(r)).ToList();

            return reservations;
        }

        public TimeSlot GetTimeSlotById(int id)
        {
            var timeSlot = _context.timeSlots.Find(id);

            return MapTimeSlot.MapToDomain(timeSlot);
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

        public Equipment CreateEquipment(Equipment equipment)
        {
            var equipmentEF = MapEquipment.MapToDL(equipment);

            _context.Equipment.Add(equipmentEF);

            _context.SaveChanges();

            return equipment;
        }

        public Equipment GetEquipmentById(int id)
        {
                var equipment = _context.Equipment.FirstOrDefault(e => e.EquipmentId == id);
                if (equipment == null)
                {
                    throw new Exception("Equipment not found");
                }

                return MapEquipment.MapToDomain(equipment);           
        }
    }
}
