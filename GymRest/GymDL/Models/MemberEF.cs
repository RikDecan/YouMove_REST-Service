
using System.ComponentModel.DataAnnotations;

namespace GymDL.Models
{
    public class MemberEF{
        public MemberEF()
        {
        }

        public MemberEF(string firstName, string lastName, string email, string adress, DateTime birthday, List<string> list, List<CyclingsessionEF> cyclingsessionEFs, List<RunningSessionMainEF> runningSessionMainEFs, List<ProgramEF> programEFs, string membertype) //zonder MemberId
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Adress = adress;
            Birthday = birthday;
            Membertype = membertype;
        }

        public MemberEF(int? memberId, string firstName, string lastName, string email, string adress, DateTime birthday, List<string> interests, List<CyclingsessionEF> cyclingsessionEFs, List<RunningSessionMainEF> runningSessionMainEFs, List<ProgramEF> programEFs, string membertype) //Met MemberId zonder ICOllections
        {
            MemberId = memberId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Adress = adress;
            Birthday = birthday;
            Interests = interests;
            Membertype = membertype;
        }

        public MemberEF(int? memberId, string firstName, string lastName, string email, string adress, DateTime birthday, List<string> interests, string membertype, ICollection<CyclingsessionEF> cyclingSessions, ICollection<ReservationEF> reservations, ICollection<RunningSessionMainEF> runningSessionMains, ICollection<ProgramEF> programs) //zonder MemberId met ICOllections
        {
            MemberId = memberId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Adress = adress;
            Birthday = birthday;
            Interests = interests;
            Membertype = membertype;
            CyclingSessions = cyclingSessions;
            Reservations = reservations;
            RunningSessionMains = runningSessionMains;
            Programs = programs;
        }

        [Key]

        public int? MemberId  { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public DateTime Birthday { get; set; }
        public List<string> Interests { get; set; }
        public string Membertype { get; set; } 

        //ICollection<ProgramMember> ProgramMembers { get; set; }
        public ICollection<CyclingsessionEF> CyclingSessions { get; set; }
        public ICollection<ReservationEF> Reservations { get; set; }
        public ICollection<RunningSessionMainEF> RunningSessionMains { get; set; }
        public ICollection<ProgramEF> Programs{ get; set; }
    }

}
