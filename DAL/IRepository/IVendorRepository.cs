using MODELS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    public interface IVendorRepository
    {
        #region 
        IEnumerable<BindAllDropdownlist.DropdownMasterDetails> BindAllDropdownlists(string drpType);
        List<InvestmentFormModel> CRUD_InvestmentFormVendor(InvestmentFormModel model, string status, string UserId);
        List<Vendor>CRUD_Vendor (Vendor model, string status);
        #endregion
    }
}
