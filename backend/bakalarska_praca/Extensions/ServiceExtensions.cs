﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace bakalarska_praca.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)          //konfiguracia CORS POLICY
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
        public static void ConfigureIISIntegration(this IServiceCollection services)        //konfiguracia pre IIS hosting
        {
            services.Configure<IISOptions>(options =>
            {
            });
        }
        public static void ConfigureAuth(this IServiceCollection services)
        {
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
            )
            .AddJwtBearer(options =>        //validate received token from client
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = false,                           //issuer is actual server
                     ValidateAudience = false,                         //receiver is valid 
                     ValidateLifetime = true,                         //token has not expired
                     ValidateIssuerSigningKey = true,                 //signing key is valid and trusted by server
                     //ValidIssuer = "http://localhost:44386",
                     //ValidAudience = "http://localhost:44386",
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("GD9mf1w&Bjd1pun=opS#")),
                 };
             });
        }
    }
}
