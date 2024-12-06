namespace GymBL.Models
{
    public class TimeSlot
    {
        public TimeSlot(int startTime, int endTime, string partOfDay)//zonder id
        {
            StartTime = startTime;
            EndTime = endTime;
            PartOfDay = partOfDay;
        }

        public TimeSlot(int timeSlotId, int startTime, int endTime, string partOfDay)//met id
        {
            TimeSlotId = timeSlotId;
            StartTime = startTime;
            EndTime = endTime;
            PartOfDay = partOfDay;
        }

        public int TimeSlotId { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public string PartOfDay { get; set; }

    }
}
