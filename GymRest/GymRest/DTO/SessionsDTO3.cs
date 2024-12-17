namespace GymRest.DTO
{
    public class SessionsDTO3 // aka MonthlyDTO
    {
        public int Month { get; set; }
        public int CyclingSessionsCount { get; set; }
        public int RunningSessionsCount { get; set; }
        public int TotalSessionsCount { get; set; }

    }
}
