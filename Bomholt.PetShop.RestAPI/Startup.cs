using Bomholt.PetShop.Core.ApplicationService;
using Bomholt.PetShop.Core.ApplicationService.Services;
using Bomholt.PetShop.Core.DomainService;
using Bomholt.PetShop.Infrastructure.DB.Data;
using Bomholt.PetShop.Infrastructure.DB.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Bomholt.PetShop.RestAPI
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
            //services.AddDbContext<PetShopContext>(opt => opt.UseInMemoryDatabase("PetBase"));
            services.AddDbContext<PetShopContext>(opt => opt.UseSqlite("Data Source = Bomholt.PetShop.DB"));
            
            services.AddMvc();
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IOwnerService, OwnerService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // Initialize the database
                //using (var scope = app.ApplicationServices.CreateScope())
                //{
                //    var dbContext = scope.ServiceProvider.GetService<PetShopContext>();
                //    dbContext.Database.EnsureCreated();
                //}
            }

            app.UseMvc();
        }
    }
}
