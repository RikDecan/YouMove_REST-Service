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
                bool IsUpdating = false;

                ReservationChecker(reservation, isExistingReservation: false , IsUpdating);
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

                bool IsUpdating = true;

                ReservationChecker(reservation, isExistingReservation: false, IsUpdating);
                return repo.UpdateReservation(id, reservation);
            }
            catch (Exception ex)
            {
                throw new Exception("ReservationService-UpdateReservation", ex);
            }
        }

        public bool RemoveReservation(int id)
        {
            try
            {
                return repo.RemoveReservation(id);
            }
            catch (Exception ex)
            {
                throw new Exception("ReservationService-RemoveReservation", ex);
            }
        }



        public void ReservationChecker(Reservation reservation, bool isExistingReservation, bool IsUpdating)
        {
            if (reservation == null)
            {
                throw new Exception("Reservation can't be null");
            }

            if (reservation.Date > DateTime.Now.AddDays(7))
            {
                throw new Exception("Resvation can't be more than 7 days ahead");
            }

            var equipment = repo.GetEquipmentById(reservation.EquipmentId);
            if (equipment == null)
            {
                throw new Exception("Equipment doesn't  exist");
            }
                  


            if (equipment.InRepair)
            {
                throw new Exception("Equipment out of service (for the time being), pick a different Device/Equipment");
            }

            var timeslot = repo.GetTimeSlotById(reservation.TimeSlotId);
            if (timeslot == null)
            {
                throw new Exception("Timeslot doesn't exist");
            }


            if (!IsUpdating)
            {
                var memberReservations = repo.GetReservationsByMemberAndDate(reservation.MemberId, reservation.Date);
                if (memberReservations.Count() >= 4 && !isExistingReservation)
                {
                    throw new Exception("Members can only have up to 4 reservations a day");
                }
            }
            


            var equipmentReservations = repo.GetReservationsByEquipmentAndDate(reservation.EquipmentId, reservation.Date, reservation.TimeSlotId);
            if (equipmentReservations.Any(r => r.TimeSlotId == reservation.TimeSlotId))
            {
                throw new Exception("Equipment already reserved in this TimeSlot");
            }

            var memberEquipmentReservations = equipmentReservations
                .Where(r => r.MemberId == reservation.MemberId)
                .Select(r => r.TimeSlotId)
                .ToList();

            memberEquipmentReservations.Add(reservation.TimeSlotId);
            memberEquipmentReservations.Sort();

            for (int i = 0; i < memberEquipmentReservations.Count -2; i++)
            {
                if (memberEquipmentReservations[i+1] - memberEquipmentReservations[i] == 1 && memberEquipmentReservations[i+2] - memberEquipmentReservations[i+1] == 1)
                {
                    throw new Exception("Equipment can't be reserved thee times in a row");
                }
                
            }

        }
    }
}


