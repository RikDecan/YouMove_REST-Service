namespace GymDL.Models
{
    public class RunningSessionMain
    {
        public int RunningSessionId { get; set; }
        public DateTime Date { get; set; }
        public int MemberId { get; set; }
        public int Duration { get; set; }
        public float AvgSpeed { get; set; }


    }
}
