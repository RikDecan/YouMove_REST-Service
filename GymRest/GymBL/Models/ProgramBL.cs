namespace GymBL.Models
{
    public class ProgramBL
    {
        public ProgramBL(int programCode, string name)
        {
            ProgramCode = programCode;
            Name = name;
        }

        public ProgramBL(string name, string target, DateTime startDate, int maxMembers)//zonder id
        {
            Name = name;
            Target = target;
            StartDate = startDate;
            MaxMembers = maxMembers;
        }

        public ProgramBL(int programCode, string name, string target, DateTime startDate, int maxMembers)//met id
        {
            ProgramCode = programCode;
            Name = name;
            Target = target;
            StartDate = startDate;
            MaxMembers = maxMembers;
        }

        public int ProgramCode { get; set; }
        public string Name { get; set; }
        public string Target { get; set; }
        public DateTime StartDate { get; set; }
        public int MaxMembers { get; set; }

 
    }
}
