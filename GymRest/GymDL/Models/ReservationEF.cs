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

        public int reservationId { get; set; }
        public int EquipmentId { get; set; }
        public int TimeSlotId { get; set; }
        public DateTime Date { get; set; }
        public int MemberId { get; set; }

        ICollection<EquipmentEF> Equipments { get; set; }
        ICollection<TimeSlotEF> TimeSlots { get; set; }
    }
}
