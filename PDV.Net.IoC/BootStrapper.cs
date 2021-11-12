using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PDV.Net.Application.AppService;
using PDV.Net.Application.Interface;
using PDV.Net.Application.ViewModel;
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

            // AppService
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<ICategoriaProdutoAppService, CategoriaProdutoAppService>();

            // Service
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<ICategoriaProdutoService, CategoriaProdutoService>();

            // Repository
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ICategoriaProdutoRepository, CategoriaProdutoRepository>();

            // AutoMapper

            var mapperConfig = new MapperConfiguration(mapperConfig =>
            {
                mapperConfig.CreateMap<Produto, ProdutoViewModel>()
                    .ReverseMap();
                mapperConfig.CreateMap<CategoriaProduto, CategoriaProdutoViewModel>()
                    .ReverseMap();
            });

            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
