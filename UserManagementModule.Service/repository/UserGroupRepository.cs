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
    public class UserGroupRepository : IUserGroupRepository
    {
        private readonly UserManagementDbContext _context;
        private readonly IMapper _mapper;

        public UserGroupRepository(UserManagementDbContext context, IMapper mapper)
        {
            this._mapper = mapper;
            this._context = context;
        }        

        public async Task<ApiResponse<string>> DeleteUserGroup(int userGroupId)
        {
            var userGroup = await _context.UserGroup.FindAsync(userGroupId);
            if (userGroup != null)
            {
                _context.UserGroup.Remove(userGroup);
                var result = await _context.SaveChangesAsync("nuwanw");
                return new ApiResponse<string>(Status.SUCCESS, result > 0 ? "Deleted successfully" : "Error(s) in deleting");
            }
            return new ApiResponse<string>(Status.ERROR, null);
        }

        public async Task<ApiResponse<UserGroupDto>> GetUserGroupById(int userGroupId)
        {
            var userGroup = await _context.UserGroup.FindAsync(userGroupId);
            if (userGroup != null)
            {
                var result = _mapper.Map<UserGroupDto>(userGroup);
                return new ApiResponse<UserGroupDto>(Status.SUCCESS, result);
            }
            return new ApiResponse<UserGroupDto>(Status.ERROR, null);
        }

        public async Task<ApiResponse<List<UserGroupDto>>> GetUserGroups()
        {
            var userGroups = await _context.UserGroup.ToListAsync();
            var result = _mapper.Map<List<UserGroupDto>>(userGroups);
            return new ApiResponse<List<UserGroupDto>>(Status.SUCCESS, result);
        }


        public async Task<ApiResponse<string>> InsertUserGroup(UserGroupDto userGroupDto)
        {
            var userGroups = _mapper.Map<UserGroup>(userGroupDto);

            _context.UserGroup.Add(userGroups);
            var result = await _context.SaveChangesAsync("nuwanw");
            if(result > 0)
            {
                return new ApiResponse<string>(Status.SUCCESS, "Created successfully");
            }
            else
            {
                return new ApiResponse<string>(Status.ERROR, "Error(s) in creating");
            }           

        }

        public async Task<ApiResponse<string>> UpdateUserGroup(UserGroupDto userGroupDto)
        {
            var userGroup = await _context.UserGroup.FindAsync(userGroupDto.UserGroupId);
            if(userGroup != null)
            {
                userGroup.GroupName = userGroupDto.GroupName;

                _context.UserGroup.Update(userGroup);
                var result = await _context.SaveChangesAsync("nuwanw");
                if (result > 0)
                {
                    return new ApiResponse<string>(Status.SUCCESS, "Updated successfully");
                }
                else
                {
                    return new ApiResponse<string>(Status.ERROR, "Error(s) in updating");
                }
            }

            return new ApiResponse<string>(Status.SUCCESS, "Error(s) in updating");

        }

        public async Task<ApiResponse<string>> AssignAccessRules(int userGroupId, IEnumerable<string> value)
        {
            var userGroup = await _context.UserGroup.FindAsync(userGroupId);
            if (userGroup != null)
            {
                foreach (var ruleId in value)
                {
                    var accessRule = await _context.AccessRule.FindAsync(int.Parse(ruleId));

                    userGroup.UserGroupRuleAssignments = new List<UserGroupRuleAssignment>
                    {
                      new UserGroupRuleAssignment {
                        UserGroup = userGroup,
                        AccessRule = accessRule
                      }
                    };

                }

                _context.UserGroup.Update(userGroup);
                var result = await _context.SaveChangesAsync();
                return new ApiResponse<string>(Status.SUCCESS, "Access rules assigned successfully");
            }
            return new ApiResponse<string>(Status.ERROR, "Error(s) in assigning");
        }
    
    }
}
