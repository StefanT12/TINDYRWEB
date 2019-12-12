using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Picture
    {

        public int Id { get; set; }
        public string FileName { get; set; }
        public int AnimalId { get; set; }
        public virtual Animal Animal { get; set; } 
    }
}
