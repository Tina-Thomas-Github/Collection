using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    public interface IAccountRepository
    {
        List<LoginModel> checkUser(LoginModel model);
        IEnumerable<BindAllDropdownlist.DropdownMasterDetails> BindAllDropdownlists(string drpType);
        List<SecurityQuestion> SaveSecurities(SecurityQuestion model);
        List<LoginModel> ResetPassword(LoginModel model);
    }
}
