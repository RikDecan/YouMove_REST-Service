
namespace GymDL.Models
{
    public class Member{
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public DateTime Birthday { get; set; }
        public string Interests { get; set; }
        public string Membertype { get; set; } 

        ICollection<ProgramMember> ProgramMembers { get; set; }
        ICollection<Cyclingsession> Cyclingsessions { get; set; }
        ICollection<Reservation> Reservations { get; set; }
        ICollection<RunningSessionMain> RunningSessionMains { get; set; }            

    }

}
