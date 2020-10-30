using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Helpers;
using BAL.IBusiness;
using DAL.IRepository;
using MODELS;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace BAL.Business
{
    public class DashboardBusiness : IDashboardBusiness
    {
        private readonly IDashboardREspositiry _objDashboardRepository;
        public DashboardBusiness(IDashboardREspositiry DashboardRepository)
        {
            _objDashboardRepository = DashboardRepository;
        }
        public List<Dashboard1> GetDashboardDetails() {
            List<Dashboard1> _modellist = new List<Dashboard1>();
            try
            {
                _modellist = _objDashboardRepository.GetDashboardDetails().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _modellist;
        }
    }
}
