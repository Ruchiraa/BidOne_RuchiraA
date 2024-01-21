using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BidOne.CodeTest.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BidOne.CodeTest.Services
{
    public class Dependencies
    {
        public static void ConfigutrationServices(IConfiguration configuation, IServiceCollection services)
        {
            services.AddScoped<IPersonService,PersonService>();
        }
    }
}
