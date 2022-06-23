using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementModule.Domain.dto;
using UserManagementModule.Domain.model;

namespace UserManagementModule.Service.repository
{
    public interface IUserGroupRepository
    {
        Task<ApiResponse<List<UserGroupDto>>> GetUserGroups();

        Task<ApiResponse<UserGroupDto>> GetUserGroupById(int userGroupId);

        Task<ApiResponse<string>> InsertUserGroup(UserGroupDto userGroupDto);

        Task<ApiResponse<string>> UpdateUserGroup(UserGroupDto userGroupDto);

        Task<ApiResponse<string>> DeleteUserGroup(int userGroupId);

        Task<ApiResponse<string>> AssignAccessRules(int userGroupId, IEnumerable<string> value);
    }
}
