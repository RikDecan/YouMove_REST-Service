namespace YouMove_RikDecan.Models
{
    public class Program
    {
        public string ProgramCode { get; set; }
        public string Name { get; set; }
        public string Target { get; set; }
        public DateTime StartDate { get; set; }
        public int MaxMembers { get; set; }

        public Program(string name, string target, DateTime startDate, int maxMembers) //zonder Id
        {
            Name = name;
            Target = target;
            StartDate = startDate;
            MaxMembers = maxMembers;
        }

        public Program(string programCode, string name, string target, DateTime startDate, int maxMembers)// met Id
        {
            ProgramCode = programCode;
            Name = name;
            Target = target;
            StartDate = startDate;
            MaxMembers = maxMembers;
        }


    }
}
