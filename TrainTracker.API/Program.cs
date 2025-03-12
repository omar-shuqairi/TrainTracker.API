using Microsoft.AspNetCore.Cors.Infrastructure;
using TrainTracker.Core.Common;
using TrainTracker.Core.Repository;
using TrainTracker.Core.Services;
using TrainTracker.Infra.Common;
using TrainTracker.Infra.Repository;
using TrainTracker.Infra.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDbContext, DbContext>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IUserProfileRepository, UserProfileRepository>();
builder.Services.AddScoped<IStationsRepository, StationsRepository>();
builder.Services.AddScoped<ITrainsRepository, TrainsRepository>();
builder.Services.AddScoped<ITripsRepository, TripsRepository>();
builder.Services.AddScoped<ITicketsRepository, TicketsRepository>();
builder.Services.AddScoped<IPaymentsRepository, PaymentsRepository>();
builder.Services.AddScoped<ITestimonialsRepository, TestimonialsRepository>();
builder.Services.AddScoped<IFavoriteStationsRepository, FavoriteStationsRepository>();
builder.Services.AddScoped<IPageSettingsRepository, PageSettingsRepository>();



builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IUserProfileService, UserProfileService>();
builder.Services.AddScoped<IStationsService, StationsService>();
builder.Services.AddScoped<ITrainsService, TrainsService>();
builder.Services.AddScoped<ITripsService, TripsService>();
builder.Services.AddScoped<ITicketsSerivce, TicketsSerivce>();
builder.Services.AddScoped<IPaymentsService, PaymentsService>();
builder.Services.AddScoped<ITestimonialsService, TestimonialsService>();
builder.Services.AddScoped<IFavoriteStationsService, FavoriteStationsService>();
builder.Services.AddScoped<IPageSettingsService, PageSettingsService>();


Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;//This will tell Dapper to match underscores automatically, so User_ID maps to UserId in C#.




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
