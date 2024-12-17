using GymBL.Interfaces;
using GymBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBL.Services
{
    public class RunningSessionServices
    {
        private IRunningSessionRepository repo;

        public RunningSessionServices(IRunningSessionRepository repo)
        {
            this.repo = repo;
        }

        public RunningSessionMain GetDetailsById(int id)
        {
            try
            {
                return repo.GetDetailsById(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Geef Member", ex);
            }
        }
    }
}
