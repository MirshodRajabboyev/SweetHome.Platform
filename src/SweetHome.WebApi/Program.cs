using SweetHome.DataAccess.Interfaces.Homes;
using SweetHome.DataAccess.Interfaces.Users;
using SweetHome.DataAccess.Repositories.Homes;
using SweetHome.DataAccess.Repositories.Users;
using SweetHome.Service.Interfaces.Auth;
using SweetHome.Service.Interfaces.Commons;
using SweetHome.Service.Interfaces.Homes;
using SweetHome.Service.Interfaces.Notification;
using SweetHome.Service.Interfaces.Users;
using SweetHome.Service.Services.Auth;
using SweetHome.Service.Services.Commons;
using SweetHome.Service.Services.Homes;
using SweetHome.Service.Services.Notification;
using SweetHome.Service.Services.Users;
using SweetHome.WebApi.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IHomeRepository, HomeRepository>();

builder.Services.AddScoped<IFileService, FileService>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthServise, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddSingleton<ISmsSender, SmsSender>();
builder.Services.AddScoped<IHomeService, HomeService>();


builder.ConfigureJwtAuth();
builder.ConfigureSwaggerAuth();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
