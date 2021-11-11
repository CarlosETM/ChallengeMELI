using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TopSecret.API
{
    public class APIBaseSettings
    {
    
        public ConnectionStrings ConnectionStrings { get; set; }
      
    }
    public class ConnectionStrings
    {
        public string DBContext { get; set; }
    }
}
