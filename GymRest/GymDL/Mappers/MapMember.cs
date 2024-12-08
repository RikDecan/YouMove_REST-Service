using GymBL.Models;
using GymDL.Exceptions;
using GymDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GymDL.Mappers
{
    public class MapMember
    {

        public static Member MapToDomain(MemberEF db)
        {
            try
            {

                return new Member(
                    db.MemberId,
                    db.FirstName,
                    db.LastName,
                    db.Email,
                    db.Adress,
                    db.Birthday,
                    db.Interests ?? new List<string>(),
                    db.CyclingSessions ?.Select(MapCyclingsession.MapToDomain).ToList() ?? new List<Cyclingsession>(),
                    db.RunningSessionMains?.Select(MapRunningSessionMain.MapToDomain).ToList() ?? new List<RunningSessionMain>(),
                    db.Reservations?.Select(MapReservations.MapToDomain).ToList() ?? new List<Reservation>(),
                    db.Programs?.Select(MapProgram.MapToDomain).ToList() ?? new List<ProgramBL>(),
                    db.Membertype);
            }
            catch (Exception)
            {
                throw new Exception("MapMember - MapToBL");
            }
        }
        public static MemberEF MapToDL(Member m)
        {
            try
            {
                return new MemberEF(
                   m.MemberId,
                    m.FirstName,
                    m.LastName,
                    m.Email,
                    m.Adress,
                    m.Birthday,
                    m.Interests ?? new List<string>(),
                    m.Cyclingsessions?.Select(MapCyclingsession.MapToDB).ToList() ?? new List<CyclingsessionEF>(),
                    m.RunningSessionMains?.Select(MapRunningSessionMain.MapToDB).ToList() ?? new List<RunningSessionMainEF>(),
                    m.Programs?.Select(MapProgram.MapToDB).ToList() ?? new List<ProgramEF>(),
                    m.Membertype);
            }
         
            catch (Exception ex)
            {
                throw new MapException("MapProgram - MapToDomain", ex);
            }
        }
        
        
    }
}
