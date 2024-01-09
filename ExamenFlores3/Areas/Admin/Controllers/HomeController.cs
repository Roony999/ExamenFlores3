using ExamenFlores3.Areas.Admin.Models;
using ExamenFlores3.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExamenFlores3.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly FloresRepository repositorio;

        public HomeController(FloresRepository repositorio)
        {
            this.repositorio = repositorio;
        }

        public IActionResult Index()
        {

            var vm = repositorio
                .GetAll()
                .Select(flor => new IndexViewModel
            {
               Id = flor.Id,
               Nombre = flor.NombreFlor
            });

            return View(vm);
        }
    }
}
