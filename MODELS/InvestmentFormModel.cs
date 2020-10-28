using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class InvestmentFormModel : ResponseMessageModel
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public string  CustomerNo { get; set; }
        public string  PhoneNo { get; set; }
        public double RevisedDue { get; set; }
        public string  ExitTYpe { get; set; }
        public bool IsActive { get; set; }
        public string ModelStatus { get; set; }
    }
}
