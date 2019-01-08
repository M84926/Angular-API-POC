using System;
using System.Collections.Generic;
using System.Text;

namespace AngularPOC.Entities
{
    public class CountryMaster : Entity<int>
    {
        public string CountryName { get; set; }

        public IList<StateMaster> States { get; set; }
    }
}
