using Contracts.Middlewares;
using Contracts.Middlewares.MiddlewaresService;
using Data.Configuration;
using Services.Interfaces;
using Services.Interfaces.User;
using Services.Services;
using Services.Services.User;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DBCOntext
builder.Services.AddTournamentDbConfiguration();
builder.Services.AddEcnryptionOptions();
builder.Services.AddAuthenticationOptions();

builder.Services.AddScoped<IExceptionService, ExceptionService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IMatchService, MatchService>();
builder.Services.AddScoped<ITournamentService, TournamentService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEncryptionService, EncryptionService>();
builder.Services.AddScoped<IAuthenticationServices, AuthenticationServices>();
builder.Services.AddHttpContextAccessor();
builder.Services.ConfigureJwt();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("SuperAdmin", policy => policy.RequireClaim("AdminType","role"));
});


builder.Services.ConfigureSwagger();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseStaticFiles();


}


app.UseMiddleware<CustomMiddleware>();
app.UseAuthentication();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
