using BAL.IBusiness;
using DAL.IRepository;
using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Business
{
   public class AccountBusiness : IAccountBusiness
    {
        private readonly IAccountRepository _objAccountRepository;

        public AccountBusiness(IAccountRepository AccountRepository)

        {
            _objAccountRepository = AccountRepository;
        }
        public List<LoginModel> checkUser(LoginModel model)
        {
            List<LoginModel> _modellist = new List<LoginModel>();
            try
            {
                 _modellist = _objAccountRepository.checkUser(model).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _modellist;
        }
        public IEnumerable<BindAllDropdownlist.DropdownMasterDetails> BindAllDropdownlists(string drpType)
        {
            List<BindAllDropdownlist.DropdownMasterDetails> bindAllDropdownlists = new List<BindAllDropdownlist.DropdownMasterDetails>();
            try
            {
                bindAllDropdownlists = _objAccountRepository.BindAllDropdownlists(drpType).ToList();
            }
            catch (Exception ex)
            { throw ex; }
            return bindAllDropdownlists;
        }
        public List<SecurityQuestion> SaveSecurities(SecurityQuestion model)
        {
            List<SecurityQuestion> _modellist = new List<SecurityQuestion>();
            try
            {
                _modellist = _objAccountRepository.SaveSecurities(model).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _modellist;
        }

        public List<LoginModel> ResetPassword(LoginModel model) {
            List<LoginModel> _modellist = new List<LoginModel>();
            try
            {
                _modellist = _objAccountRepository.ResetPassword(model).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _modellist;
        }
    }
}
