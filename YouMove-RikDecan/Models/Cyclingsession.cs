namespace YouMove_RikDecan.Models
{
    public class Cyclingsession
    {
        public int CyclingsessionId { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public int Avg_watt { get; set; }
        public int Aax_watt { get; set; }
        public int Avg_cadence  { get; set; }
        public int Max_cadence { get; set; }
        public string Trainingtype { get; set; }
        public string Comment { get; set; }
        public int Member_id { get; set; }

        public Cyclingsession(DateTime date, int duration, int avg_watt, int aax_watt, int avg_cadence, int max_cadence, string trainingtype, string comment, int member_id) //zonder Id 
        {
            Date = date;
            Duration = duration;
            Avg_watt = avg_watt;
            Aax_watt = aax_watt;
            Avg_cadence = avg_cadence;
            Max_cadence = max_cadence;
            Trainingtype = trainingtype;
            Comment = comment;
            Member_id = member_id;
        }

        public Cyclingsession(int cyclingsessionId, DateTime date, int duration, int avg_watt, int aax_watt, int avg_cadence, int max_cadence, string trainingtype, string comment, int member_id)//met Id
        {
            CyclingsessionId = cyclingsessionId;
            Date = date;
            Duration = duration;
            Avg_watt = avg_watt;
            Aax_watt = aax_watt;
            Avg_cadence = avg_cadence;
            Max_cadence = max_cadence;
            Trainingtype = trainingtype;
            Comment = comment;
            Member_id = member_id;
        }
    }
}
