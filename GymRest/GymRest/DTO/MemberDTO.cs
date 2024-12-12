namespace GymRest.DTO
{
    public class MemberDTO
    {
        public MemberDTO(string firstName, string lastName, string email, string address, DateTime birthday, List<string>? interests, string membertype)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
            Birthday = birthday;
            Interests = interests;
            Membertype = membertype;
        }

        //public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public List<string> ? Interests { get; set; }
        public string Membertype { get; set; }

    }
}
