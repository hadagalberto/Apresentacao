using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PDV.Net.Application.Interface;
using PDV.Net.Application.ViewModel;
using PDV.Net.Domain.Interface.Service;
using PDV.Net.Web.Controllers.Base;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PDV.Net.Web.Areas.Produto.Controllers
{
    [Area("Produto")]
    public class HomeController : BaseController<IProdutoAppService, ProdutoViewModel>
    {
        private readonly ICategoriaProdutoService _categoriaProdutoService;

        public HomeController(IProdutoAppService appService, ICategoriaProdutoService categoriaProdutoService) : base(appService)
        {
            _categoriaProdutoService = categoriaProdutoService;
        }

        public override async Task<IActionResult> Create()
        {
            await Task.Run(CarregarCategorias);
            return View();
        }

        public override async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || id.Value == Guid.Empty)
            {
                return NotFound();
            }

            var produto = await _appService.GetAsync(id.Value);
            if (produto == null)
            {
                return NotFound();
            }

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
