using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticaDesarrolloDeSoftware.Datos;
using PracticaDesarrolloDeSoftware.Models;
using System.Diagnostics;

namespace PracticaDesarrolloDeSoftware.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDBContext _contexto;

        public HomeController(ApplicationDBContext contexto)
        {
            _contexto = contexto;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Cliente.ToListAsync());
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _contexto.Cliente.Add(cliente);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cliente = _contexto.Cliente.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _contexto.Update(cliente);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        [HttpGet]
        public IActionResult Detalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cliente = _contexto.Cliente.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cliente = _contexto.Cliente.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }
        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarCliente(int? id)
        {
            var cliente = await _contexto.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return View();
            }
            _contexto.Cliente.Remove(cliente);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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