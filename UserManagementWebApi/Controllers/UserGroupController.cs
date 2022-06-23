using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementModule.Domain.dto;
using UserManagementModule.Domain.model;
using UserManagementModule.Service.repository;

namespace UserManagementModule.WebApi.Controllers
{
    [Route("api/groups")]
    [ApiController]
    public class UserGroupController : ControllerBase
    {
        private readonly IUserGroupRepository _userGroupRepository;

        public UserGroupController(IUserGroupRepository userGroupRepository)
        {
            this._userGroupRepository = userGroupRepository;
        }

        [HttpGet]
        public async Task<IActionResult> SearchUserGroups()
        {
            var userGroups = await _userGroupRepository.GetUserGroups();
            return Ok(userGroups);
        }

        [HttpGet("{userGroupId}")]
        public async Task<IActionResult> GetUserGroupById([FromRoute] int userGroupId)
        {
            var userGroups = await _userGroupRepository.GetUserGroupById(userGroupId);
            return Ok(userGroups);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserGroup([FromBody] UserGroupDto userGroupDto)
        {
            var result = await _userGroupRepository.UpdateUserGroup(userGroupDto);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> InsertUserGroup([FromBody] UserGroupDto userGroupDto)
        {
            var result = await _userGroupRepository.InsertUserGroup(userGroupDto);
            return Ok(result);
        }

        [HttpDelete("{userGroupId}")]
        public async Task<IActionResult> DeleteUserGroup([FromRoute] int userGroupId)
        {
            var result = await _userGroupRepository.DeleteUserGroup(userGroupId);
            return Ok(result);
        }


        [HttpPut("{userGroupId}/assign-rules")]
        public async Task<IActionResult> AssignUserGroup([FromRoute] int userGroupId, [FromBody] IEnumerable<string> value)
        {

            var userGroups = await _userGroupRepository.AssignAccessRules(userGroupId, value);
            return Ok(userGroups);
        }

    }
}
