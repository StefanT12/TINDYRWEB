using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Picture
    {

        //Has a one-to-zero-or-one relationship to User, hence the PK is also a FK. - good note but 
        //we set validation for entities in Persistence, since we want to decouple Domain from any dependency
        public int Id { get; set; }
        public string FileName { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public override string ToString()
        {
            return FileName;
        }
    }
}
