using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AngularPOC.Entities;
using AngularPOC.Entities.Dto;
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

        public UsersWithPaging GetAllUsersWithCitiesWithPaging(int skip,int take)
        {
            var users = Entities.Include(i => i.City).Skip(skip).Take(take).ToList();
            var count = Entities.Count();
            return new UsersWithPaging(users, count);
        }

    }
}
