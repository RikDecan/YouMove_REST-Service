namespace GymRest.DTO
{
    public class MemberRESToutputDTO
    {
        public MemberRESToutputDTO(int memberId, string firstName, string lastName, string email, string adress, DateTime birthday, string interests, string membertype) //met id
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

        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public DateTime Birthday { get; set; }
        public string Interests { get; set; }
        public string Membertype { get; set; }


    }
}
