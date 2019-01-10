using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AngularPOC.Common;
using AngularPOC.Entities;
using AngularPOC.Entities.Dto;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic;

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

        public UsersWithPaging GetAllUsersWithCitiesWithPaging(int skip, int take, string orderBy)
        {
            IQueryable<UserMaster> query = Entities.Include(i => i.City);

            if (!string.IsNullOrEmpty(orderBy))
                query= query.OrderBy(SortingHelper.GetSortableString(orderBy));

            query = query.Skip(skip).Take(take);
            
            var users = query.ToList();
            var count = Entities.Count();
            return new UsersWithPaging(users, count);
        }

    }
}
