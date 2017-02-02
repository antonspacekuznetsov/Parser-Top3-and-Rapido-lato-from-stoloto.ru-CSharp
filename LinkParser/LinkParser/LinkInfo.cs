using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkParser
{
    class LinkInfo:ICloneable
    {
       public string Url { get; set; }
       public int Code { get; set; }
       public object Clone()
       {
           return this.MemberwiseClone();
       }
    }

}
