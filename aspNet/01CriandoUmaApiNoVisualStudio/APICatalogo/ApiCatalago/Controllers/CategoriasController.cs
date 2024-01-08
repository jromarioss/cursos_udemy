using Microsoft.AspNetCore.Mvc;

namespace ApiCatalago.Controllers
{
    public class CategoriasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
