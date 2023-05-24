using Notes.Application.Entities.Author.Interfaces;
using Notes.Application.Entities.Author.Repositories;
using Notes.Application.Entities.InformationSystem.Interfaces;
using Notes.Application.Entities.InformationSystem.Repositories;
using Notes.Application.Entities.Priority.Interfaces;
using Notes.Application.Entities.Priority.Repositories;
using Notes.Application.Entities.Role.Interfaces;
using Notes.Application.Entities.Role.Repositories;
using Notes.Application.Entities.Task.Interfaces;
using Notes.Application.Entities.Task.Repositories;
using Notes.Application.Entities.TaskStatus.Interfaces;
using Notes.Application.Entities.TaskStatus.Repositories;
using Notes.Application.Entities.User.Interfaces;
using Notes.Application.Entities.User.Repositories;
using Notes.Persistence.DependencyInjection;

namespace Notes.WebApi;

/// <summary>
/// Class Program.
/// </summary>
public class Program
{
    /// <summary>
    /// Defines the entry point of the application.
    /// </summary>
    /// <param name="args">The arguments.</param>
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddPersistence(builder.Configuration);

        builder.Services.AddTransient<ITaskRepository, TaskRepository>();
        builder.Services.AddTransient<ITaskStatusRepository, TaskStatusRepository>();
        builder.Services.AddTransient<IRoleRepository, RoleRepository>();
        builder.Services.AddTransient<IPriorityRepository, PriorityRepository>();
        builder.Services.AddTransient<IInformationSystemRepository, InformationSystemRepository>();
        builder.Services.AddTransient<IAuthorRepository, AuthorRepository>();
        builder.Services.AddTransient<IUserRepository, UserRepository>();

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

        app.Run();
    }
}