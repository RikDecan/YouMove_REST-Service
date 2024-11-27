namespace YouMove_RikDecan.Models
{
    public class ProgramMembers
    {
        public ProgramMembers(int memberId) //zonder Id
        {
            MemberId = memberId;
        }

        public ProgramMembers(string programCode, int memberId) //met Id
        {
            ProgramCode = programCode;
            MemberId = memberId;
        }

        public string ProgramCode { get; set; }
        public int MemberId { get; set; }
    }
}
