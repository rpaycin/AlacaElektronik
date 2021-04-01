using Admin.DataLayer;
using Admin.DataLayer.LoginData;
using Alaca.Web.Models;
using System.Collections.Specialized;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;

namespace Alaca.Web.Controllers
{
    public class BizeUlasinController : Controller
    {
        private readonly IFirmsData _firmsData;

        public BizeUlasinController()
        {
            _firmsData = new FirmsData();
        }

        public ActionResult Index()
        {
            FirmaBilgileri firm = _firmsData.GetFirstActiveFirm();

            var layoutModel = new LayoutModel(firm);

            return View(layoutModel);
        }




        [HttpPost]
        public JsonResult SendEmail()
        {
            NameValueCollection form = HttpContext.Request.Form;

            string senderMailAddress = "test@gmail.com"; // todo : değişcek
            const string fromPassword = "test"; // todo : değişcek

            string subject = form["Konu"];
            string body = string.Format("Mail Adresi: {0}, İçerik:{1}", form["EPosta"], form["Mesaj"]);

            MailMessage mailMessage = new MailMessage();
            MailAddress mailAddress = new MailAddress(senderMailAddress, form["AdSoyad"]);
            mailMessage.From = mailAddress;
            mailAddress = new MailAddress(senderMailAddress, "Alaca Elektronik - Bize Ulaşın");
            mailMessage.To.Add(mailAddress);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;

            SmtpClient mailSender = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(senderMailAddress, fromPassword)
            };

            try
            {
                mailSender.Send(mailMessage);
            }
            catch (SmtpFailedRecipientException ex)
            {
            }
            catch (SmtpException ex)
            {
            }
            finally
            {
                mailSender = null;
                mailMessage.Dispose();
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}