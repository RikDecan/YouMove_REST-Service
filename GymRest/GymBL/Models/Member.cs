
namespace GymBL.Models
{
    public class Member{
        public Member()
        {
        }

        public Member(int id, string firstName, string lastName, string email, string adress, DateTime birthday, List<string> interests, string membertype)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Adress = adress;
            Birthday = birthday;
            Interests = interests;
            Membertype = membertype;
        }

        public Member(int memberId, string firstName, string lastName, string email, string adress, DateTime birthday, List<string> list, List<Cyclingsession> cyclingsessions, List<RunningSessionMain> runningSessionMains, List<Reservation> reservations, List<ProgramBL> programBLs, string membertype)
        {
            MemberId = memberId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Adress = adress;
            Birthday = birthday;
            Cyclingsessions = cyclingsessions;
            RunningSessionMains = runningSessionMains;
            Reservations = reservations;
            Membertype = membertype;
        }

        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public DateTime Birthday { get; set; }
        public List<string> Interests { get; set; }
        public string Membertype { get; set; } 

       
        public ICollection<Cyclingsession> Cyclingsessions { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<RunningSessionMain> RunningSessionMains { get; set; }
        public ICollection<ProgramBL> Programs{ get; set; }
    }

}
