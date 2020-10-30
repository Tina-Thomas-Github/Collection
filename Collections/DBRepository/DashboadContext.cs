using MODELS;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Collections.DBRepository
{
    public class DashboadContext: DbContext
    {
        public DashboadContext()
           : base("Collections")
        {
        }

        public List<Dashboard1> loadDashboardCamp1()
        {
            var sqlParam = new SqlParameter[] {
            };
            //var sqlQuery = @"proc_Sum";
            var sqlQuery = @"sp_RevisedRange_from_tb_09232020_Frontier_Resi_DC_Exit_31_to_60";
            var res = this.Database.SqlQuery<Dashboard1>(sqlQuery, sqlParam).ToList();
            return res;
        }
        public List<Dashboard1> loadDashboardCamp2()
        {
            var sqlParam = new SqlParameter[] {};
            var sqlQuery = @"sp_RevisedRange_from_tb_09232020_Frontier_Resi_DC_Exit_61_to_90";
            var res = this.Database.SqlQuery<Dashboard1>(sqlQuery, sqlParam).ToList();
            return res;
        }
        public List<Dashboard1> loadDashboardCamp3()
        {
            var sqlParam = new SqlParameter[] { };
            var sqlQuery = @"sp_RevisedRange_from_tb_09232020_Frontier_Resi_DC_Exit_below_30";
            var res = this.Database.SqlQuery<Dashboard1>(sqlQuery, sqlParam).ToList();
            return res;
        }
        public List<Dashboard1> loadDashboardCamp4()
        {
            var sqlParam = new SqlParameter[] { };
            var sqlQuery = @"sp_RevisedRange_from_tb_09232020_Frontier_Resi_DC_Exit_over_90";
            var res = this.Database.SqlQuery<Dashboard1>(sqlQuery, sqlParam).ToList();
            return res;
        }
        public List<Dashboard1> loadDashboardCamp5()
        {
            var sqlParam = new SqlParameter[] { };
            var sqlQuery = @"sp_RevisedRange_from_tb_09232020_Frontier_Resi_SO_Exit_31_to_60";
            var res = this.Database.SqlQuery<Dashboard1>(sqlQuery, sqlParam).ToList();
            return res;
        }
        public List<Dashboard1> loadDashboardCamp6()
        {
            var sqlParam = new SqlParameter[] { };
            var sqlQuery = @"sp_RevisedRange_from_tb_09232020_Frontier_Resi_SO_Exit_61_to_90";
            var res = this.Database.SqlQuery<Dashboard1>(sqlQuery, sqlParam).ToList();
            return res;
        }
        public List<Dashboard1> loadVendorDashboard1()
        {
            var sqlParam = new SqlParameter[] { };
            var sqlQuery = @"sp_vendor_and_customercount";
            var res = this.Database.SqlQuery<Dashboard1>(sqlQuery, sqlParam).ToList();
            return res;
        }
      
        public List<Dashboard1> loadVendor1Dashboard()
        {
            var sqlParam = new SqlParameter[] { };
            var sqlQuery = @"sp_vendor_and_totalPaymentCollected";
            var res = this.Database.SqlQuery<Dashboard1>(sqlQuery, sqlParam).ToList();
            return res;
        }
        
    }
}