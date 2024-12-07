using System.ComponentModel.DataAnnotations;

namespace GymDL.Models
{
    public class ReservationEF
    {
        public ReservationEF(int reservationId, int equipmentId, int timeSlotId, DateTime date, int memberId)
        {
            this.reservationId = reservationId;
            EquipmentId = equipmentId;
            TimeSlotId = timeSlotId;
            Date = date;
            MemberId = memberId;
        }
        [Key]

        public int reservationId { get; set; }
        public int EquipmentId { get; set; }
        public int TimeSlotId { get; set; }
        public DateTime Date { get; set; }
        public int MemberId { get; set; }

        public ICollection<EquipmentEF> Equipments { get; set; }
        public ICollection<TimeSlotEF> TimeSlots { get; set; }
    }
}
