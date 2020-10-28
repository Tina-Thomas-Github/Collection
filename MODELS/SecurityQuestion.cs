using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class SecurityQuestion : ResponseMessageModel
    {
        public string sqLoginID { get; set; }
        public string sqSecQues1 { get; set; }
        public string sqSecAns1 { get; set; }
        public string sqSecQues2 { get; set; }
        public string sqSecAns2 { get; set; }
        public string sqSecQues3 { get; set; }
        public string sqSecAns3 { get; set; }
        public string ModelStatus { get; set; }
    }
}
