using BAL.IBusiness;

using MODELS;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices.AccountManagement;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Collections.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountBusiness _objIAccountBusiness;
        public AccountController(IAccountBusiness objIAccountBusiness)
        {
            _objIAccountBusiness = objIAccountBusiness;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            List<LoginModel> _model = new List<LoginModel>();
            if (ModelState.IsValid)
            {
                _model = _objIAccountBusiness.checkUser(model).ToList();
                Session["UserID"] = Convert.ToString(model.username);
            }
            else
                TempData["ErrorMessage"] = "Please enter valid Email and Password";

            return Json(_model, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Reset()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Reset(LoginModel model)
        {
            List<LoginModel> _model = new List<LoginModel>();
            if (ModelState.IsValid)
            {
                model.username = Session["UserID"].ToString();
                _model = _objIAccountBusiness.ResetPassword(model).ToList();
            }
            else
                TempData["ErrorMessage"] = "Some unknown error has occured. Please try again.";

            return Json(_model, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Security()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Security(SecurityQuestion model)
        {
            List<SecurityQuestion> _model = new List<SecurityQuestion>();
            if (ModelState.IsValid)
            {
                model.sqLoginID = Session["UserID"].ToString();
                _model = _objIAccountBusiness.SaveSecurities(model).ToList();
            }
            else
                TempData["ErrorMessage"] = "Some unknown error has occured. Please try again.";

            return Json(_model, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Forgot()
        {
            return View();
        }
        public ActionResult NewPassword()
        {
            return View();
        }
        [HttpGet]
        public JsonResult BindAllDropdownlist(string drpType)
        {
            BindAllDropdownlist.DropdownMasterDetails _objbindDropdown = new BindAllDropdownlist.DropdownMasterDetails();
            List<BindAllDropdownlist.DropdownMasterDetails> SecurityQuestions = new List<BindAllDropdownlist.DropdownMasterDetails>();
            try
            {
                SecurityQuestions = _objIAccountBusiness.BindAllDropdownlists(drpType).ToList();
                if (SecurityQuestions != null)
                {
                    //if (drpType == Constant.dllVendor)
                    //{
                        _objbindDropdown._Collection_Models_list = SecurityQuestions[0]._Collection_Models_list;
                    //}
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("LoginUser", "Error");
            }
            return Json(_objbindDropdown, JsonRequestBehavior.AllowGet);
        }
    }
}