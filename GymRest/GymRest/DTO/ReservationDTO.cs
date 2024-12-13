namespace GymRest.DTO
{
    public class ReservationDTO
    {
        public ReservationDTO(int equipmentId, int timeSlotId, DateTime date, int memberId)
        {
            EquipmentId = equipmentId;
            TimeSlotId = timeSlotId;
            Date = date;
            MemberId = memberId;
        }

        public int EquipmentId { get; set; }
        public int TimeSlotId { get; set; }
        public DateTime Date { get; set; }
        public int MemberId { get; set; }
    }
}
