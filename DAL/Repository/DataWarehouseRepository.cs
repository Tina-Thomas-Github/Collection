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
    public class DataWarehouseRepository : IDataWarehouseRepository
    {
        SqlConnection conn;
        dbConnection ObjCon = dbConnection.GetObject();
        public List<MasterData> GetMasterDetails(MasterData model) {
            List<MasterData> _modellist = new List<MasterData>();
            using (conn = ObjCon.makeConnection())
            {
                var objDetails = SqlMapper.QueryMultiple(conn, "sp_GetDatawareHouseDetails", commandType: CommandType.StoredProcedure);
                _modellist = objDetails.Read<MasterData>().ToList();
            }
            return _modellist;
        }
    }
}
