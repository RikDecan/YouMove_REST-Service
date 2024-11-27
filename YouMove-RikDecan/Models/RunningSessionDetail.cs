namespace YouMove_RikDecan.Models
{
    public class RunningSessionDetail
    {
        public int RunningSessionId { get; set; }
        public int SeqNr { get; set; }
        public int IntervalTime { get; set; }
        public float IntervalSpeed { get; set; }

        public RunningSessionDetail(int seqNr, int intervalTime, float intervalSpeed) // zonder Id
        {
            SeqNr = seqNr;
            IntervalTime = intervalTime;
            IntervalSpeed = intervalSpeed;
        }

        public RunningSessionDetail(int runningSessionId, int seqNr, int intervalTime, float intervalSpeed) //met Id
        {
            RunningSessionId = runningSessionId;
            SeqNr = seqNr;
            IntervalTime = intervalTime;
            IntervalSpeed = intervalSpeed;
        }

    }
}
