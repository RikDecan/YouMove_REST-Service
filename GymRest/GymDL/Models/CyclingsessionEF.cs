using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace GymDL.Models
{
    public class CyclingSessionEF
    {

        public CyclingSessionEF()
        {
            
        }
        public CyclingSessionEF(int cyclingSessionId, DateTime date, double duration, double avgWatt, double maxWatt, double avgCadence, double maxCadence, string trainingType, string comment, int member_id)
        {
            CyclingSessionId = cyclingSessionId;
            Date = date;
            Duration = duration;
            Avg_watt = avgWatt;
            Max_watt = maxWatt;
            Avg_Cadence = avgCadence;
            Max_Cadence = maxCadence;
            TrainingType = trainingType;
            Comment = comment;
            MemberId = member_id;
        }


        [Key]
        public int CyclingSessionId { get; set; }
        public DateTime Date { get; set; }
        public double Duration { get; set; }
        public double Avg_watt { get; set; }
        public double Max_watt { get; set; }
        public double Avg_Cadence { get; set; }
        public double Max_Cadence { get; set; }
        public string TrainingType { get; set; }
        public string? Comment { get; set; }
        public int MemberId { get; set; }
        public MemberEF Member { get; set; }

    }
}
