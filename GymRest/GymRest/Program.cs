using GymBL.Interfaces;
using GymBL.Models;
using GymBL.Services;
using GymDL.Repositories;
using GymDL;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configure CORS
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowReactApp", policy =>
            {
                policy.WithOrigins("http://localhost:5173") 

                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
        });

        builder.Services.AddDbContext<GymContext>();

        builder.Services.AddScoped<IMemberRepository, MemberRepository>();
        builder.Services.AddScoped<MemberService>();

        builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
        builder.Services.AddScoped<EquipmentService>();

        builder.Services.AddScoped<IProgramRepository, ProgramRepository>();
        builder.Services.AddScoped<ProgramRepository>();

        builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
        builder.Services.AddScoped<ReservationService>();

        builder.Services.AddScoped<IRunningSessionRepository, RunningsSessionRepository>();
        builder.Services.AddScoped<RunningSessionServices>();

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCors("AllowReactApp");

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}