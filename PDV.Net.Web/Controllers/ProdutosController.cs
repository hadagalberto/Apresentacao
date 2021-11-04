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

namespace PDV.Net.Web.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoService _service;

        public ProdutosController(IProdutoService service)
        {
            _service = service;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            return View(await _service.ListAsync());
        }


        // GET: Produtos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Valor,Custo,Descricao,Ativo")] ProdutoDTO produto)
        {
            if (ModelState.IsValid)
            {
                produto.Id = Guid.NewGuid();
                await _service.CreateAsync(produto);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || !id.HasValue)
            {
                return NotFound();
            }

            var produto = await _service.GetAsync(id.Value);
            produto.ValorHelper = produto.Valor.ToString();
            produto.CustoHelper = produto.Custo.ToString();
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Nome,Valor,Custo,Descricao,Ativo,Id")] ProdutoDTO produto)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateAsync(produto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var produto = await _service.GetAsync(id);
            if (produto != null) {
                await _service.DeleteAsync(produto);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
