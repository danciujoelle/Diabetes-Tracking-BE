using DiabetesTrackingServer.Core.IRepositories;
using DiabetesTrackingServer.Core.Repositories;
using DiabetesTrackingServer.DataAccess;
using DiabetesTrackingServer.Repositories;
using DiabetesTrackingServer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DiabetesTrackingServer
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
            services.AddCors(options => options.AddDefaultPolicy(
                builder => builder.AllowAnyOrigin()));
            services.AddSwaggerGen();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPredictionService, PredictionService>();
            services.AddTransient<IPredictionRepository, PredictionRepository>();
            services.AddTransient<IEventService, EventService>();
            services.AddTransient<IEventRepository, EventRepository>();
            services.AddTransient<IGlucoseLogService, GlucoseLogService>();
            services.AddTransient<IGlucoseLogRepository, GlucoseLogRepository>();
            services.AddTransient<IInsulinLogService, InsulinLogService>();
            services.AddTransient<IInsulinLogRepository, InsulinLogRepository>();
            services.AddTransient<ISportLogRepository, SportLogRepository>();
            services.AddTransient<ISportLogService, SportLogService>();
            services.AddDbContext<DiabetesTrackingContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DiabetesTracking")));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DiabetesTrackingServer v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(options =>
            {
                options.
                AllowAnyOrigin().
                AllowAnyMethod().
                AllowAnyHeader();
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
