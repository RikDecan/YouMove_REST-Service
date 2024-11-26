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
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

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
