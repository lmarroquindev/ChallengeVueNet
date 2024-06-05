using AutoMapper;
using BackendChallenge.Core.Dtos.Output;
using BackendChallenge.Core.Entities;

namespace BackendChallenge.Core.Automapper
{
    public class PermissionTypeProfile : Profile
    {
        public PermissionTypeProfile()
        {
            CreateMap<PermissionType, PermissionTypeOutputDto>();
        }
    }
}
