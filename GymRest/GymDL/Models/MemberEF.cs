
namespace GymDL.Models
{
    public class MemberEF{
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public DateTime Birthday { get; set; }
        public string Interests { get; set; }
        public string Membertype { get; set; } 

        //ICollection<ProgramMember> ProgramMembers { get; set; }
        ICollection<CyclingsessionEF> Cyclingsessions { get; set; }
        ICollection<ReservationEF> Reservations { get; set; }
        ICollection<RunningSessionMainEF> RunningSessionMains { get; set; }
        ICollection<ProgramEF> Programs { get; set; }

    }

}
