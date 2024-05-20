using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Data.Repository;
using Microsoft.Extensions.Configuration;
using JwtSecurity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace Data.Configuration
{
    public static class ServiceCollectionExtension
    {

        public static void AddTournamentDbConfiguration(this IServiceCollection collection)
        {
            IConfiguration _config;

            using (var ServiceScope = collection.BuildServiceProvider().CreateScope())
            {
                _config = ServiceScope.ServiceProvider.GetService<IConfiguration>()!;
            }

            var ApllicationOptions = new ApllicationOptions();

            _config.GetSection(ApllicationOptions.Section).Bind(ApllicationOptions);

            string connectionStringCar = _config["Application:ConnectionStringCar"];
            string connectionStringEmi = _config["Application:ConnectionStringEmi"];



            collection.AddDbContext<TournamentContext>(options => options.UseSqlServer(connectionStringCar));
            //collection.AddDbContext<TournamentContext>(options => options.UseSqlServer(connectionStringEmi));
        }

        public static void AddEcnryptionOptions(this IServiceCollection services)
        {
            IConfiguration _configuration;

            using (var serviceScope = services.BuildServiceProvider().CreateScope())
            {
                _configuration = serviceScope.ServiceProvider.GetService<IConfiguration>()!;
            }

            var encryptionOptions = new EncryptionOptions();

            _configuration.GetSection(EncryptionOptions.Section).Bind(encryptionOptions);

            services.AddSingleton(typeof(EncryptionOptions), encryptionOptions);
        }

        public static void AddAuthenticationOptions(this IServiceCollection services)
        {
            IConfiguration _configuration;

            using (var serviceScope = services.BuildServiceProvider().CreateScope())
            {
                _configuration = serviceScope.ServiceProvider.GetService<IConfiguration>()!;
            }

            var authenticationOptions = new AuthenticationOptions();
            _configuration.GetSection(AuthenticationOptions.Section).Bind(authenticationOptions);

            services.AddSingleton(typeof(AuthenticationOptions), authenticationOptions);
        }

        public static void ConfigureJwt(this IServiceCollection services)
        {
            AuthenticationOptions _authenticationOptions;

            using (var serviceScope = services.BuildServiceProvider().CreateScope())
            {
                _authenticationOptions = serviceScope.ServiceProvider.GetService<AuthenticationOptions>()!;
            }

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _authenticationOptions.Issuer,
                    ValidAudience = _authenticationOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationOptions.Key)),
                    ClockSkew = TimeSpan.Zero,
                };
            });
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Torneo Pinturillo", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });
        }
        public static void AddAuthorizationPolicies(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Arbitro", policy => policy.RequireClaim("Role", "arbitro"));
                options.AddPolicy("Jugador", policy => policy.RequireClaim("Role", "jugador"));
            });
        }


    }
}
