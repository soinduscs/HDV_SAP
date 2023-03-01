using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class clsCorreo
    {
        private string Email;
        private string Asunto;
        private string Mensaje;
        private int prioridad;
        public int Error;
        public string MensajeError;

        public clsCorreo(string e_mail, string asunto, string mensaje, int prioridad, string Adjunto)
        {
            MailMessage email = new MailMessage();

            this.Email = e_mail;
            this.Asunto = asunto;
            this.Mensaje = mensaje;
            this.prioridad = prioridad;
            email.IsBodyHtml = true;
            if (this.prioridad==0)
            {
                email.Priority = MailPriority.High;
            }
            else
            {
                email.Priority = MailPriority.Normal;
            }
           
            if (Adjunto!=string.Empty)
            {
                email.Attachments.Add(new Attachment(Adjunto, System.Net.Mime.MediaTypeNames.Application.Pdf));
            }
           





            email.To.Add(new MailAddress(e_mail));
            email.From = new MailAddress("sistema@huertosdelvalle.cl");
            email.Subject =  "("+DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) - " + asunto;
            email.Body = mensaje;
            


            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.office365.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("sistema@huertosdelvalle.cl", "sistema2017");



           

            try
            {
                smtp.Send(email);
                email.Dispose();
                this.MensajeError = "Corre electrónico fue enviado satisfactoriamente.";
                this.Error = 0;
            }
            catch (Exception ex)
            {
                this.MensajeError = "error envio correo - " + ex.Message;
                this.Error = 9999;
            }


        }
    }
}
