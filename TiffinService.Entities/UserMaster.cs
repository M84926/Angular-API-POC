using static AngularPOC.Entities.Enums;

namespace AngularPOC.Entities
{
    public class UserMaster : Entity<int>
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool Admin { get; set; }

        public TiffinType DefaultTiffinType { get; set; }

        public bool DefaultBM { get; set; }

        public bool Active { get; set; }
    }
}
