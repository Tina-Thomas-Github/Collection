using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BAL.IBusiness;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using MODELS;

namespace Collections.Controllers
{
    public class CampaignController : Controller
    {
        private readonly IVendorBusiness _objIVendorBusiness;
        private readonly ICampaignBusiness _objICampaignBusiness;

        public CampaignController(IVendorBusiness objIVendorBusiness, ICampaignBusiness objICampaignBusiness)
        {
            _objIVendorBusiness = objIVendorBusiness;
            _objICampaignBusiness = objICampaignBusiness;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewCampaign()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ViewCampaign(Campaign model)
        {
            List<Campaign> _model = new List<Campaign>();
            if (ModelState.IsValid)
            {
                //model.username = Session["UserID"].ToString();
                _model = _objICampaignBusiness.GetCampaignDetails(model).ToList();
            }
            else
                TempData["ErrorMessage"] = "Some unknown error has occured. Please try again.";

            return Json(_model, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult Delete()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Customer()
        {
            return View();
        }
        [HttpGet]
        public JsonResult BindAllDrodownlist(string drpType)
        {
            BindAllDropdownlist.DropdownMasterDetails _objbindDropdown = new BindAllDropdownlist.DropdownMasterDetails();
            List<BindAllDropdownlist.DropdownMasterDetails> VendorData = new List<BindAllDropdownlist.DropdownMasterDetails>();
            try
            {
                VendorData = _objIVendorBusiness.BindAllDropdownlists(drpType).ToList();
                if (VendorData != null)
                {
                    if (drpType == Constant.dllVendor)
                    {
                        _objbindDropdown._Collection_Models_list = VendorData[0]._Collection_Models_list;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("LoginUser", "Error");
            }
            return Json(_objbindDropdown, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public ActionResult CheckEUINExists(string EUINNo)
        //{
        //    string filePath = string.Empty;
        //    try
        //    {
        //        filePath = _objICampaignBusiness.BindAllDropdownlists("1", "iblfm6942", "117");
        //        if (!string.IsNullOrEmpty(Request["btnSubmit"]))
        //        {
        //            string[] filename = filePath.Split('/');
        //            //ExportToPDF(filePath.Split('//'), Response);
        //        }
        //    }
        //    catch (Exception ex) { }
        //    return View();
        //}
        //public void ExportToPDF(string FileName, HttpResponseBase Response)
        //{
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        byte[] bytearray = ms.ToArray();
        //        Response.Clear();
        //        Response.Buffer = true;
        //        Response.ClearContent();
        //        Response.ClearHeaders();
        //        Response.Charset = "";
        //        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("Content-Length", bytearray.Length.ToString());
        //        Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName.ToString());
        //        Response.WriteFile(FileName);
        //        Response.Flush();
        //        Response.End();
        //        //if (System.IO.File.Exists(FileName))
        //          //  System.IO.File.Delete(FileName);
        //    }
        //}
        //public FileResult Export(string GridHtml)
        //{
        //    try
        //    {
        //        using (MemoryStream stream = new System.IO.MemoryStream())
        //        {
        //            string Date = DateTime.Now.ToString("ddMMyyyy");
        //            string FileName = "AML_" + Date;
        //            StringReader sr = new StringReader(GridHtml);
        //            Document pdfDoc = new Document(PageSize.A4_LANDSCAPE, 10f, 10f, 10f, 0f);
        //            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);//Added                
        //            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
        //            pdfDoc.Open();
        //            htmlparser.Parse(sr);
        //            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
        //            pdfDoc.Close();
        //            return File(stream.ToArray(), "application/pdf", FileName + ".pdf");
        //        }
        //    }
        //    catch { return null; }
        //}
    }
}