﻿using AngularPOC.Common;
using AngularPOC.Entities;
using AngularPOC.Entities.Dto;
using AngularPOC.Service.EntityService;

namespace AngularPOC.Service.UserService
{
    public interface IUserService : IEntityService<UserMaster>
    {
        ApiResponse<UserMaster> AuthenticateUser(string email, string password);

        ApiResponse<UserMaster> GetAllUsers();

        ApiResponse<UserMaster> GetAllUsersWithCities();

        ApiResponse<UsersWithPaging> GetAllUsersWithCitiesWithPaging(int skip, int take, string orderBy);
    }
}
