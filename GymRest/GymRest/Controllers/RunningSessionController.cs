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
    public class RunningSessionController : ControllerBase
    {
        private RunningSessionServices service;

        public RunningSessionController(RunningSessionServices service)
        {
            this.service = service;
        }

        [Route("GetDetailsById/{id}")]
        [HttpGet]

        public IActionResult GetDetailsById(int id)
        {
            var existingRunningSession = service.GetDetailsById(id);
            if (existingRunningSession == null)
            {
                throw new Exception("Running session not found");
            }

            var runningSession = new RunningSessionMain
            {
                RunningSessionId = existingRunningSession.RunningSessionId,
                Date = existingRunningSession.Date,
                Duration = existingRunningSession.Duration,
                AvgSpeed = existingRunningSession.AvgSpeed,
                Details = existingRunningSession.Details.Select(d => new RunningSessionDetail
                {
                    RunningSessionId = d.RunningSessionId,
                    SeqNr = d.SeqNr,
                    IntervalTime = d.IntervalTime,
                    IntervalSpeed = d.IntervalSpeed
                }).ToList()
            };

            return Ok(runningSession);
        }
    }
}
