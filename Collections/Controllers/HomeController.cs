using BAL.IBusiness;
using Collections.DBRepository;
using Collections.Models;
using MODELS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Collections.Controllers
{
    public class HomeController : Controller
    {
        DashboadContext da = new DashboadContext();
        //private readonly IDashboardBusiness _objDasboardBusiness;
        //private readonly ICampaignBusiness _objICampaignBusiness;

        //public HomeController(IDashboardBusiness objDasboardBusiness)
        //{
        //    _objDasboardBusiness = objDasboardBusiness;
        //    //_objICampaignBusiness = objICampaignBusiness;
        //}
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //public ActionResult Dashboard()
        //{
        //    ViewBag.Message = "";
        //    return View();
        //}
        [HttpGet]
        //public PartialViewResult Filter()
        //{
        //    return PartialView("Filter");
        //}

        public ActionResult DashboardUser()
        {
            List<DataPoint> dataPoints = new List<DataPoint>();
            List<Dashboard1> _model = new List<Dashboard1>();
            _model = da.loadDashboardCamp1();

            foreach (var item in _model)
            {
                dataPoints.Add(new DataPoint(item.Name, (item.Total)));
            }

            ViewBag.DashboardCamp1 = JsonConvert.SerializeObject(dataPoints);

            _model.Clear();
            dataPoints.Clear();
            _model = da.loadDashboardCamp2();

            foreach (var item in _model)
            {
                dataPoints.Add(new DataPoint(item.Name, (item.Total)));
            }

            ViewBag.DashboardCamp2 = JsonConvert.SerializeObject(dataPoints);

            _model.Clear();
            dataPoints.Clear();
            _model = da.loadDashboardCamp3();

            foreach (var item in _model)
            {
                dataPoints.Add(new DataPoint(item.Name, (item.Total)));
            }

            ViewBag.DashboardCamp3 = JsonConvert.SerializeObject(dataPoints);

            _model.Clear();
            dataPoints.Clear();
            _model = da.loadDashboardCamp4();

            foreach (var item in _model)
            {
                dataPoints.Add(new DataPoint(item.Name, (item.Total)));
            }

            ViewBag.DashboardCamp4 = JsonConvert.SerializeObject(dataPoints);

            _model.Clear();
            dataPoints.Clear();
            _model = da.loadDashboardCamp5();

            foreach (var item in _model)
            {
                dataPoints.Add(new DataPoint(item.Name, (item.Total)));
            }

            ViewBag.DashboardCamp5 = JsonConvert.SerializeObject(dataPoints);

            _model.Clear();
            dataPoints.Clear();
            _model = da.loadDashboardCamp6();

            foreach (var item in _model)
            {
                dataPoints.Add(new DataPoint(item.Name, (item.Total)));
            }

            ViewBag.DashboardCamp6 = JsonConvert.SerializeObject(dataPoints);
            
            _model.Clear();
            dataPoints.Clear();
            _model = da.loadVendorDashboard1();

            foreach (var item in _model)
            {
                dataPoints.Add(new DataPoint(item.Name, (item.Total)));
            }

            ViewBag.loadVendorDashboard1 = JsonConvert.SerializeObject(dataPoints);

            _model.Clear();
            dataPoints.Clear();
            _model = da.loadVendor1Dashboard();

            foreach (var item in _model)
            {
                dataPoints.Add(new DataPoint(item.Name, (item.Total)));
            }

            ViewBag.loadVendor1Dashboard = JsonConvert.SerializeObject(dataPoints);


            return View();
        }
    }
}