using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementModule.Domain.dto;
using UserManagementModule.Domain.model;
using UserManagementModule.Service.repository;

namespace UserManagementModule.WebApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

       
        [HttpPut("{userId}/assign-group")]
        public async Task<IActionResult> AssignUserGroup([FromRoute] int userId, [FromBody] UserGroupDto userGroupDto)
        {

            var userGroups = await _userRepository.AssignUserGroup(userId, userGroupDto.UserGroupId);
            return Ok(userGroups);
        }

        
    }
}
