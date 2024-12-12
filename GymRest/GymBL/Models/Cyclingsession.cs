namespace GymBL.Models
{
    public class Cyclingsession
    {
        public Cyclingsession(DateTime date, double duration, double avg_watt, double max_watt, double avg_cadence, double max_cadence, string trainingtype, string comment, int member_id) //zonder id
        {
            Date = date;
            Duration = duration;
            Avg_watt = avg_watt;
            Max_watt = max_watt;
            Avg_cadence = avg_cadence;
            Max_cadence = max_cadence;
            Trainingtype = trainingtype;
            Comment = comment;
            MemberId = member_id;
        }

        public Cyclingsession(int cyclingsessionId, DateTime date, double duration, double avg_watt, double max_watt, double avg_cadence, double max_cadence, string trainingtype, string comment, int memberId) //met id
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
            MemberId = memberId;
        }

        public int CyclingsessionId { get; set; }
        public DateTime Date { get; set; }
        public double Duration { get; set; }
        public double Avg_watt { get; set; }
        public double Max_watt { get; set; }
        public double Avg_cadence  { get; set; }
        public double Max_cadence { get; set; }
        public string Trainingtype { get; set; }
        public string Comment { get; set; }
        public int MemberId { get; set; }

    }
}
