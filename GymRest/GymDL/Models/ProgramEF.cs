using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GymDL.Models
{
    public class ProgramEF
    {
        public ProgramEF()
        {
        }

        public ProgramEF(string programCode, string name, string target, DateTime startDate, int maxMembers)
        {
            ProgramCode = programCode;
            Name = name;
            Target = target;
            StartDate = startDate;
            MaxMembers = maxMembers;
        }

        [Key]
        public string ProgramCode { get; set; }
        public string Name { get; set; }
        public string Target { get; set; }
        public DateTime StartDate { get; set; }
        public int MaxMembers { get; set; }

        // Navigation Properties
        public ICollection<MemberEF> Members { get; set; }
    }
    
}
