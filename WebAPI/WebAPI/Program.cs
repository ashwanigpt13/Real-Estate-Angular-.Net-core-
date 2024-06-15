using Microsoft.Extensions.Options;
using WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data.Repo;
using WebAPI.Interface;
using WebAPI.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using WebAPI.Errors;
using WebAPI.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IUnitOfWork,UnitOfWork>();
builder.Services.AddTransient<IPhotoService, PhotoService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
var configuration = builder.Configuration;
var secretKey = configuration.GetValue<string>("AppSettings:Key");
   var key = new SymmetricSecurityKey(Encoding.UTF8
    .GetBytes(secretKey ?? ""));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(
    opt=>{
        opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuerSigningKey=true,
            ValidateIssuer=false,
            ValidateAudience=false,
            IssuerSigningKey= key
        };
    }
);
// Configuration setup
// var configuration = new ConfigurationBuilder()
//     .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//     .Build();

builder.Services.AddSingleton(configuration);

// Configure DbContext
var connectionString = configuration.GetConnectionString("Default");
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(opt=>opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseAuthentication();
app.UseAuthorization();
app.ConfigureExceptionHandler(builder.Environment);

app.MapControllers();

app.Run();
