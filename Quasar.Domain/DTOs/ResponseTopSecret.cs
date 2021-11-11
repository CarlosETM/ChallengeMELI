using System;
using System.Collections.Generic;
using System.Text;

namespace Quasar.Domain.DTOs
{
    public class Position
    {
        public float x { get; set; }
        public float y { get; set; }
    }

    public class ResponseTopSecret
    {
        public Position position { get; set; }
        public string message { get; set; }
    }
    
}
