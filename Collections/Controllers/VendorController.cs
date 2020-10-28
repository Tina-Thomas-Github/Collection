using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.IO;
using BAL.IBusiness;
using MODELS;
//using Collections.Common;
using System.Net.Mime;

using iTextSharp.tool.xml;
using System.Globalization;

namespace Collections.Controllers
{
    public class VendorController : Controller
    {
        private readonly IVendorBusiness _objIVendorBusiness;
        public VendorController(IVendorBusiness objIVendorBusiness)
        {
            _objIVendorBusiness = objIVendorBusiness;
        }

        #region View Vendor
        public ActionResult ViewVendor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CRUD_InvestmentFormMaster(InvestmentFormModel model)
        {
            List<InvestmentFormModel> _model = new List<InvestmentFormModel>();
            try
            {
                _model = _objIVendorBusiness.CRUD_InvestmentFormVendor(model, "ttina123").ToList();
            }
            catch (Exception ex)
            {
                ex.Data.Add("SubscriptionName", "IBL");
            }
            return Json(_model, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Create Vendor
        public ActionResult Create()
        {
            return View();
        }
        #endregion

        #region Edit Vendor
        public ActionResult Edit()
        {
            return View();
        }
        #endregion

        #region Delete Vendor
        public ActionResult Delete()
        { return View(); }
        #endregion

        [HttpPost]
        public ActionResult CRUD_Vendor(Vendor model)
        {
            List<Vendor> _model = new List<Vendor>();
            try
            {
                _model = _objIVendorBusiness.CRUD_Vendor(model).ToList();
            }
            catch (Exception ex)
            {
                ex.Data.Add("SubscriptionName", "IBL");
            }
            return Json(_model, JsonRequestBehavior.AllowGet);
        }
    }
}