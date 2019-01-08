using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AngularPOC.Entities;
using Microsoft.EntityFrameworkCore;

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

        public IEnumerable<UserMaster> GetAllUsersWithCities()
        {
            return Entities.Include(i => i.City);
        }

    }
}
