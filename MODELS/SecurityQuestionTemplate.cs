using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class SecurityQuestionTemplate : ResponseMessageModel
    {
        public int sqtQuestionID { get; set; }
        public string sqlSecurityQuestion { get; set; }
        public string ModelStatus { get; set; }
    }
}
