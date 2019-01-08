using System;
using System.Linq;
using AngularPOC.Common;
using AngularPOC.Data.Repositories;
using AngularPOC.Data.Repositories.User;
using AngularPOC.Entities;
using AngularPOC.Service.EntityService;

namespace AngularPOC.Service.UserService
{
    public class UserService : EntityService<UserMaster>, IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public ApiResponse<UserMaster> AuthenticateUser(string email, string password)
        {
            var response = new ApiResponse<UserMaster>();

            try
            {
                var user = _repository.AuthenticateUser(email, password);
                if (user != null)
                {

                    response.IsSuccess = true;
                    response.Data.Add(user);
                }
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.Message);
            }

            return response;

        }

        public ApiResponse<UserMaster> GetAllUsers()
        {
            var response = new ApiResponse<UserMaster>();

            try
            {
                response.Data = _repository.Table.ToList();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.Message);
            }

            return response;
        }

        public ApiResponse<UserMaster> GetAllUsersWithCities()
        {
            var response = new ApiResponse<UserMaster>();

            try
            {
                response.Data = _repository.GetAllUsersWithCities().Take(1000).ToList();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.Messages.Add(ex.Message);
            }

            return response;
        }

    }
}
