using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AngularPOC.Common;
using AngularPOC.Entities;
using AngularPOC.Service.UserService;
using AngularPOC.Entities.Dto;

namespace AngularPOC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IHelper _helper;

        public UserController(IUserService service, IHelper helper)
        {
            _service = service;
            _helper = helper;
        }
        
        [AllowAnonymous]
        [HttpPost]
        [Route("[action]")]
        public IActionResult AuthenticateUser(string email, string password)
        {
            try
            {
                var response = _service.AuthenticateUser(email, password);
                if (!response.IsSuccess)
                    return BadRequest("Failed to generate token!");

                var user = response.Data.FirstOrDefault();
                if (user == null)
                    return BadRequest("Failed to generate token!");

                var token = TokenBuilder.CreateJsonWebToken(
                            user.Email,
                            new List<string>() { "Administrator" },
                            _helper.JwtAudience,
                            _helper.JwtIssuer,
                            Guid.NewGuid(),
                            DateTime.UtcNow.AddMinutes(Convert.ToInt32(_helper.JwtExpireTime)));
                
                return Ok(new
                {
                    token,
                    expires = _helper.JwtExpireTime
                });

            }
            catch (Exception ex)
            {
                return BadRequest("Failed to generate token!");
            }
        }

        [Route("[action]")]
        public ApiResponse<UsersWithPaging> GetAllUsers(int skip = 0, int take = int.MaxValue)
        {
            return _service.GetAllUsersWithCitiesWithPaging(skip, take);

        }
    }
}