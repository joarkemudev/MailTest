using MailTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Thereading.Tasks;

namespace MailTest.AddControllers 
{
    public class DestinatariosController : controller
    {
        private readonly ApplicationDbContext _context;

        public DestinatariosController(ApplicationDbContext context)
        {
            _context = context;
    
        }

        public IActionResult Index()
        {
            return View(_context.Destinatarios.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Create(string nombre, string correo)
        {
            if (ModelState.IsValid)
            {
                var destinatario = new Destinatario { Nombre = nombre, Correo = correo};
                _context.Add(destinatario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}