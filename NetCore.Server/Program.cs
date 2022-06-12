using Microsoft.EntityFrameworkCore;
using NetCore.Server.Interfaces;
using NetCore.Server.Models;
using NetCore.Server.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
    options.AddPolicy("CORSPolicy",
        builder =>
        {
            builder
            .AllowCredentials()
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .WithOrigins("http://localhost:5500");
        }));

var connection = builder.Configuration.GetConnectionString("DefaultDatabase");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection, options => options.EnableRetryOnFailure()));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IGroupService, GroupService>();
builder.Services.AddTransient<IAccountService, AccountService>();
//builder.Services.AddTransient<IUserService, UserService>();
//builder.Services.AddTransient<ITodoService, TodoService>();

var app = builder.Build();

app.UseCors("CORSPolicy");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
