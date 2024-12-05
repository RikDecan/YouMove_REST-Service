namespace GymDL.Models
{
    public class ProgramEF
    {
        public string ProgramCode { get; set; }
        public string Name { get; set; }
        public string Target { get; set; }
        public DateTime StartDate { get; set; }
        public int MaxMembers { get; set; }


        ICollection<MemberEF> Members { get; set; } 

    }
}
