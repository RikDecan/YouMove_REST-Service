using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;
using GymBL.Models;
using GymBL.Services;
using GymRest.DTO;
using GymDL.Models;
using GymDL.Mappers;
using System.Diagnostics.Metrics;
using GymBL.Interfaces;
using System.Linq.Expressions;
using System.Reflection;

namespace GymRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private MemberService repo;

        public MemberController(MemberService repo)
        {
            this.repo = repo;
        }

        [Route("GetMemberById/{id}")]
        [HttpGet]
        public Member GetMemberById(int id)
        {
           return repo.GetMemberById(id);               
        }

        [Route("GetSessionsFromMembers/{id}")]
        [HttpGet]

        public SessionsDTO GetSessionsFromMembers(int id, int month, int year)
        {
            Member member = repo.GetMemberById(id);
            SessionsDTO sessions = new SessionsDTO();

            // Get cycling sessions and calculate impact
            var cyclingSessions = member.Cyclingsessions
                .Where(s => s.Date.Month == month && s.Date.Year == year)
                .OrderBy(s => s.Date)
                .Select(s =>
                {
                    string impact;
                    if (s.Avg_watt > 200)
                    {
                        impact = "high";
                    }
                    else if (s.Avg_watt >= 150)
                    {
                        impact = "medium";
                    }
                    else// avg_watt < 150
                    {
                        impact = s.Duration > 90 ? "medium" : "low";
                    }

                    // Create new cycling session with impact
                    return new Cyclingsession(
                        s.CyclingsessionId,
                        s.Date,
                        s.Duration,
                        s.Avg_watt,
                        s.Max_watt,
                        s.Avg_cadence,
                        s.Max_cadence,
                        s.Trainingtype,
                        s.Comment + $"Impact: {impact} ",
                        s.MemberId
                    );
                })
                .ToList();

            sessions.Cyclingsessions = cyclingSessions;
            sessions.RunningSessions = member.RunningSessionMains
                .Where(r => r.Date.Month == month && r.Date.Year == year)
                .OrderBy(r => r.Date)
                .ToList();

            return sessions;
        }



        [Route("GetStatisticalSessionsFromMembers/{id}")]
        [HttpGet]
        public SessionsDTO2 GetSessionsFromMembers2(int id)
        {
            Member member = repo.GetMemberById(id);
            SessionsDTO2 sessions = new SessionsDTO2();

            //aantal sessies over beide sessiezs
            var cyclingSessionsCount = member.Cyclingsessions.Count();
            var runningSessionsCount = member.RunningSessionMains.Count();
            var sessionsAmount = cyclingSessionsCount + runningSessionsCount;


            //totale duratie
            var totalCyclingDuration = member.Cyclingsessions.Sum(cs => cs.Duration);
            var totalRunningDuration = member.RunningSessionMains.Sum(rs => rs.Duration);
            var sessionsTotalDuration = totalCyclingDuration + totalRunningDuration;
            
            //gemiddelde duration
            var avg_duration = sessionsTotalDuration / sessionsAmount; 

            //langste duration
            var longestCyclingSessionDuration = member.Cyclingsessions.Max(cs => cs.Duration);
            var longestRunningSessionDuration = member.RunningSessionMains.Max(rs => rs.Duration);          
            var longestSessionDuration = Math.Max(longestCyclingSessionDuration, longestRunningSessionDuration);

            //korste duration
            var shortestCyclingSessionDuration = member.Cyclingsessions.Min(cs => cs.Duration);
            var shortestRunningSessionDuration = member.RunningSessionMains.Min(rs => rs.Duration);
            

            var shortestSessionDuration = shortestCyclingSessionDuration;
            if (shortestRunningSessionDuration < shortestSessionDuration && shortestRunningSessionDuration != double.MaxValue)
            {
                shortestSessionDuration = shortestRunningSessionDuration;
            }

            // DTO invullen
            sessions.SessionsAmount = sessionsAmount;
            sessions.TotalDuration = sessionsTotalDuration;
            sessions.AvgDuration = avg_duration;
            sessions.LongestSession = longestSessionDuration;
            sessions.ShortestSession = shortestSessionDuration;

            return sessions;
        }

        [Route("GetMonthlySessionsFromMembers/{id}")]
        [HttpGet]

        public List<SessionsDTO3> GetMonthlySessionsFromMembers(int id, int year)
        {
            Member member = repo.GetMemberById(id);

            var monthlySessionsList = Enumerable.Range(1, 12)
                .Select(month => new SessionsDTO3

                {
                    Month = month,
                    CyclingSessionsCount = 0,
                     RunningSessionsCount = 0,
                    TotalSessionsCount = 0
                }
                
                ).ToList();

            var cyclingSessionsPerMonth = member.Cyclingsessions.Where(cs => cs.Date.Year == year).GroupBy(cs => cs.Date.Month).ToList();

            var runningSessionsPerMonth = member.RunningSessionMains.Where(rs => rs.Date.Year == year).GroupBy(rs => rs.Date.Month).ToList();

            int cyclingIndex = 0;
            while (cyclingIndex < cyclingSessionsPerMonth.Count)
            {
                var cyclingGroup = cyclingSessionsPerMonth[cyclingIndex];
                var monthEntry = monthlySessionsList.First(m => m.Month == cyclingGroup.Key);

                monthEntry.CyclingSessionsCount = cyclingGroup.Count();
                monthEntry.TotalSessionsCount += cyclingGroup.Count();
                cyclingIndex++;
            }

            int runningIndex = 0;
            while (runningIndex < runningSessionsPerMonth.Count)
            {
                var runningGroup = runningSessionsPerMonth[runningIndex];
                var monthEntry = monthlySessionsList.First(m => m.Month == runningGroup.Key);
                monthEntry.RunningSessionsCount = runningGroup.Count();
                monthEntry.TotalSessionsCount += runningGroup.Count();
                runningIndex++;
            }

            return monthlySessionsList.OrderBy(m => m.Month).ToList();
        }



        [Route("GetSessionsFromTrainingType/{id}")]
        [HttpGet]

        public List<TrainingTypeSessionsDTO> GetCyclingSessionsCountByTrainingType(int id, int year)
        {
            Member member = repo.GetMemberById(id);

            var trainingTypes = new[] { "fun", "endurance", "interval", "recovery" };

            var trainingTypeSessionsList = trainingTypes
                .Select(type => new TrainingTypeSessionsDTO
                {
                    TrainingType = type,
                    SessionsCount = 0
                })
                .ToList();

            var cyclingSessionsByTrainingType = member.Cyclingsessions
                .Where(cs => cs.Date.Year == year)
                .GroupBy(cs => cs.Trainingtype)
                .ToList();

            int trainingTypeIndex = 0;
            while (trainingTypeIndex < cyclingSessionsByTrainingType.Count)
            {
                var trainingTypeGroup = cyclingSessionsByTrainingType[trainingTypeIndex];
                var typeEntry = trainingTypeSessionsList
                    .FirstOrDefault(t => t.TrainingType.ToLower() == trainingTypeGroup.Key.ToLower());

                if (typeEntry != null)
                {
                    typeEntry.SessionsCount = trainingTypeGroup.Count();
                }

                trainingTypeIndex++;
            }

            return trainingTypeSessionsList;
        }


        [Route("GetMembers")]
        [HttpGet]
        public List<Member> GetMembers()
        {
            return repo.GetMembers();
        }

        [Route("RemoveMember/{id}")]
        [HttpDelete]
        public bool RemoveMember(int id)
        {
            return repo.RemoveMember(id);
        }

        [Route("NieuweMember")]
        [HttpPost]

        public Member CreateMember([FromBody] MemberDTO memberDTO)
        {
                Member member = new Member(
                memberDTO.FirstName,
                memberDTO.LastName,
                memberDTO.Email,
                memberDTO.Address,
                memberDTO.Birthday,
                memberDTO.Interests,
                memberDTO.Membertype
                );
                return repo.CreateMember(member);
        }

        [Route("UpdateMember/{id}")]
        [HttpPut]

        public Member UpdateMemberById(int id, [FromBody] MemberDTO memberDTO)
        {
            try
            {
                Member member = new Member(

                memberDTO.FirstName,
                memberDTO.LastName,
                memberDTO.Email,
                memberDTO.Address,
                memberDTO.Birthday,
                memberDTO.Interests,
                memberDTO.Membertype

                    );
                return repo.UpdateMemberById(id, member);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}