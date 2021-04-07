using Account.Data;
using Account.Data.Interfaces;
using Account.Data.Repositories;
using Account.Data.UnitOfWork;
using Account.Service;
using Account.Service.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Account.WebApi
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
            services.AddDbContext<AccountContext>(options =>
                options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));


            #region Repositories
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IAccountRepository, AccountRepository>();
            #endregion

            #region Services
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAccountService, AccountService>();
            #endregion

            services.AddSwaggerGen((options) => {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "Account API" });
            });

            services.AddAuthorization();
            services.AddControllers();

            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Account API");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
