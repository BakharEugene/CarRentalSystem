using CarRentalSystem.DAL.Models.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CarRentalSystem.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index(EmailModel model)
        {
            if (model == null)
                model = new EmailModel();
            return View(model);
        }

        public ActionResult Sent(EmailModel model)
        {
            sendMessage(model);
            return View(model);
        }

        private void SendMail(String smtpServer, string from, string password, string mailto, string caption, string message)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add(new MailAddress(mailto));
                mail.Subject = caption;
                mail.Body = message;
                SmtpClient client = new SmtpClient();
                client.Host = smtpServer;
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(from, password);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mail);
                mail.Dispose();
            }
            catch (Exception e)
            {
                throw new Exception("Mail.Send: " + e.Message);
            }
        }
        private void sendMessage(EmailModel email)
        {
            String UserName = "carrentalsystem.contact@gmail.com";
            String Password = "r3zPvlhc";

            StringBuilder b = new StringBuilder();
            b.AppendFormat("From {0} {1}\n", email.FirstName, email.LastName);
            b.AppendLine(email.Description);
            if (email.Phone != null)
            {
                b.AppendLine("Phone: " + email.Phone);
            }
            if (email.Address != null)
            {
                b.AppendLine("Addres: " + email.Address);
            }
            b.AppendLine("Email: " + email.Email);

            SendMail("smtp.gmail.com",
                    UserName,
                    Password,
                    UserName,
                    "Feedback",
                    b.ToString());
        }
    }
}