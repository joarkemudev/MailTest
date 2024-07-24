using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace MailTest.Services
{
    public class EmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendEmail(List<string> toList, string subject, string message)
        {
            // Obtener la configuración del servidor SMTP
            var host = _configuration["Smtp:Host"];
            var portString = _configuration["Smtp:Port"];
            var userName = _configuration["Smtp:User"];
            var password = _configuration["Smtp:Password"];
            var enableSslString = _configuration["Smtp:EnableSsl"];

            if (string.IsNullOrEmpty(host))
            {
                throw new ArgumentNullException(nameof(host), "SMTP configuration value for 'Server' is missing.");
            }

            if (string.IsNullOrEmpty(portString))
            {
                throw new ArgumentNullException(nameof(portString), "SMTP configuration value for 'Port' is missing.");
            }

            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException(nameof(userName), "SMTP configuration value for 'User' is missing.");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password), "SMTP configuration value for 'Password' is missing.");
            }

            if (string.IsNullOrEmpty(enableSslString))
            {
                throw new ArgumentNullException(nameof(enableSslString), "SMTP configuration value for 'EnableSsl' is missing.");
            }

            var port = int.Parse(portString);  // Convertir el puerto a entero
            var enableSsl = bool.Parse(enableSslString);  // Convertir a booleano

            // Configurar el cliente SMTP
            var smtpClient = new SmtpClient(host)
            {
                Port = port,
                Credentials = new NetworkCredential(userName, password),
                EnableSsl = enableSsl,
            };

            // Crear el mensaje de correo
            var mailMessage = new MailMessage
            {
                From = new MailAddress(userName),
                Subject = subject,
                Body = message,
                IsBodyHtml = true,
            };

            // Agregar destinatarios
            foreach (var to in toList)
            {
                if (!string.IsNullOrEmpty(to))
                {
                    mailMessage.To.Add(to);
                }
            }

            // Enviar el correo
            smtpClient.Send(mailMessage);
        }
    }
}