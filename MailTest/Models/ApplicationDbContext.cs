using Microsoft.EntityFrameworkCore;

namespace MailTest.Models
{
    // Representa una solicitud de envío de correo electrónico.
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Destinatario> Destinatarios { get; set; }
    }
}