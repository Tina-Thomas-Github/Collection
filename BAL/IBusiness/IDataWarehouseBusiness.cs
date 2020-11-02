using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IBusiness
{
    public interface IDataWarehouseBusiness
    {
        List<MasterData> GetMasterDetails(MasterData model);
    }
}
