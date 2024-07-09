using Microsoft.EntityFrameworkCore;

namespace MailTest.Models
{
    public class ApplicationDbContext : ApplicationDbContext
    {
        public ApplicationDbContext(dbConextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Destinatario> Destinatarios {get; set;}
    }
}