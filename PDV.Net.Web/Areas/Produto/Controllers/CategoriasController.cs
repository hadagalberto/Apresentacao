using Microsoft.AspNetCore.Mvc;
using PDV.Net.Domain.DTO;
using PDV.Net.Domain.Entity;
using PDV.Net.Domain.Interface.Service;
using PDV.Net.Web.Controllers.Base;

namespace PDV.Net.Web.Areas.Produto.Controllers
{
    [Area("Produto")]
    public class CategoriasController : BaseController<ICategoriaProdutoService, CategoriaProdutoDTO, CategoriaProduto>
    {

        public CategoriasController(ICategoriaProdutoService service)
            : base(service)
        {
        }


    }
}
