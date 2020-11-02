using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.AppConnection;
using MODELS;
using DAL.IRepository;
using Dapper;
using System.Data;
using System.Configuration;
using System.Globalization;

namespace DAL.Repository
{
    public class VendorRepository : IVendorRepository
    {
        SqlConnection conn;
        dbConnection ObjCon = dbConnection.GetObject();
        #region 
        public IEnumerable<BindAllDropdownlist.DropdownMasterDetails> BindAllDropdownlists(string drpType)
        {
            List<BindAllDropdownlist.DropdownMasterDetails> bindAllDropdownlists = new List<BindAllDropdownlist.DropdownMasterDetails>();
            try
            {
                conn = ObjCon.makeConnection();
                var objDetails = SqlMapper.QueryMultiple(conn, "BindAllDropdownlists", new { drpType }, commandType: CommandType.StoredProcedure);
                BindAllDropdownlist.DropdownMasterDetails ObjVendor = new BindAllDropdownlist.DropdownMasterDetails();

                if (drpType == Constant.dllVendor)
                {
                    ObjVendor._Collection_Models_list = objDetails.Read<BindAllDropdownlist.Generic_Type>().ToList();
                }
                bindAllDropdownlists.Add(ObjVendor);
            }
            catch (Exception ex)
            {
                ex.Data.Add("SubscriptionName", "IBL");
                ex.Data.Add("LoginUser", "");
            }
            finally
            {
                conn = ObjCon.closeConnection();
            }
            return bindAllDropdownlists;
        }
        //public List<InvestmentFormModel> CRUD_InvestmentFormVendor(InvestmentFormModel model, string type, string UserId)
        //{
        //    List<InvestmentFormModel> _modellist = new List<InvestmentFormModel>();
        //    //try
        //    //{
        //    using (conn = ObjCon.makeConnection())
        //    {
        //        var objDetails = SqlMapper.QueryMultiple(conn, "[CRUD_InvestmentForm_Master]", new { model.ID, model.CustomerName, type, UserId, model.IsActive,model.CustomerNo,model.PhoneNo,model.RevisedDue,model.ExitTYpe }, commandType: CommandType.StoredProcedure);
        //        _modellist = objDetails.Read<InvestmentFormModel>().ToList();
        //    }
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    ex.Data.Add("SubscriptionName", "IBL");
        //    //    ex.Data.Add("LoginUser", "");
        //    //}
        //    //finally
        //    //{
        //    //    conn = ObjCon.closeConnection();
        //    //}
        //    return _modellist;
        //}
        public List<Vendor> CRUD_Vendor(Vendor model, string type)
        {
            List<Vendor> _modellist = new List<Vendor>();
            try
            {
            using (conn = ObjCon.makeConnection())
            {
                var objDetails = SqlMapper.QueryMultiple(conn, "[CRUD_Vendor]", new { model.VendorId, model.VendorName, model.VendorShortName, model.IsActive, type }, commandType: CommandType.StoredProcedure);
                _modellist = objDetails.Read<Vendor>().ToList();
            }
            }
            catch (Exception ex)
            {
            //    ex.Data.Add("SubscriptionName", "IBL");
            //    ex.Data.Add("LoginUser", "");
            }
            finally
            {
                conn = ObjCon.closeConnection();
            }
            return _modellist;
        }
        #endregion
        //public DataSet getPDFData(string id)
        //{

        //    DataSet ds = new DataSet();
        //    using (conn = ObjCon.makeConnection())
        //    {
        //        using (SqlCommand cmd = new SqlCommand("SP_getPDFData", conn))
        //        {
        //            cmd.Parameters.AddWithValue("@id", id.Trim());
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            SqlDataAdapter da = new SqlDataAdapter();
        //            da.SelectCommand = cmd;
        //            da.Fill(ds);
        //        }
        //    }
        //    return ds;
        //}
    }
}
