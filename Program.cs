using Microsoft.EntityFrameworkCore;
using TaskAPI.App.ErrorLogs.Repositories;
using TaskAPI.App.ErrorLogs.Repositories.IRepositories;
using TaskAPI.App.PersonRelationships.Repositories;
using TaskAPI.App.PersonRelationships.Repositories.IRepositories;
using TaskAPI.App.PhoneNumbers.Repositories;
using TaskAPI.App.PhoneNumbers.Repositories.IRepositories;
using TaskAPI.App.PhysicalPersons.Repositories;
using TaskAPI.App.PhysicalPersons.Repositories.IRepositories;
using TaskAPI.App.PhysicalPersons.Services;
using TaskAPI.App.PhysicalPersons.Services.IServices;
using TaskAPI.Middlewares;
using TaskAPI.Persistent.Data;
using TaskAPI.Shared;

var builder = WebApplication.CreateBuilder(args);
 
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
 
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
 
builder.Services.AddSingleton<ISqlConnectionFactory>(_ =>
    new SqlConnectionFactory(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();


builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IErrorLogRepository, ErrorLogRepository>();
builder.Services.AddScoped<IPhoneNumberRepository, PhoneNumberRepository>();
builder.Services.AddScoped<IPhysicalPersonRepository, PhysicalPersonRepository>();
builder.Services.AddScoped<IPersonRelationshipRepository, PersonRelationshipRepository>();

builder.Services.AddScoped<IPhysicalPersonService, PhysicalPersonService>();//IPhysicalPersonReadRepository

builder.Services.AddScoped<IPhysicalPersonReadRepository, PhysicalPersonReadRepository>();

var app = builder.Build();
app.MapControllers();


app.UseMiddleware<ErrorHandlerMiddleware>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();