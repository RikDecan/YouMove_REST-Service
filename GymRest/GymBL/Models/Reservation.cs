namespace GymDL.Models
{
    public class Reservation
    {
        public int reservationId { get; set; }
        public int EquipmentId { get; set; }
        public int TimeSlotId { get; set; }
        public DateTime Date { get; set; }
        public int MemberId { get; set; }

        ICollection<Equipment> Equipments { get; set; }
        ICollection<TimeSlot> TimeSlots { get; set; }
    }
}
