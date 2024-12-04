using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Data.SqlClient;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



// Connection string uit appsettings.json ophalen

// ! ik wil het niet uit apsettings halen ik wil her doen met de OnConfigure methode
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");



protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseSQLServer(@"Server=LAPTOP-8PQJLNFG\\SQLEXPRESS;Database=[GymTest]; Initial Catalog=Races;Integrated Security=True;TrustServerCertificate=True");
    //Niet vergeten om de connectiestring aan te passen
}

try
{
    using (var connection = new SqlConnection(connectionString))
    {
        connection.Open();
        Console.WriteLine("Verbinding met de database gelukt!");
        connection.Close();
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Fout bij het verbinden met de database: {ex.Message}");
}


app.Run();
