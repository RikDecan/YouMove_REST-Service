namespace YouMove_RikDecan.Models
{
    public class TimeSlot
    {
        public int TimeSlotId { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public string PartOfDay { get; set; }

        public TimeSlot(int startTime, int endTime, string partOfDay)//zonder Id
        {
            StartTime = startTime;
            EndTime = endTime;
            PartOfDay = partOfDay;
        }

        public TimeSlot(int timeSlotId, int startTime, int endTime, string partOfDay)//met Id
        {
            TimeSlotId = timeSlotId;
            StartTime = startTime;
            EndTime = endTime;
            PartOfDay = partOfDay;
        }

    }
}
