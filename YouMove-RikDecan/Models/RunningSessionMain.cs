namespace YouMove_RikDecan.Models
{
    public class RunningSessionMain
    {
        public int RunningSessionId { get; set; }
        public DateTime Date { get; set; }
        public int MemberId { get; set; }
        public int Duration { get; set; }
        public float AvgSpeed { get; set; }

        public RunningSessionMain(DateTime date, int memberId, int duration, float avgSpeed)// Zonder Id
        {
            Date = date;
            MemberId = memberId;
            Duration = duration;
            AvgSpeed = avgSpeed;
        }

        public RunningSessionMain(int runningSessionId, DateTime date, int memberId, int duration, float avgSpeed)//Met Id
        {
            RunningSessionId = runningSessionId;
            Date = date;
            MemberId = memberId;
            Duration = duration;
            AvgSpeed = avgSpeed;
        }
    }
}
