using Microsoft.AspNetCore.Mvc;
using GymDL;
using System;

namespace GymRest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DatabaseController : ControllerBase
    {
        private readonly GymContext _context;

        public DatabaseController(GymContext context)
        {
            _context = context;
        }

        [HttpGet("check-connection")]
        public IActionResult CheckDatabaseConnection()
        {
            try
            {
                var memberCount = _context.Members.Count();

                return Ok(new
                {
                    message = "Database connection successful.",
                    details = $"Number of members found: {memberCount}"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Database connection failed or an error occurred.",
                    error = ex.Message
                });
            }
        }
    }
}
