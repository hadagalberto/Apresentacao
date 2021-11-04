using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PDV.Net.Domain.DTO;
using PDV.Net.Domain.Entity;
using PDV.Net.Domain.Interface.Service;
using PDV.Net.Infra.Data.Context;
using PDV.Net.Web.Controllers.Base;

namespace PDV.Net.Web.Controllers
{
    public class ProdutosController : BaseController<IProdutoService, ProdutoDTO, Produto>
    {

        public ProdutosController(IProdutoService service) : base(service)
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
