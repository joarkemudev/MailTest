using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MailTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MailTest.Pages.Destinatarios
{
    // Modelo de página para la vista de destinatarios.
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Destinatario> Destinatarios { get; set; }

        public async Task OnGetAsync()
        {
            Destinatarios = await _context.Destinatarios.ToListAsync();
        }
    }
}