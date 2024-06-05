using AutoMapper;
using BackendChallenge.Core.Dtos.Input;
using BackendChallenge.Core.Dtos.Output;
using BackendChallenge.Core.Entities;

namespace BackendChallenge.Core.Automapper
{
    public class PermissionProfile : Profile
    {
        public PermissionProfile()
        {
            CreateMap<Permission, PermissionOutputDto>();
            CreateMap<PermissionCreateInputDto, Permission>();
            CreateMap<PermissionUpdateInputDto, Permission>();
        }
    }
}
