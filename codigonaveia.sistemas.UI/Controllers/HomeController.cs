using codigonaveia.sistemas.UI.Models;
using codigonaveia.sistemas.UI.Repositoy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace codigonaveia.sistemas.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ServicesRepository _servicesRepository = new ServicesRepository();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            
            var resultado = _servicesRepository.ObterEstados().ToList();
            ViewBag.Estado = new SelectList(resultado, "Id", "EstadoNome");
            return View();
        }
        public JsonResult ObterCidadePorId(int Id)
        {
            var resultado = new SelectList(_servicesRepository.ObterCidadesPorId(Id),"Id","CidadeNome").ToList();
            return Json(resultado);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}