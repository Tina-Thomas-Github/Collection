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
    public class DashboardREspositiry
    {
        SqlConnection conn;
        dbConnection ObjCon = dbConnection.GetObject();
        public List<Dashboard1> GetDashboardDetails()
        {
            List<Dashboard1> _modellist = new List<Dashboard1>();
            using (conn = ObjCon.makeConnection())
            {
                var objDetails = SqlMapper.QueryMultiple(conn, "proc_Sum", commandType: CommandType.StoredProcedure);
                _modellist = objDetails.Read<Dashboard1>().ToList();
            }
            return _modellist;
        }
    }
}
