using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PDV.Net.Domain.DTO;
using PDV.Net.Domain.Entity;
using PDV.Net.Domain.Interface.Repository;
using PDV.Net.Domain.Interface.Service;
using PDV.Net.Domain.Service;
using PDV.Net.Infra.Data.Repository;

namespace PDV.Net.IoC
{
    public class BootStrapper
    {
        public static void Register(IServiceCollection services)
        {

            // Service
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<ICategoriaProdutoService, CategoriaProdutoService>();

            // Repository
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ICategoriaProdutoRepository, CategoriaProdutoRepository>();

            // AutoMapper

            var mapperConfig = new MapperConfiguration(mapperConfig =>
            {
                mapperConfig.CreateMap<Produto, ProdutoDTO>()
                    .ReverseMap();
                mapperConfig.CreateMap<CategoriaProduto, CategoriaProdutoDTO>()
                    .ReverseMap();
            });

            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
