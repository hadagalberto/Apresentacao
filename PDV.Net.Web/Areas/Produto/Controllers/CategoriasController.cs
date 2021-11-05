using Microsoft.AspNetCore.Mvc;

namespace PDV.Net.Web.Areas.Produto.Controllers
{
    public class CategoriasController : Controller
    {
        [Area("Produto")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
