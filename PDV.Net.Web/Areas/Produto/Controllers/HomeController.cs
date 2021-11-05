using Microsoft.AspNetCore.Mvc;
using PDV.Net.Domain.DTO;
using PDV.Net.Domain.Interface.Service;
using PDV.Net.Web.Controllers.Base;
using System;
using System.Threading.Tasks;

namespace PDV.Net.Web.Areas.Produto.Controllers
{
    [Area("Produto")]
    public class HomeController : BaseController<IProdutoService, ProdutoDTO, Domain.Entity.Produto>
    {

        public HomeController(IProdutoService service) : base(service)
        {
        }

        public override async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || !id.HasValue)
            {
                return NotFound();
            }

            var produto = await _service.GetAsync(id.Value);
            if (produto == null)
            {
                return NotFound();
            }
            produto.ValorHelper = produto.Valor.ToString();
            produto.CustoHelper = produto.Custo.ToString();

            return View(produto);
        }

    }
}
