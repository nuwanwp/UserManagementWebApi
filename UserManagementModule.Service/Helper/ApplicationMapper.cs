using AutoMapper;
using UserManagementModule.Domain.dto;
using UserManagementModule.Domain.model;

namespace UserManagementModule.Service.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<UserGroup, UserGroupDto>().ReverseMap();

            CreateMap<SystemUser, SystemUserDto>()
                .ForMember(vm => vm.UserGroupDto, m => m.MapFrom(u => u.UserGroup));
        }
    }
}
