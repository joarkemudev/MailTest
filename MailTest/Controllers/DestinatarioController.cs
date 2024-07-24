using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MailTest.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MailTest.Controllers
{
    public class DestinatariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DestinatariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Acción que devuelve la vista con la lista de destinatarios.
        public async Task<IActionResult> Index()
        {
            return View(await _context.Destinatarios.ToListAsync());
        }

        // GET: Recipients/Create
        public IActionResult Create()
        {
            return View();
        }

        // Acción para agregar un nuevo destinatario.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Email")] Destinatario destinatario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(destinatario);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Email already exists.");
                }
            }
            return View(destinatario); // Corregido aquí
        }
    }
}