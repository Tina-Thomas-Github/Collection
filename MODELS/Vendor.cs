using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class Vendor : ResponseMessageModel
    {
            public int VendorId { get; set; }
            public string VendorName { get; set; }
            public string VendorShortName { get; set; }
            public bool IsActive { get; set; }
            public string ModelStatus { get; set; }
    }
}
