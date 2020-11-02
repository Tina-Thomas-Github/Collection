using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    public interface ICampaignRepository
    {
        List<Campaign> GetCampaignDetails(Campaign model);
        List<Campaign> UploadCampaignDetails(Campaign model);
        List<MasterData> GetCampaignCustomerDetails(string tablename);
    }
}
