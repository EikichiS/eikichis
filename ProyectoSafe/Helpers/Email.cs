using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace Helpers
{
    public static class Email
    {
        private static SmtpClient cliente
        {
            get
            {
                return new SmtpClient
                {
                    Host = "Smtp.Gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    Timeout = 10000,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,

                    Credentials = new NetworkCredential("notificaciones.safe@gmail.com", "safe12345")
                };
            }
        }

        public static string fillConfirmacionTemplate(string nombre, string paciente, string fecha, string hora, string lugar, string direccion)
        {
            try
            {
                string directoryPath = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName);
                string filePath = string.Format("{0}\\Helpers\\ConfirmaHoraTemplate.html", directoryPath);

                string filledTemplate = string.Empty;
                using (StreamReader reader = new StreamReader(filePath))
                {
                    filledTemplate = reader.ReadToEnd();
                }

                filledTemplate = filledTemplate.Replace("{nombre}", nombre);
                filledTemplate = filledTemplate.Replace("{paciente}", paciente);
                filledTemplate = filledTemplate.Replace("{fecha}", fecha);
                filledTemplate = filledTemplate.Replace("{hora}", hora);
                filledTemplate = filledTemplate.Replace("{lugar}", lugar);
                filledTemplate = filledTemplate.Replace("{direccion}", direccion);

                return filledTemplate;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static void ConfirmacionMedicoMail(string template, string email)
        {
            SmtpClient cliente = Helpers.Email.cliente;

            try
            {
                MailMessage mmsg = new MailMessage();

                mmsg.Subject = "Tienes una visita medica!";
                mmsg.SubjectEncoding = System.Text.Encoding.UTF8;
                mmsg.To.Add(email);
                mmsg.From = new System.Net.Mail.MailAddress("notificaciones.safe@gmail.com");
                mmsg.Body = template;
                mmsg.BodyEncoding = System.Text.Encoding.UTF8;
                mmsg.IsBodyHtml = true;

                cliente.Send(mmsg);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        }
    }