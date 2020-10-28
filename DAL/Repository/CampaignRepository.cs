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
    public class CampaignRepository : ICampaignRepository
    {
        SqlConnection conn;
        dbConnection ObjCon = dbConnection.GetObject();
        public List<Campaign> GetCampaignDetails(Campaign model) {
            List<Campaign> _modellist = new List<Campaign>();
            using (conn = ObjCon.makeConnection())
            {
                var objDetails = SqlMapper.QueryMultiple(conn, "Get_CampaignDetails", commandType: CommandType.StoredProcedure);
                _modellist = objDetails.Read<Campaign>().ToList();
            }
            return _modellist;
        }
    }
}
