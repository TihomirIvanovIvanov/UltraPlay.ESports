using Microsoft.EntityFrameworkCore;
using UltraPlay.ESports.Data;
using UltraPlay.ESports.DataProcessing;
using UltraPlay.ESports.DataProcessing.Contracts;
using UltraPlay.ESports.Services;
using UltraPlay.ESports.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

//Registry DbContext
builder.Services.AddDbContext<ESportsDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add processing services to the container.
builder.Services.AddHttpClient<IXmlFetcherService, XmlFetcherService>();
builder.Services.AddScoped<IDataSaverService, DataSaverService>();
builder.Services.AddScoped<IDataPollingService, DataPollingService>();
//builder.Services.AddHostedService<DataPollingBackgroundService>();

// Add CRUD services to the container.
builder.Services.AddTransient<ISportService, SportService>();
builder.Services.AddTransient<IEventService, EvenService>();
builder.Services.AddTransient<IMatchService, MatchService>();
builder.Services.AddTransient<IBetService, BetService>();
builder.Services.AddTransient<IOddService, OddService>();

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
