using Microsoft.EntityFrameworkCore;
using UltraPlay.ESports.Data;
using UltraPlay.ESports.DataProcessing;
using UltraPlay.ESports.DataProcessing.Contracts;
using UltraPlay.ESports.Events;
using UltraPlay.ESports.Events.Contracts;
using UltraPlay.ESports.Services;
using UltraPlay.ESports.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

//Registry DbContext
builder.Services.AddDbContext<ESportsDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    options => options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));

// Add processing services to the container.
builder.Services.AddHttpClient<IXmlFetcherService, XmlFetcherService>();
builder.Services.AddScoped<IDataSaverService, DataSaverService>();
builder.Services.AddScoped<IDataPollingService, DataPollingService>();
//builder.Services.AddHostedService<DataPollingBackgroundService>();

// Add CRUD services to the container.
builder.Services.AddTransient<ISportService, SportService>();
builder.Services.AddTransient<IEventService, EventService>();
builder.Services.AddTransient<IMatchService, MatchService>();
builder.Services.AddTransient<IBetService, BetService>();
builder.Services.AddTransient<IOddService, OddService>();

// Add Events services to the container.
builder.Services.AddTransient<IMatchEventService, MatchEventService>();
builder.Services.AddTransient<IBetEventService, BetEventService>();
builder.Services.AddTransient<IOddEventService, OddEventService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
