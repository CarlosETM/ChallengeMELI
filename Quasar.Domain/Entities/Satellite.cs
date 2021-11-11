using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Quasar.Domain.Entities
{
     public  class Satellite
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string name { get; set; }
        public string postionX { get; set; }
        public string postionY { get; set; }
        public string Distance { get; set; }
        public string word1 { get; set; }
        public string word2 { get; set; }
        public string word3 { get; set; }
        public string word4 { get; set; }
    }
}
