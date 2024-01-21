using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BidOne.CodeTest.Data
{
    public class Dependencies
    {
        public static void ConfigutrationServices(IConfiguration configuation, IServiceCollection services)
        {
            services.AddScoped<JsonWriter>();
        }
    }
}
