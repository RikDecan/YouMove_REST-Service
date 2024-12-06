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

        public int RunningSessionId { get; set; }
        public DateTime Date { get; set; }
        public int MemberId { get; set; }
        public int Duration { get; set; }
        public float AvgSpeed { get; set; }

        ICollection<RunningSessionDetailEF> RunningSessionDetails { get; set; }

    }
}
