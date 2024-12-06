namespace GymBL.Models
{
    public class Reservation
    {
        public Reservation(int equipmentId, int timeSlotId, DateTime date, int memberId) //zonder id
        {
            EquipmentId = equipmentId;
            TimeSlotId = timeSlotId;
            Date = date;
            MemberId = memberId;
        }

        public Reservation(int reservationId, int equipmentId, int timeSlotId, DateTime date, int memberId) //met id
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
    }
}
