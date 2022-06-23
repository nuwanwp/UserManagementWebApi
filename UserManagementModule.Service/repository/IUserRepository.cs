using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementModule.Domain.dto;
using UserManagementModule.Domain.model;

namespace UserManagementModule.Service.repository
{
    public interface IUserRepository
    {
        Task<ApiResponse<SystemUserDto>> GetSystemUserDetailsById(int systemUserId);

        Task<ApiResponse<string>> AssignUserGroup(int userId, int userGroupId);

        //TODO: other CRUD operations required to manage Users enity need to implemented       
    }
}
