using GymBL.Interfaces;
using GymBL.Models;
using GymRest.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private IReservationRepository repo;

        public ReservationController(IReservationRepository repo)
        {
            this.repo = repo;
        }


        [Route("NewReservation")]
        [HttpPost]


        public Reservation AddReservation([FromBody] ReservationDTO reservationDTO)
        {
            try
            {
                Reservation reservation = new Reservation
                (
                    reservationDTO.EquipmentId,
                    reservationDTO.TimeSlotId,
                    reservationDTO.Date,
                    reservationDTO.MemberId
                );

                return repo.AddReservation(reservation);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("UpdateReservation/{id}")]
        [HttpPut]

        public Reservation UpdateReservation(int id, [FromBody] ReservationDTO reservationDTO)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
