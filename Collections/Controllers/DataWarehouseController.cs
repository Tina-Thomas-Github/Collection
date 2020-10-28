using BAL.Business;
using BAL.IBusiness;
using MODELS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
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
    }
}