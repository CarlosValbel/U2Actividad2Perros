using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using U2Actividad2.Models.Entities;
using U2Actividad2.Models.ViewModels;
namespace U2Actividad2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string id)
        {
            PerrosContext context = new PerrosContext();
            IndexViewModel ivm = new IndexViewModel();
            List<Razas> razas = new();
            if (id != null)
            {
                razas = context.Razas.Where(x => x.Nombre.StartsWith(id)).Select(x => new Razas
                {
                    Id = (int)x.Id,
                    Nombre = x.Nombre
                }).ToList();
            }
            else
            {
                razas = context.Razas.Select(x => new Razas
                {
                    Id = (int)x.Id,
                    Nombre = x.Nombre
                }).ToList();
            }

            ivm.Razas = razas;
            return View(ivm);

        }
        public IActionResult Pais()
        {
            PerrosContext context = new PerrosContext();
            PaisViewModel pvm = new PaisViewModel();
            List<Pais> pais = context.Paises.Select(x => new Pais
            {
                Razas = x.Razas.Select(x => new Razas
                {
                    Id = (int)x.Id,
                    Nombre = x.Nombre
                }).ToList(),
                Nombre = x.Nombre ?? "Sin nombre"
            }).ToList();
            pvm.Pais = pais;
            return View(pvm);
        }
        public IActionResult Raza(string id)
        {
            PerrosContext context = new PerrosContext();
            RazaViewModel rvm = new RazaViewModel();
            Raza raza = context.Razas
                .Include(x => x.Caracteristicasfisica)
                .Include(x => x.Estadisticasraza)
                .Where(x => id == x.Nombre).First();
            Random r = new();
            List<Razas> Sugerencia = new();
            List<int> PerrosSugeridos = context.Razas.Select(x => (int)x.Id).ToList();
            for (int i = 0; i <= 4; i++)
            {
                int random = r.Next(0, PerrosSugeridos.Count());
                Razas s = context.Razas.Where(x => x.Id == PerrosSugeridos[random])
                    .Select(x => new Razas
                    {
                        Id = (int)x.Id,
                        Nombre = x.Nombre
                    }).First();
                Sugerencia.Add(s);
            }
            rvm.Perro = raza;
            rvm.Otros = Sugerencia;
            return View(rvm);
        }
    }
}
