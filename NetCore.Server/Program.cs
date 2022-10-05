using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NetCore.Server.Interfaces;
using NetCore.Server.Models;
using NetCore.Server.Models.Configurations;
using NetCore.Server.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// CORS policy settings
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

// Connection settings
var connection = builder.Configuration.GetConnectionString("DefaultDatabase");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection, options => options.EnableRetryOnFailure()));
 
// JWT configuration settings
var authOptionsConfiguration = builder.Configuration.GetSection("JWTSettings");
builder.Services.Configure<JWTAuthenticationOptions>(authOptionsConfiguration);

// JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = "Server",
            ValidateAudience = true,
            ValidAudience = "Server",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("SomebodyOnceToldMeTheWorldIsGonnaRollMe")),
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
        };
    });

builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Services
builder.Services.AddTransient<IGroupService, GroupService>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IGroupAccountService, GroupAccountService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ITodoService, TodoService>();

var app = builder.Build();

app.UseCors("CORSPolicy");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
