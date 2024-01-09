using ExamenFlores3.Models.ViewModels;
using ExamenFlores3.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExamenFlores3.Controllers
{
    public class HomeController : Controller
    {
        private readonly FloresRepository repositorio;

        public HomeController(FloresRepository repositorio)
        {
            this.repositorio = repositorio;
        }

        public IActionResult Index()
        {
           var flores = repositorio
                .GetAll()
                .Select(x => new IndexViewModel
           {
               Nombre = x.NombreFlor,
           });


            return View(flores);
        }

        [Route("Detalles/{id}")]
        public IActionResult Detalles(string Id)
        {
            
            var flor = repositorio.GetByNombre(Id.Replace("-", " "));
            if(flor == null)
            {
                return RedirectToAction("Index");
            }

            var floresAleatorias = repositorio
                .GetAll()
                .Where(x => x.Id != flor.Id)
                .OrderBy(x => x.Id)
                .Take(3)
                .Select(x => new FlorModel
                {
                    Nombre = x.NombreFlor
                });

            var vm = new DetallesViewModel
            {
                Id = flor.Id,
                Nombre = flor.NombreFlor,
                Origen = flor.Origen,
                Descripcion = flor.Descripcion,
                Flores = floresAleatorias
            };  


            return View(vm);
        }
    }
}
