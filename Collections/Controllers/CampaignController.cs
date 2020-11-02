using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BAL.IBusiness;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using MODELS;
using Newtonsoft.Json;

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
        [HttpPost]
        public ActionResult Customer(string tablename)
        {
            List<MasterData> _model = new List<MasterData>();
            if (ModelState.IsValid)
            {
                _model = _objICampaignBusiness.GetCampaignCustomerDetails(tablename).ToList();
            }
            else
                TempData["ErrorMessage"] = "Some unknown error has occured. Please try again.";

            return Json(_model, JsonRequestBehavior.AllowGet);
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
        [HttpPost]
        public ActionResult Create(Campaign model)
        {
            List<Campaign> _model = new List<Campaign>();
            //if (Request.Files.Count > 0)
            //{
                //HttpPostedFileBase file1 = Request.Files[0];
            //}
            //if (model.FileName != string.Empty && !string.IsNullOrEmpty(model.FileName))
            if (Request.Files.Count > 0)
            {
                string[] fieldNames = Request.Files.AllKeys;
                //var fileName = Path.GetFileName(model.FileName);
                //var path = Path.Combine(Server.MapPath("~/Content/Upload"), fileName);
                //file.SaveAs(path);

                for (int i = 0; i < fieldNames.Length; i++)
                {
                    HttpPostedFileBase file = Request.Files[i];
                    string FName = Request.Files[i].FileName;
                    //HttpPostedFileBase file = Request.Files[0];
                    //model.contentType = Request.ContentType;
                    string folderPath = Server.MapPath("~/UploadFile/");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    file.SaveAs(folderPath + Path.GetFileName(FName));
                    model.FilePath = folderPath + Path.GetFileName(FName);
                    model.FileName = FName.Substring(0, FName.Length - 4);
                }
            }
            if (ModelState.IsValid)
            {
                _model = _objICampaignBusiness.UploadCampaignDetails(model).ToList();
            }
            else
                TempData["ErrorMessage"] = "Some unknown error has occured. Please try again.";

            return Json(_model, JsonRequestBehavior.AllowGet);
        }
    }
}