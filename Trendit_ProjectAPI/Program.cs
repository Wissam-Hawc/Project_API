//using Serilog;
//using Serilog.Core;

using Trendit_ProjectAPI.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

        //building the logs in serilogs using file
        //Log.Logger= new LoggerConfiguration().MinimumLevel.Debug()
        //    .WriteTo.File("log/villalogs.txt", rollingInterval:RollingInterval.Day).CreateLogger();

        //builder.Host.UseSerilog();

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ILogging,Logging>();
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
