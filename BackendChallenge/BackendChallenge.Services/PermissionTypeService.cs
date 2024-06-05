using AutoMapper;
using BackendChallenge.Core.Dtos.Output;
using BackendChallenge.Core.Entities;
using BackendChallenge.Core.Interfaces.Repositories;
using BackendChallenge.Core.Interfaces.Services;

namespace BackendChallenge.Services
{
    /// <summary>
    /// A concrete implementation of the IPermissionTypeService interface that provides
    /// methods for retrieving permission type data from the database, including fetching
    /// individual permission types by ID and retrieving a list of all permission types.
    /// </summary>
    public class PermissionTypeService : IPermissionTypeService
    {
        private readonly IMapper _mapper;
        private readonly IPermissionTypeRepository _permissionTypeRepository;
        public PermissionTypeService(IMapper mapper,
                                     IPermissionTypeRepository permissionTypeRepository)
        {
            _mapper = mapper;
            _permissionTypeRepository = permissionTypeRepository;
        }
        public async Task<PermissionTypeOutputDto> GetByIdAsync(int id)
        {
            PermissionType entity = await _permissionTypeRepository.GetByIdAsync(id, tracking:false);
            PermissionTypeOutputDto result = _mapper.Map<PermissionTypeOutputDto>(entity);
            return result;
        }

        public async Task<List<PermissionTypeOutputDto>> GetListAsync()
        {
            List<PermissionType> entity = await _permissionTypeRepository.GetListAsync(tracking: false);
            List<PermissionTypeOutputDto> result = _mapper.Map<List<PermissionTypeOutputDto>>(entity);
            return result;
        }
    }
}
