using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularPOC.Entities
{
    public class UserMaster : Entity<int>
    {
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        public byte Gender { get; set; }
        public bool IsVerified { get; set; }
        public bool IsDocsSubmited { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [ForeignKey("CityMaster")]
        public int CityId { get; set; }
        
        public string Hobbies { get; set; }


        public CityMaster City { get; set; }

    }
}
