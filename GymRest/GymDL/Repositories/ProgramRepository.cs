using GymBL.Interfaces;
using GymBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDL.Repositories
{
    public class ProgramRepository : IProgramRepository
    {
        private readonly GymContext _context;

        public ProgramRepository(GymContext context)
        {
            _context = context;
        }

        public ProgramBL AddProgram(ProgramBL program)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw new Exception("ProgramRepository-AddProgram",ex);
            }
        }
        public ProgramBL UpdateProgram(int id, ProgramBL program)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw new Exception("ProgramRepository-UpdateProgram",ex);
            }
        }
    }
}
