using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IBusiness
{
    public interface IVendorBusiness
    {
        #region VendorsForm
        IEnumerable<BindAllDropdownlist.DropdownMasterDetails> BindAllDropdownlists(string drpType);
        List<InvestmentFormModel> CRUD_InvestmentFormVendor(InvestmentFormModel model, string UserId);
        List<Vendor> CRUD_Vendor(Vendor model);
        #endregion
    }
}
