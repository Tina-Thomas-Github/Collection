using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
   public class Campaign : ResponseMessageModel
    {
        public int CampaignID { get; set; }
        public string CampaignName { get; set; }
        public string StartDate { get; set; }
        public string StartTime { get; set; }
        public string Vendor { get; set; }
        public string FileUpload { get; set; }
        //public bool IsActive { get; set; }
        public string ModelStatus { get; set; }
        public int CustomerCount { get; set; }
        public int VendorCount { get; set; }

    }
}
