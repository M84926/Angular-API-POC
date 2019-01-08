using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AngularPOC.Entities
{
    public class CityMaster : Entity<int>
    {
        [ForeignKey("StateMaster")]
        public int StateId { get; set; }

        public string CityName { get; set; }

        public StateMaster State { get; set; }
    }
}
