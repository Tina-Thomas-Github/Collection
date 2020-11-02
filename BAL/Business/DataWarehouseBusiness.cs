using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Helpers;
using BAL.IBusiness;
using DAL.IRepository;
using MODELS;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace BAL.Business
{
    public class DataWarehouseBusiness : IDataWarehouseBusiness
    {
        private readonly IDataWarehouseRepository _objDataWarehouseRepository;
        public DataWarehouseBusiness(IDataWarehouseRepository DataWarehouseRepository)
        {
            _objDataWarehouseRepository = DataWarehouseRepository;
        }
        public List<MasterData> GetMasterDetails(MasterData model) {
            List<MasterData> _modellist = new List<MasterData>();
            try
            {
                _modellist = _objDataWarehouseRepository.GetMasterDetails(model).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _modellist;
        }

    }
}
