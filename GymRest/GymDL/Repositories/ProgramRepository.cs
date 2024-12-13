using GymBL.Interfaces;
using GymBL.Models;
using GymDL.Mappers;
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
                var programEF = MapProgram.MapToDB(program);
                _context.Programs.Add(programEF);
                _context.SaveChanges();

                return program;                
            }
            catch (Exception ex)
            {

                throw new Exception("ProgramRepository-AddProgram",ex);
            }
        }
        public ProgramBL UpdateProgram(int id, ProgramBL program)
        {
            if (program == null)
            {
                throw new ArgumentNullException(nameof(program), "Program can't be null");
            }

            try
            {
                var ProgramDB = _context.Programs.Find(id);

                if (ProgramDB == null)
                {
                    throw new Exception("No Program Found");
                }
              
                    program.ProgramCode = id;
                    _context.Entry(ProgramDB).CurrentValues.SetValues(MapProgram.MapToDB(program));
                    _context.SaveChanges();

                    return MapProgram.MapToDomain(ProgramDB);
                


            }
            catch (Exception ex)
            {

                throw new Exception("ProgramRepository-UpdateProgram",ex);
            }
        }
    }
}
