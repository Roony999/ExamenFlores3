using ExamenFlores3.Areas.Admin.Models;
using ExamenFlores3.Models.Entities;
using ExamenFlores3.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExamenFlores3.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FloresController : Controller
    {
        private readonly FloresRepository repositorio;

        public FloresController(FloresRepository repositorio)
        {
            this.repositorio = repositorio;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(AgregarViewModel vm)
        {
            if(vm != null)
            {
               if(string.IsNullOrWhiteSpace(vm.Nombre))
                {
                   ModelState.AddModelError("","El nombre es requerido");
                }

               if(string.IsNullOrWhiteSpace(vm.Origen))
                   {
                   ModelState.AddModelError("","El origen es requerido");
                   }

                if (string.IsNullOrWhiteSpace(vm.Descripcion)) 
                    {
                    ModelState.AddModelError("", "Se debe de agregar una descripcion");
                    } 

               if(vm.Imagen == null)
                    {
                    ModelState.AddModelError("","La imagen es requerida");
                    }

               if (vm.Imagen != null && vm.Imagen.Length > 1024 * 1024 * 2)
                {
                   ModelState.AddModelError("", "La imagen no debe pesar mas de 2MB");
                }

               if (vm.Imagen != null  && vm.Imagen.ContentType != "image/jpg"  && vm.Imagen.ContentType != "image/jpeg" )
                {
                   ModelState.AddModelError("", "La imagen debe ser jpg");
                }

               if(ModelState.IsValid)
                {
                    var nuevaFlor = new Datos
                    {
                        NombreFlor = vm.Nombre,
                        Origen = vm.Origen,
                        Descripcion = vm.Descripcion,
   
                    };

                    repositorio.Insert(nuevaFlor);
                    
                    if (vm.Imagen != null )
                    {
                        System.IO.FileStream fs = System.IO.File.Create($"wwwroot/images/{nuevaFlor.Id}.jpg");
                        vm.Imagen.CopyTo(fs);
                        fs.Close();
                    }

                    return RedirectToAction("Index", "Home");

                }

            }
            return View(vm);
        }

        public IActionResult Editar(uint Id)
        {
            var flor = repositorio.Get(Id);
            if(flor != null)
            {
                var vm = new AgregarViewModel
                {
					Id = (int)flor.Id,
					Nombre = flor.NombreFlor,
					Origen = flor.Origen,
					Descripcion = flor.Descripcion,
                    Imagen = null!,
                    
				};
				return View(vm);
			

			}
			return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Editar(AgregarViewModel vm)
        {
			if(vm != null)
            {
				if(string.IsNullOrWhiteSpace(vm.Nombre))
                {
					ModelState.AddModelError("","El nombre es requerido");
				}

				if(string.IsNullOrWhiteSpace(vm.Origen))
                {
					ModelState.AddModelError("","El origen es requerido");
				}

				if(string.IsNullOrWhiteSpace(vm.Descripcion))
                {
					ModelState.AddModelError("","La descripcion es requerida");
				}

				if(vm.Imagen != null && vm.Imagen.ContentType != "image/jpg" && vm.Imagen.ContentType != "image/jpeg")
                {
					ModelState.AddModelError("","La imagen debe ser jpg");
				}

				if(ModelState.IsValid)
                {
					var flor = repositorio.Get((uint)vm.Id);
					if(flor != null)
                    {
						flor.NombreFlor = vm.Nombre;
						flor.Origen = vm.Origen;
						flor.Descripcion = vm.Descripcion;
                        repositorio.Update(flor);

						if(vm.Imagen != null)
                        {
							System.IO.FileStream fs = System.IO.File.Create($"wwwroot/images/{flor.Id}.jpg");
							vm.Imagen.CopyTo(fs);
							fs.Close();
						}
						return RedirectToAction("Index", "Home");
					}
				}
			}
			return View(vm);
		}   

        public IActionResult Eliminar(uint Id)
        {
            var flor = repositorio.Get(Id);
            if(flor != null)
            {
				var vm = new EliminarViewModel
                {
					Id = flor.Id,
					Nombre = flor.NombreFlor
				};
				return View(vm);
			}
             
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Eliminar(EliminarViewModel vm)
        {
            if(vm != null)
            {
                var flor = repositorio.Get(vm.Id);
				if(flor != null)
                {
                    repositorio.Delete(flor);
					return RedirectToAction("Index", "Home");
                }
            }
			return RedirectToAction("Index", "Home");
		}
    }
}
