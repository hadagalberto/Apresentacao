using Microsoft.AspNetCore.Mvc;
using PDV.Net.Domain.DTO;
using PDV.Net.Domain.Interface.Service;
using PDV.Net.Web.Controllers.Base;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PDV.Net.Web.Areas.Produto.Controllers
{
    [Area("Produto")]
    public class HomeController : BaseController<IProdutoService, ProdutoDTO, Domain.Entity.Produto>
    {
        private readonly ICategoriaProdutoService _categoriaProdutoService;

        public HomeController(IProdutoService service, ICategoriaProdutoService categoriaProdutoService) : base(service)
        {
            _categoriaProdutoService = categoriaProdutoService;
        }

        public override async Task<IActionResult> Create()
        {
            CarregarCategorias();
            return View();
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
            CarregarCategorias();

            return View(produto);
        }

        private void CarregarCategorias()
        {
            var categorias = _categoriaProdutoService.ListActive();

            ViewBag.Categorias = categorias.Where(x => x.Ativo)
                .Select(x => new SelectListItem {Text = x.Nome, Value = x.Id.ToString()});
        }

    }
}
