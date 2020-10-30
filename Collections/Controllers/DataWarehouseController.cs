using BAL.Business;
using BAL.IBusiness;
using MODELS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Collections.Controllers
{
    public class DataWarehouseController : Controller
    {
        private readonly ICampaignBusiness _objICampaignBusiness;

        public DataWarehouseController(ICampaignBusiness objICampaignBusiness)
        {
            _objICampaignBusiness = objICampaignBusiness;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Explore()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Export(string GridHtml)
        {
            List<EmailModel> people = new List<EmailModel>();
            string jsonResult;
            using (StreamReader streamReader = new StreamReader(Server.MapPath("~/data/people.json")))
            {
                jsonResult = streamReader.ReadToEnd();
            }
            people = JsonConvert.DeserializeObject<List<EmailModel>>(jsonResult);

            bool k = SendEmail(people, GridHtml);

            //return new JsonResult { Data = k, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return Json(k, JsonRequestBehavior.AllowGet);
        }
        public static bool SendEmail(List<EmailModel> mailto, string GridHtml)
        {
            Boolean isSend = false;
            String mailfrom = ConfigurationManager.AppSettings["FromMail"].ToString();
            String uid = ConfigurationManager.AppSettings["UserID"].ToString();
            String pwd = ConfigurationManager.AppSettings["Password"].ToString();
            String Sub = ConfigurationManager.AppSettings["Sub"].ToString();
            String Host = ConfigurationManager.AppSettings["Host"].ToString();
            String Port = ConfigurationManager.AppSettings["Port"].ToString();

            String mailMessage = GridHtml;

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(mailfrom);
            foreach (var item in mailto)
            {
                msg.To.Add(new MailAddress(item.Email));
            }

            msg.Subject = Sub;
            msg.Body = mailMessage;
            msg.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = Host;
            smtp.Port = Convert.ToInt32(Port);

            NetworkCredential networkcred = new NetworkCredential();
            networkcred.UserName = uid.ToString();
            networkcred.Password = pwd.ToString();
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = networkcred;
            smtp.EnableSsl = true;

            try
            {
                //smtp.Send(msg);
                isSend = true;
            }
            catch
            {
                isSend = false;
            }
            finally
            {
                msg = null;
                smtp = null;
            }

            return isSend;
        }
       
    }
}