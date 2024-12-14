
using GymBL.Models;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace GymDL.Models
{
    public class MemberEF
    {
        public MemberEF()
        {
        }

        public MemberEF(int? memberId, string firstName, string lastName, string email, string adress, DateTime birthday, List<string> interests, object value, List<RunningSessionMainEF> runningSessionMainEFs, List<ProgramEF> programEFs, string membertype)
        {
            MemberId = memberId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = adress;
            Birthday = birthday;
            Interests = interests;
            MemberType = membertype;
        }

        public MemberEF(int?  memberId, string firstName, string lastName, string email, string address, DateTime birthday, List<string> interests, ICollection<CyclingSessionEF> cyclingSessionEFs, ICollection<RunningSessionMainEF> runningSessionMainEFs, ICollection<ReservationEF> reservationEFs, ICollection<ProgramEF> programModelEFs, string memberType)
        {
            MemberId = memberId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
            Birthday = birthday;
            Interests = interests;
            CyclingSessions = cyclingSessionEFs;
            RunningSessions = runningSessionMainEFs;
            Reservations = reservationEFs;
            Programs = programModelEFs;
            MemberType = memberType;
        }

        [Key]
        public int ? MemberId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        public List<string> ? Interests { get; set; }
        [Required]
        public string MemberType { get; set; }
        public ICollection<ProgramEF> Programs { get; set; }
        public ICollection<ReservationEF> Reservations { get; set; }
        public ICollection<CyclingSessionEF> CyclingSessions { get; set; }
        public ICollection<RunningSessionMainEF> RunningSessions { get; set; }
    }
}
