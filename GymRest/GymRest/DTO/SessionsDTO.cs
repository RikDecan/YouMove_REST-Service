using GymBL.Models;

namespace GymRest.DTO
{
    public class SessionsDTO
    {
        public List <Cyclingsession> Cyclingsessions { get; set; }
        public List<RunningSessionMain> RunningSessions { get; set; }
        public string Impact { get; set;  }

    }
}
