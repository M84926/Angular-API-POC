using AngularPOC.Entities;

namespace AngularPOC.Data.Repositories.User
{
    public interface IUserRepository : IGenericRepository<UserMaster>
    {
        UserMaster AuthenticateUser(string email,string password);
    }
}
