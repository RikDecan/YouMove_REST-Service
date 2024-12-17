using GymBL.Models;

namespace GymRest.DTO
{
    public class SessionsDTO2
    {

        public int SessionsAmount { get; set; } // aantal sessies
        public double TotalDuration { get; set; } //in uren
        public double AvgDuration{ get; set; }
        public double LongestSession { get; set; }
        public double ShortestSession { get; set; }

    }
}
