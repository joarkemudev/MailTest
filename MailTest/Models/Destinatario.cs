namespace MailTest.Models
{
    // Representa un destinatario de correo electrónico.
    public class Destinatario
    {
        public int Id { get; set; } // Identificador único.
        public string Nombre { get; set; } // Nombre del destinatario.
        public string Correo { get; set; } // Dirección de correo electrónico del destinatario.
    }
}