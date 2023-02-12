﻿
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Lms.Data.Data;
using Lms.Api.Extensions;

namespace Lms.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<LmsApiContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("LmsApiContext") ?? throw new InvalidOperationException("Connection string 'LmsApiContext' not found.")));

            // Add services to the container.

            //** orginal **************************************************//
            //builder.Services.AddControllers();
            //// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/

            //**New**//
            //Dessa till�gg hj�lper oss att mappa mot Json och Xml.

            builder.Services.AddControllers(opt => opt.ReturnHttpNotAcceptable = true)
                .AddNewtonsoftJson()
                .AddXmlDataContractSerializerFormatters() ;
            /*********************************************/

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            /*****************************************************************/


            var app = builder.Build();
            await app.SeedDataAsync();

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
        }
    }
}