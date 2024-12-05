namespace GymDL.Models
{
    public class RunningSessionMainEF
    {
        public int RunningSessionId { get; set; }
        public DateTime Date { get; set; }
        public int MemberId { get; set; }
        public int Duration { get; set; }
        public float AvgSpeed { get; set; }

        ICollection<RunningSessionDetailEF> RunningSessionDetails { get; set; }

    }
}
