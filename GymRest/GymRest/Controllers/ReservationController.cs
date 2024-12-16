using GymBL.Interfaces;
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
        private ReservationService repo;

        

        public ReservationController(ReservationService repo)
        {
            this.repo = repo;
        }


        [Route("NewReservation")]
        [HttpPost]


        public Reservation AddReservation([FromBody] ReservationDTO reservationDTO)
        {            
                Reservation reservation = new Reservation
                (
                    reservationDTO.EquipmentId,
                    reservationDTO.TimeSlotId,
                    reservationDTO.Date,+
                    reservationDTO.MemberId
                );

                return repo.AddReservation(reservation);            
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

                return repo.UpdateReservation(id, reservation);

            
        }

    }
}
