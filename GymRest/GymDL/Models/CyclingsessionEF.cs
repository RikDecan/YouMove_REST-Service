namespace GymDL.Models
{
    public class CyclingsessionEF
    {
        public int CyclingsessionId { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public int Avg_watt { get; set; }
        public int Max_watt { get; set; }
        public int Avg_cadence  { get; set; }
        public int Max_cadence { get; set; }
        public string Trainingtype { get; set; }
        public string Comment { get; set; }
        public int Member_id { get; set; }

    }
}
