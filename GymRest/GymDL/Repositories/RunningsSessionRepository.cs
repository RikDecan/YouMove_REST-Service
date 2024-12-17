using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymBL.Interfaces;
using GymBL.Models;
using GymDL.Mappers;
using Microsoft.EntityFrameworkCore;

namespace GymDL.Repositories
{
    public class RunningsSessionRepository : IRunningSessionRepository
    {

        private readonly GymContext _context;

        private RunningsSessionRepository(GymContext context)
        {
            _context = context;
        }

        public RunningSessionMain GetDetailsById(int id)
        { 
            var runninSession = _context.runningSessionMains.Include( r => r.Details).FirstOrDefault( r => r.RunningSessionId == id);

            if (runninSession == null)
            {
                throw new Exception("Runningsession not found");

            }
            return MapRunningSessionMain.MapToDomain(runninSession);

        }



    }
}
