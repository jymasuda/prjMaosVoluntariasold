using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;

namespace prjMaosVoluntarias.Libs
{
    public class EnviarEmail
    {

        public string Destinatario { get; set; }
        public string Assunto { get; set; }
        public string Corpo { get; set; }
        public EnviarEmail(string destinatario, string assunto, string corpo)
        {
            Destinatario = destinatario;
            Assunto = assunto;
            Corpo = corpo;
        }

        public bool enviarEmail(EnviarEmail email)
        {
            string remetente = "maosvoluntarias@outlook.com";
            string senha = "!Mvtcc10";
            string destinatario = email.Destinatario;
            string assunto = email.Assunto;

            SmtpClient client = new SmtpClient();
            client.Credentials = new NetworkCredential(remetente, senha);
            client.Host = "smtp.office365.com";
            client.Port = 587;
            client.EnableSsl = true;

            MailMessage mail = new MailMessage();
            mail.To.Add(destinatario);
            mail.From = new MailAddress(remetente, "Mãos Voluntárias", System.Text.Encoding.UTF8);
            mail.Subject = assunto;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = email.Corpo;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            try
            {
                client.Send(mail);
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}