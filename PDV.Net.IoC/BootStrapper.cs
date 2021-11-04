using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace PDV.Net.IoC
{
    public class BootStrapper
    {
        public static void Register(IServiceCollection services)
        {

            // Service
            

            // Repository


            // AutoMapper

            var mapperConfig = new MapperConfiguration(mapperConfig =>
            {

            });

            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
