using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Helpers;
using BAL.IBusiness;
using DAL.IRepository;
using MODELS;

namespace BAL.Business
{
    public class VendorBusiness : IVendorBusiness
    {
        private readonly IVendorRepository _objVendorRepository;

        public VendorBusiness(IVendorRepository VendorRepository)
        {
            _objVendorRepository = VendorRepository;
        }

        #region Investment Form Vendor

        public IEnumerable<BindAllDropdownlist.DropdownMasterDetails> BindAllDropdownlists(string drpType)
        {
            List<BindAllDropdownlist.DropdownMasterDetails> bindAllDropdownlists = new List<BindAllDropdownlist.DropdownMasterDetails>();
            try
            {
                bindAllDropdownlists = _objVendorRepository.BindAllDropdownlists(drpType).ToList();
            }
            catch (Exception ex)
            { throw ex; }
            return bindAllDropdownlists;
        }
        public List<InvestmentFormModel> CRUD_InvestmentFormVendor(InvestmentFormModel model, string UserId)
        {
            List<InvestmentFormModel> _modellist = new List<InvestmentFormModel>();
            try
            {
                if (model.Operation.ToLower().Trim() == "edit")
                {
                    _modellist = _objVendorRepository.CRUD_InvestmentFormVendor(model, Constants.getbyid, UserId).ToList();
                }
                //else if (model.Opertion.ToLower().Trim() == "delete")
                //{
                //    _modellist = _objVendorRepository.CRUD_InvestmentFormVendor(model, Constants.delete, UserId).ToList();
                //}
                else if (model.Operation.ToLower().Trim() == "list")
                {
                    _modellist = _objVendorRepository.CRUD_InvestmentFormVendor(model, Constants.list, UserId).ToList();
                }
                else if (model.Operation.ToLower().Trim() == "getall")
                {
                    _modellist = _objVendorRepository.CRUD_InvestmentFormVendor(model, Constants.getall, UserId).ToList();
                }
                else
                {
                    if (model.ID != 0)
                        _modellist = _objVendorRepository.CRUD_InvestmentFormVendor(model, Constants.update, UserId);
                    else
                        _modellist = _objVendorRepository.CRUD_InvestmentFormVendor(model, Constants.add, UserId);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _modellist;
        }

        public List<Vendor>CRUD_Vendor(Vendor model)
        {
            List<Vendor> _modellist = new List<Vendor>();
            try
            {
                if (model.Operation.ToLower().Trim() == "edit")
                {
                    _modellist = _objVendorRepository.CRUD_Vendor(model, Constants.getbyid).ToList();
                }
                else if (model.Operation.ToLower().Trim() == "delete")
                {
                    _modellist = _objVendorRepository.CRUD_Vendor(model, Constants.delete).ToList();
                }
                else if (model.Operation.ToLower().Trim() == "list")
                {
                    _modellist = _objVendorRepository.CRUD_Vendor(model, Constants.list).ToList();
                }
                else if (model.Operation.ToLower().Trim() == "getbyid")
                {
                    _modellist = _objVendorRepository.CRUD_Vendor(model, Constants.getbyid).ToList();
                }
                else
                {
                    if (model.VendorId != 0)
                        _modellist = _objVendorRepository.CRUD_Vendor(model, Constants.update);
                    else
                        _modellist = _objVendorRepository.CRUD_Vendor(model, Constants.add);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _modellist;
        }
        #endregion


    }
}
