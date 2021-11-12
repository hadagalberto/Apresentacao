using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDV.Net.Application.Interface;
using System;
using System.Threading.Tasks;
using PDV.Net.Application.ViewModel;

namespace PDV.Net.Web.Controllers.Base
{
    public class BaseController<TAppService, TViewModel> : Controller
    where TViewModel : BaseViewModel, new()
    where TAppService : IAppService<TViewModel>
    {

        protected readonly TAppService _appService;

        public BaseController(TAppService appService)
        {
            _appService = appService;
        }

        public virtual async Task<IActionResult> Index()
        {
            return View(await _appService.ListAsync());
        }


        public virtual async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Create(TViewModel dto)
        {
            if (ModelState.IsValid)
            {
                dto.Id = Guid.NewGuid();
                await _appService.CreateAsync(dto);
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

            var dto = await _appService.GetAsync(id.Value);
            
            if (dto == null)
            {
                return NotFound();
            }
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Edit(Guid id, TViewModel dto)
        {
            if (id != dto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _appService.UpdateAsync(dto);
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
            var dto = new TViewModel { Id = id };
            if (dto != null)
            {
                await _appService.DeleteAsync(dto);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
