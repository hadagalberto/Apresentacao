using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PDV.Net.Domain.DTO;
using PDV.Net.Domain.Entity;
using PDV.Net.Domain.Interface.Service;

namespace PDV.Net.Web.Controllers.Base
{
    public class BaseController<Service, DTO, Entity> : Controller
    where DTO : BaseDTO, new()
    where Entity : BaseEntity
    where Service : IBaseService<DTO, Entity>
    {

        protected readonly Service _service;

        public BaseController(Service service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> Index()
        {
            return View(await _service.ListAsync());
        }


        public virtual async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Create(DTO dto)
        {
            if (ModelState.IsValid)
            {
                dto.Id = Guid.NewGuid();
                await _service.CreateAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        public virtual async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || !id.HasValue)
            {
                return NotFound();
            }

            var dto = await _service.GetAsync(id.Value);
            
            if (dto == null)
            {
                return NotFound();
            }
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Edit(Guid id, DTO dto)
        {
            if (id != dto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateAsync(dto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var dto = new DTO { Id = id };
            if (dto != null)
            {
                await _service.DeleteAsync(dto);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
