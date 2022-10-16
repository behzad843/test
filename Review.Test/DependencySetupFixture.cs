using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Review.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review.Test
{
    public class DependencySetupFixture
    {
        public IConfiguration Configuration { get; }
        public IServiceCollection services { get; }
        public ServiceProvider ServiceProvider { get; private set; }

        public DependencySetupFixture(IConfiguration configuration, IServiceCollection serviceCollection)
        {
            Configuration = configuration;
            services = serviceCollection;

            var service = IocConfig.Configure(services, Configuration);

            ServiceProvider = service.BuildServiceProvider();
        }

    }
}
