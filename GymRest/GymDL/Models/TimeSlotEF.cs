﻿namespace GymDL.Models
{
    public class TimeSlotEF
    {
        public TimeSlotEF(int timeSlotId, int startTime, int endTime, string partOfDay)
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
