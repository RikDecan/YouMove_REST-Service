﻿using System.ComponentModel.DataAnnotations;

namespace GymDL.Models
{
    public class RunningSessionMainEF
    {
        public RunningSessionMainEF(int runningSessionId, DateTime date, int memberId, int duration, float avgSpeed)
        {
            RunningSessionId = runningSessionId;
            Date = date;
            MemberId = memberId;
            Duration = duration;
            AvgSpeed = avgSpeed;
        }
        [Key]

        public int RunningSessionId { get; set; }
        public DateTime Date { get; set; }
        public int MemberId { get; set; }
        public int Duration { get; set; }
        public float AvgSpeed { get; set; }

        public ICollection<RunningSessionDetailEF> RunningSessionDetails { get; set; }

    }
}
