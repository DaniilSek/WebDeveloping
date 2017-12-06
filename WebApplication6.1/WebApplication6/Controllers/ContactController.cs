using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication6.Models;
using System.Net;
using System.Net.Mail;

namespace WebApplication6.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Send(MessageModel message)
        {
            try
            {
                var emailMessage = new MailMessage(SMTPModel.Email, message.Email, message.Topic, message.Text);

                using (var client = new SmtpClient(SMTPModel.Host, SMTPModel.Port))
                {

                    client.Credentials = new NetworkCredential(SMTPModel.Login, SMTPModel.Password);
                    client.EnableSsl = true;
                    client.Send(emailMessage);

                }

                ViewBag.SuccessMessage = "Сообщение успешно отправлено!";
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
            }

            return View("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
