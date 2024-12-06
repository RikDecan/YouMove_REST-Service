namespace GymDL.Models
{
    public class CyclingsessionEF
    {
        public CyclingsessionEF(int cyclingsessionId, DateTime date, int duration, int avg_watt, int max_watt, int avg_cadence, int max_cadence, string trainingtype, string comment, int member_id)
        {
            CyclingsessionId = cyclingsessionId;
            Date = date;
            Duration = duration;
            Avg_watt = avg_watt;
            Max_watt = max_watt;
            Avg_cadence = avg_cadence;
            Max_cadence = max_cadence;
            Trainingtype = trainingtype;
            Comment = comment;
            Member_id = member_id;
        }

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
