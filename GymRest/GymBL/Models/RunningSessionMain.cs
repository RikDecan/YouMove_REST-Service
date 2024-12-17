namespace GymBL.Models
{
    public class RunningSessionMain
    {

        public RunningSessionMain()
        {
                
        }

        public RunningSessionMain(DateTime date, int memberId, int duration, float avgSpeed)//zonder id
        {
            Date = date;
            MemberId = memberId;
            Duration = duration;
            AvgSpeed = avgSpeed;
        }

        public RunningSessionMain(int runningSessionId, DateTime date, int memberId, int duration, float avgSpeed)//met id 
        {
            RunningSessionId = runningSessionId;
            Date = date;
            MemberId = memberId;
            Duration = duration;
            AvgSpeed = avgSpeed;
        }

        public RunningSessionMain(int runningSessionId, DateTime date, int memberId, int duration, float avgSpeed, List<RunningSessionDetail> details) : this(runningSessionId, date, memberId, duration, avgSpeed)
        {
            Details = details;
        }

        public int RunningSessionId { get; set; }
        public DateTime Date { get; set; }
        public int MemberId { get; set; }
        public int Duration { get; set; }
        public float AvgSpeed { get; set; }

        public List<RunningSessionDetail> Details { get; set; } = new List<RunningSessionDetail>();


    }
}
