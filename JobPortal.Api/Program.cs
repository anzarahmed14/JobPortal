using JobPortal.Api;
using JobPortal.Data;
using JobPortal.IRepositories;
using JobPortal.IRepositories.Job;
using JobPortal.IServices;
using JobPortal.IServices.Job;
using JobPortal.Model;
using JobPortal.Repositories;
using JobPortal.Repositories.Job;
using JobPortal.Services;
using JobPortal.Services.Job;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);



var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("DefaultConnection");


builder.Services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

builder.Services.AddDbContext<JobPortalDbContext>(options =>
{
    options.UseSqlServer(connectionString,b => b.MigrationsAssembly("JobPortal.Api"));

});

builder.Services.AddControllers();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


builder.Services.AddScoped<IPersonalInfoService, PersonalInfoService>();
builder.Services.AddScoped<IPersonalInfoRepository, PersonalInfoRepository>();

builder.Services.AddScoped<IAcademicInfoService, AcademicInfoService>();
builder.Services.AddScoped<IAcademicInfoRepository, AcademicInfoRepository>();


builder.Services.AddScoped<IEmploymentInfoService, EmploymentInfoService>();
builder.Services.AddScoped<IEmploymentInfoRepository, EmploymentInfoRepository>();


builder.Services.AddScoped<IExperienceInfoService, ExperienceInfoService>();
builder.Services.AddScoped<IExperienceInfoRepository, ExperienceInfoRepository>();


builder.Services.AddScoped<IAddressInfoService, AddressInfoService>();
builder.Services.AddScoped<IAddressInfoRepository, AddressInfoRepository>();


builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IJwtService, JwtService>();


builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<ICityRepository, CityRepository>();

builder.Services.AddScoped<IStateService, StateService>();
builder.Services.AddScoped<IStateRepository, StateRepository>();


builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();


builder.Services.AddScoped<ITrainLineRepository, TrainLineRepository>();
builder.Services.AddScoped<ITrainLineService, TrainLineService>();

builder.Services.AddScoped<IDesignationRepository, DesignationRepository>();
builder.Services.AddScoped<IDesignationService, DesignationService>();


builder.Services.AddScoped<INoticePeriodRepository, NoticePeriodRepository>();
builder.Services.AddScoped<INoticePeriodService, NoticePeriodService>();


builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<ISkillService, SkillService>();


builder.Services.AddScoped<IExportLevelRepository, ExportLevelRepository>();
builder.Services.AddScoped<IExportLevelService, ExportLevelService>();

builder.Services.AddScoped<ISkillInfoRepository, SkillInfoRepository>();
builder.Services.AddScoped<ISkillInfoService, SkillInfoService>();


builder.Services.AddScoped<IJobInfoRepository, JobInfoRepository>();
builder.Services.AddScoped<IJobInfoService, JobInfoService>();

builder.Services.AddScoped<IJobSkillRepository, JobSkillRepository>();
builder.Services.AddScoped<IJobSkillService, JobSkillService>();


builder.Services.AddScoped<IJobCityRepository, JobCityRepository>();
builder.Services.AddScoped<IJobCityService, JobCityService>();

//builder.Services.AddScoped<IJobSearchRepository, JobSearchRepository>();
builder.Services.AddScoped<IJobSearchService, JobSearchService>();

//ServiceRegistration.AddScopedServices(builder.Services);

builder.Services.AddScoped<IJobApplicationService, JobApplicationService>();
builder.Services.AddScoped<IJobApplicationRepository, JobApplicationRepository>();


builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();



// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("EnableCORS", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


// Add services to the container.

var app = builder.Build();



// Configure the HTTP request pipeline.

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
});

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

// Enable CORS
app.UseCors("EnableCORS");

app.MapControllers();
await app.RunAsync();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
