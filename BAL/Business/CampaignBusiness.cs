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
    public class CampaignBusiness : ICampaignBusiness
    {
        private readonly ICampaignRepository _objCampaignRepository;
        public CampaignBusiness(ICampaignRepository CampaignRepository)
        {
            _objCampaignRepository = CampaignRepository;
        }
        public List<Campaign> GetCampaignDetails(Campaign model) {
            List<Campaign> _modellist = new List<Campaign>();
            try
            {
                _modellist = _objCampaignRepository.GetCampaignDetails(model).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _modellist;
        }
    }
}
