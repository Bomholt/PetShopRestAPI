using Bomholt.Petshop.Infrastructure.Data.Repositories;
using Bomholt.PetShop.Core.ApplicationService;
using Bomholt.PetShop.Core.ApplicationService.Services;
using Bomholt.PetShop.Core.DomainService;
using Bomholt.PetShop.UI.InterF;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Bomholt.PetShop.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<ILogic, Logic>();
            serviceCollection.AddScoped<IRunProgram, RunProgram>();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var runprogram = serviceProvider.GetRequiredService<IRunProgram>();

            runprogram.Run();
        }
    }
}
    