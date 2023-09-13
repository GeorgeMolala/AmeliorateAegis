using AmeliorateAegis.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AmeliorateAegis.Controllers
{
    [Area("Liason")]
    [Authorize(Roles = SD.ProvincialLiason)]
    public class EmailController : Controller
    {
        //GET Email
        public ActionResult SendEmail()
        {
            return View();
        }


        //POST
        [HttpPost]
        public ActionResult SendEmail(Models.MailModel _objModelMail)
        {
            if (ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(_objModelMail.To);
                mail.From = new MailAddress(_objModelMail.From);
                mail.Subject = _objModelMail.Subject;
                string Body = _objModelMail.Body;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("katliieykay@gmail.com", "0844463010Kamo");  
                smtp.EnableSsl = true;
                smtp.Send(mail);
                ViewBag.msg = "Email successfully sent...";
                return View( _objModelMail);
            }
            else { return View();
            }
        }
    }
}
