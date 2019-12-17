using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tindyr.Models.ProfileEdit;

namespace Tindyr.Models.Browse 
{
    public class BrowseAnimalsModel
    {
        public bool UserIsValidated { get; set; }
        public List<AnimalModel> Animals { get; set; }
        public BrowseAnimalsModel()
        {
            Animals = new List<AnimalModel>();
        }
    }
}
