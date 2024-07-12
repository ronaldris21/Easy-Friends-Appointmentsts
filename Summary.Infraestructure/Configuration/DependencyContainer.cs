using Microsoft.Extensions.DependencyInjection;
using Summary.Core.Abstraction;
using Summary.Core.Services.Abstraction;
using Summary.Core.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summary.Infraestructure.Configuration
{
    public class DependencyContainer
    {

        public static void RegisterServices(IServiceCollection services)
        {

            services.AddTransient<IDbContext, AppDbContext > (); //As "using(){}" statement for better memory management and closing the db context instance on the dependecy injection
            services.AddTransient<IFriendService, FriendService>();
            services.AddTransient<IAppointmentService, AppointmentService>();

        }

        public static void ConfigureServices(IServiceCollection services)
        {
            RegisterServices(services);
        }


    }
}
