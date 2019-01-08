using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AngularPOC.Entities
{
    public class StateMaster : Entity<int>
    {
        [ForeignKey("CountryMaster")]
        public int CountryId { get; set; }

        public string StateName { get; set; }

        public CountryMaster Country { get; set; }
        public IList<CityMaster> Cities { get; set; }
    }
}
