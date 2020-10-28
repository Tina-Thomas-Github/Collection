using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class BindAllDropdownlist
    {
        public class DropdownMasterDetails
        {
            public List<Generic_Type> _Collection_Models_list { get; set; }
        }
        public class Generic_Type
        {
            public int Id { get; set; }
            public string Type { get; set; }
        }

    }
    
}
