﻿namespace GymDL.Models
{
    public class ProgramMember
    {
    
        public string ProgramCode { get; set; }
        public int MemberId { get; set; }


        ICollection<Program> programs { get; set; }
    }
}
