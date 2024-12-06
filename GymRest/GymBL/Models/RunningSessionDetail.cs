namespace GymBL.Models
{
    public class RunningSessionDetail
    {
        public RunningSessionDetail(int seqNr, int intervalTime, float intervalSpeed)// zonder id
        {
            SeqNr = seqNr;
            IntervalTime = intervalTime;
            IntervalSpeed = intervalSpeed;
        }

        public RunningSessionDetail(int runningSessionId, int seqNr, int intervalTime, float intervalSpeed)//met id
        {
            RunningSessionId = runningSessionId;
            SeqNr = seqNr;
            IntervalTime = intervalTime;
            IntervalSpeed = intervalSpeed;
        }

        public int RunningSessionId { get; set; }
        public int SeqNr { get; set; }
        public int IntervalTime { get; set; }
        public float IntervalSpeed { get; set; }

    

    }
}
