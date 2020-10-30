using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Collections.Models
{
    [DataContract]
    public class DataPoint
    {
        public DataPoint(string label, int y)
        {
            this.Label = label;
            this.Y = y;
           
        }
        [DataMember(Name = "label")]
        public string Label = "";

        [DataMember(Name = "y")]
        public Nullable<int> Y = null;

    }
}