using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MailTest.Models;
using MailTest.Services;
using System.Threading.Tasks;
using System.Linq;

namespace MailTest.Pages.Email
{
    public class SendModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly EmailSender _emailSender;

        public SendModel(ApplicationDbContext context, EmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string subject, string message)
        {
            if (ModelState.IsValid)
            {
                var destinatarios = await _context.Destinatarios.ToListAsync();
                var emailAddresses = destinatarios.Select(d => d.Correo).ToList();

                _emailSender.SendEmail(emailAddresses, subject, message);
                return RedirectToPage("/Destinatarios/Index");
            }
            return Page();
        }
    }
}