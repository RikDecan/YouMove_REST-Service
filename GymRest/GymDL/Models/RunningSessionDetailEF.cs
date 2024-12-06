namespace GymDL.Models
{
    public class RunningSessionDetailEF
    {
        public RunningSessionDetailEF(int runningSessionId, int seqNr, int intervalTime, float intervalSpeed)
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
