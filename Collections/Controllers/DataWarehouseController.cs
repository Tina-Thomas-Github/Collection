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
        private readonly IDataWarehouseBusiness _objIDataWarehouseBusiness;

        public DataWarehouseController(IDataWarehouseBusiness objIDataWarehouseBusiness)
        {
            _objIDataWarehouseBusiness = objIDataWarehouseBusiness;
        }
        // GET: WritePDFData
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
        public ActionResult Create(MasterData model)
        {
            List<MasterData> _model = new List<MasterData>();
            if (ModelState.IsValid)
            {
                _model = _objIDataWarehouseBusiness.GetMasterDetails(model).ToList();
            }
            else
                TempData["ErrorMessage"] = "Some unknown error has occured. Please try again.";

            return Json(_model, JsonRequestBehavior.AllowGet);
        }
        //[HttpPost]
        //public ActionResult GeneratePDF(WritePDFDataModel objWritePDFDataModel)
        //{
        //    //_objIWritePDFDataBusiness.GeneratePDF(objWritePDFDataModel.sourceFile, objWritePDFDataModel.newFile, objWritePDFDataModel.writeText, objWritePDFDataModel.id);
        //    string strPath = "";
        //    try
        //    {
        //        strPath = _objIWritePDFDataBusiness.GeneratePDF(objWritePDFDataModel.id);

        //        //Response.Clear();
        //        //Response.ClearContent();
        //        //Response.ClearHeaders();
        //        //Response.ContentType = "application/pdf";
        //        //Response.AddHeader("Content-Disposition", "attachment;filename=" + Path.GetFileName(strPath).ToString());
        //        //Response.WriteFile(strPath);
        //        //Response.Flush();
        //        //return strPath;
        //        //ApplicationInstance.CompleteRequest();
        //        //GetReport(strPath);
        //        //var v1 = DownloadFile(strPath);
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return Json(new { FileName = strPath });

        //}

        //[AllowAnonymous]
        //[HttpGet]
        //public async Task<FileResult> DownloadFile(string FileName)
        //{
        //    string Filepath = ConfigurationManager.AppSettings["DestinationFolderFilePath"];
        //    var path = ConfigurationManager.AppSettings["DestinationFolderFilePath"];
        //    var Filespath = path + FileName;
        //    var memory = new MemoryStream();
        //    try
        //    {
        //        using (var stream = new FileStream(Filespath, FileMode.Open))
        //        {
        //            await stream.CopyToAsync(memory);
        //        }
        //    }
        //    catch (Exception ex)
        //    { }
        //    memory.Position = 0;
        //    return File(memory, path, Path.GetFileName(Filespath));
        //}

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

            return new JsonResult { Data = k, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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
                smtp.Send(msg);
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