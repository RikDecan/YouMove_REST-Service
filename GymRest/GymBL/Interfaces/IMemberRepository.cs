﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymBL.Models;

namespace GymBL.Interfaces
{
    public interface IMemberRepository
    {
        public Member GetMemberById (int id) ;  
        


    }
}