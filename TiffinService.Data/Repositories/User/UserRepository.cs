using System;
using System.Linq;
using AngularPOC.Entities;

namespace AngularPOC.Data.Repositories.User
{
    public class UserRepository : GenericRepository<UserMaster>, IUserRepository
    {
        public UserRepository(AngularPOCDbContext context) : base(context)
        {

        }

        public UserMaster AuthenticateUser(string email, string password)
        {
            var user = Entities
                        .FirstOrDefault(w => w.Email.Equals(email, StringComparison.OrdinalIgnoreCase) &&
                                    w.Password.Equals(password, StringComparison.OrdinalIgnoreCase));

            return user;
        }
    }
}
