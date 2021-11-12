using Microsoft.AspNetCore.Mvc;
using PDV.Net.Application.Interface;
using PDV.Net.Application.ViewModel;
using PDV.Net.Domain.Entity;
using PDV.Net.Domain.Interface.Service;
using PDV.Net.Web.Controllers.Base;

namespace PDV.Net.Web.Areas.Produto.Controllers
{
    [Area("Produto")]
    public class CategoriasController : BaseController<ICategoriaProdutoAppService, CategoriaProdutoViewModel>
    {
        public CategoriasController(ICategoriaProdutoAppService appService) : base(appService)
        {
        }
    }
}
