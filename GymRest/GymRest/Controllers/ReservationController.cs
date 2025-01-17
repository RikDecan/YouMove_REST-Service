﻿using GymBL.Interfaces;
using GymBL.Models;
using GymBL.Services;
using GymRest.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private ReservationService service; //noem dit service ipv service

        

        public ReservationController(ReservationService service)
        {
            this.service = service;
        }


        [Route("NewReservation")]
        [HttpPost]


        public Reservation AddReservation([FromBody] ReservationDTO reservationDTO)
        {
          
                Reservation reservation = new Reservation
                (
                    reservationDTO.EquipmentId,
                    reservationDTO.TimeSlotId,
                    reservationDTO.Date,
                    reservationDTO.MemberId
                );

                return service.AddReservation(reservation);            
        }

        [Route("UpdateReservation/{id}")]
        [HttpPut]

        public Reservation UpdateReservation(int id, [FromBody] ReservationDTO reservationDTO)
        {           
                Reservation reservation = new Reservation
                (
                    reservationDTO.EquipmentId,
                    reservationDTO.TimeSlotId,
                    reservationDTO.Date,
                    reservationDTO.MemberId
                );

                return service.UpdateReservation(id, reservation);

            
        }

        [Route("RemoveReservation/{id}")]
        [HttpDelete]
        public bool RemoveReservation(int id)
        {
            return service.RemoveReservation(id);
        }

    }
}
