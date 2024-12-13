    using GymBL.Interfaces;
using GymBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBL.Services
{
    public class ProgramService
    {
        private IProgramRepository repo;

        public ProgramService(IProgramRepository repo)
        {
            this.repo = repo;
        }

        public ProgramBL AddProgram(ProgramBL program)
        {
            try
            {
                return repo.AddProgram(program);
            }
            catch (Exception ex)
            {

                throw new Exception("ProgramService-AddProgram",ex);
            }
        }
        public ProgramBL UpdateProgram(int id,ProgramBL program)
        {
            try
            {
                return repo.UpdateProgram(id,program);
            }
            catch (Exception ex)
            {

                throw new Exception("ProgramService-UpdateProgram",ex);
            }
        }
    }
}
