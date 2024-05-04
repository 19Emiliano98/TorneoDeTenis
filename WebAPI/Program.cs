using Contracts.Middlewares;
using Contracts.Middlewares.MiddlewaresService;
using Data.Configuration;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// DBCOntext
builder.Services.AddTournamentDbConfiguration();
builder.Services.AddScoped<IExceptionService, ExceptionService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseMiddleware<CustomMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
