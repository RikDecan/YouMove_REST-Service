using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

[ApiController]
[Route("api/[controller]")]
public class TestConnectionController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public TestConnectionController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet]
    [Route("test-connection")]
    public IActionResult TestConnection()
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");

        try
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return Ok("Verbinding met de database gelukt!");
            }
            //test op https://localhost:7007/api/testconnection/test-connection
        }
        catch (Exception ex)
        {
            return BadRequest($"Fout bij het verbinden met de database: {ex.Message}");
        }
    }
}
