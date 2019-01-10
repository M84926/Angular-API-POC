using AngularPOC.Entities;
using AngularPOC.Entities.Dto;
using System.Collections.Generic;

namespace AngularPOC.Data.Repositories.User
{
    public interface IUserRepository : IGenericRepository<UserMaster>
    {
        UserMaster AuthenticateUser(string email,string password);

        IEnumerable<UserMaster> GetAllUsersWithCities();

        UsersWithPaging GetAllUsersWithCitiesWithPaging(int skip, int take, string orderBy);
    }
}
