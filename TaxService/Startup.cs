using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MunicipalityTaxService.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System;
using MunicipalityTaxService.Models;
using MunicipalityTaxService.Data;

namespace MunicipalityTaxService
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();
      services.AddTransient<IMunicipalityTaxRecordRepository, MunicipalityTaxRecordRepositoryEF>();
      services.AddDbContext<MunicipalityTaxRecordContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("MunicipalityTaxRecordContext")));

      services.AddMvc()
        .AddJsonOptions(options =>
        {
          options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
          options.JsonSerializerOptions.IgnoreNullValues = true;
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

     //var context = app.ApplicationServices.GetService<MunicipalityTaxRecordContext>();
     //AddTestData(context);

     app.UseRouting();

     app.UseAuthorization();

     app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }

        // creating data for in-memory database.
        private static void AddTestData(MunicipalityTaxRecordContext context)
        {
            var MS = new MunicipalityTaxRecord
            {
           
                MunicipalityName = "Copenhegen",
                ScheduleStart = new DateTime(2016, 01, 01),
                ScheduleEnd = new DateTime(2016, 12, 31),
                TaxRate = new decimal(0.1),
                Period = TimePeriod.Year
            };

            context.MunicipalityTaxRecordes.Add(MS);
            context.SaveChanges();
        }


    }
}
