using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using NetCore.Server.Interfaces;
using NetCore.Server.Models;
using NetCore.Server.Models.Configurations;
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

builder.Services.ConfigureApplicationCookie(o => { o.Cookie.SameSite = SameSiteMode.Strict; o.Cookie.Domain = "localhost"; o.Cookie.SecurePolicy = CookieSecurePolicy.None; });

var connection = builder.Configuration.GetConnectionString("DefaultDatabase");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection, options => options.EnableRetryOnFailure()));

/*var authOptionsConfiguration = builder.Configuration.GetSection("Auth");
builder.Services.Configure<AuthOptions>(authOptionsConfiguration);*/

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(1);
        options.SlidingExpiration = true;
        options.AccessDeniedPath = "/Forbidden/";
        options.Cookie.SameSite = SameSiteMode.Strict;
        options.Cookie.SecurePolicy = CookieSecurePolicy.None;
        options.Cookie.Domain = "localhost";
    });

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = HttpOnlyPolicy.Always,
    // Always при HTTPS 
    Secure = CookieSecurePolicy.None
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
