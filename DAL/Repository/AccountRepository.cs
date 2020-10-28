using DAL.AppConnection;
using DAL.IRepository;
using Dapper;
using MODELS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class AccountRepository : IAccountRepository
    {
        SqlConnection conn;
        dbConnection ObjCon = dbConnection.GetObject();
        //string strConnectionString = ConfigurationManager.ConnectionStrings["SampleTestDB"].ConnectionString;
        public List<LoginModel> checkUser(LoginModel model) //This method check the user existence
        {
            List<LoginModel> _modellist = new List<LoginModel>();
            using (conn = ObjCon.makeConnection())
            {
                var objDetails = SqlMapper.QueryMultiple(conn, "sp_get_ValidateLogin", new { model.username,model.password}, commandType: CommandType.StoredProcedure);
                _modellist = objDetails.Read<LoginModel>().ToList();
            }

            return _modellist;
        }
        public IEnumerable<BindAllDropdownlist.DropdownMasterDetails> BindAllDropdownlists(string drpType)
        {
            List<BindAllDropdownlist.DropdownMasterDetails> bindAllDropdownlists = new List<BindAllDropdownlist.DropdownMasterDetails>();
            try
            {
                conn = ObjCon.makeConnection();
                var objDetails = SqlMapper.QueryMultiple(conn, "sp_get_SecurityQuestionTemplate", commandType: CommandType.StoredProcedure);
                BindAllDropdownlist.DropdownMasterDetails ObjVendor = new BindAllDropdownlist.DropdownMasterDetails();

                ObjVendor._Collection_Models_list = objDetails.Read<BindAllDropdownlist.Generic_Type>().ToList();
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
        public List<SecurityQuestion> SaveSecurities(SecurityQuestion model)
        {
            List<SecurityQuestion> _modellist = new List<SecurityQuestion>();
            try
            {
                using (conn = ObjCon.makeConnection())
                {
                    var objDetails = SqlMapper.QueryMultiple(conn, "[sp_set_SecurityQuestionAnswer]",new { model.sqLoginID, model.sqSecQues1, model.sqSecAns1, model.sqSecQues2, model.sqSecAns2, model.sqSecQues3, model.sqSecAns3 }, commandType: CommandType.StoredProcedure);
                    _modellist = objDetails.Read<SecurityQuestion>().ToList();
                }
            }
            catch (Exception ex)
            {
        //        //    ex.Data.Add("SubscriptionName", "IBL");
        //        //    ex.Data.Add("LoginUser", "");
            }
            finally
            {
                conn = ObjCon.closeConnection();
            }
            return _modellist;
        }
        public List<LoginModel> ResetPassword(LoginModel model) {
            List<LoginModel> modelList = new List<LoginModel>();
            using (conn = ObjCon.makeConnection())
            {
                var objDetails = SqlMapper.QueryMultiple(conn, "[sp_set_LoginPassword]", new { model.username, model.oldPassword, model.password }, commandType: CommandType.StoredProcedure);
                modelList = objDetails.Read<LoginModel>().ToList();
            }
            return modelList;
        }
    }
}
