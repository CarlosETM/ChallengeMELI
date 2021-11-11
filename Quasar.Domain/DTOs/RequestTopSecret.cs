using System;
using System.Collections.Generic;
using System.Text;

namespace Quasar.Domain.DTOs
{
    public class Satellite2
    {
        public string name { get; set; }
        public double distance2 { get; set; }
        public Messaeges message { get; set; }

        public float PositionX { get; set; }

        public float PositionY { get; set; }
    }

    public class RequestTopSecret
    {
        public List<Satellite2> satellites { get; set; }
    }

    public class Messaeges
    {
        public string word1 { get; set; }
        public string word2 { get; set; }
        public string word3 { get; set; }
        public string word4 { get; set; }
    }
}
