using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementModule.Data;
using UserManagementModule.Domain.dto;
using UserManagementModule.Domain.model;

namespace UserManagementModule.Service.repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManagementDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(UserManagementDbContext context, IMapper mapper)
        {
            this._mapper = mapper;
            this._context = context;
        }

        /**
         * This method assign the given group to the pertucular user
         */
        public async Task<ApiResponse<string>> AssignUserGroup(int userId, int userGroupId)
        {
            // get user by id
            var systemUser = await _context.SystemUser.FindAsync(userId);

            var userGroup = await _context.UserGroup.FindAsync(userGroupId);

            if (systemUser != null && userGroup != null)
            {
                systemUser.UserGroup = userGroup;

                _context.SystemUser.Update(systemUser);
                var result = await _context.SaveChangesAsync("nuwanw");
                return new ApiResponse<string>(Status.SUCCESS, result > 0 ? "User group assigned successfully" : "Error(s) in assignment");
            }
            return new ApiResponse<string>(Status.ERROR, "Error(s) in assignment");
        }

       /**
       * Retreive the details of System user with related group details (Eager loading)
       */
        public async Task<ApiResponse<SystemUserDto>> GetSystemUserDetailsById(int systemUserId)
        {
            // eager loading of system user with related user group details
            var systemUser = await _context.SystemUser.Include(q => q.UserGroup).FirstOrDefaultAsync(q=> q.Id == systemUserId);
            if (systemUser != null)
            {
                var result = _mapper.Map<SystemUserDto>(systemUser);
                return new ApiResponse<SystemUserDto>(Status.SUCCESS, result);
            }
            return new ApiResponse<SystemUserDto>(Status.ERROR, null);
        }
    }
}
