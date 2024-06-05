using AutoMapper;
using BackendChallenge.Core.Dtos.Input;
using BackendChallenge.Core.Dtos.Output;
using BackendChallenge.Core.Entities;
using BackendChallenge.Core.Interfaces.Repositories;
using BackendChallenge.Core.Interfaces.Services;
using BackendChallenge.Data.Repositories;

namespace BackendChallenge.Services
{
    /// <summary>
    /// Provides an implementation of the IPermissionService interface, defining service methods
    /// for managing <see cref="Permission"/> entities within the database. This includes creating,
    /// updating, and deleting permissions, as well as retrieving permission records.
    /// </summary>
    public class PermissionService : IPermissionService
    {
        private readonly IMapper _mapper;
        private readonly IPermissionRepository _permissionRepository;
        public PermissionService(IMapper mapper,
                                 IPermissionRepository permissionRepository)
        {
            _mapper = mapper;
            _permissionRepository = permissionRepository;
        }
        public async Task<PermissionOutputDto> GetByIdAsync(int id)
        {
            Permission entity = await _permissionRepository.GetByIdAsync(id, tracking: false);
            PermissionOutputDto result = _mapper.Map<PermissionOutputDto>(entity);
            return result;
        }

        public async Task<List<PermissionOutputDto>> GetListAsync()
        {
            List<Permission> entity = await _permissionRepository.GetListAsync(tracking: false);
            List<PermissionOutputDto> result = _mapper.Map<List<PermissionOutputDto>>(entity);
            return result;
        }
        public async Task<PermissionOutputDto> CreateAsync(PermissionCreateInputDto input)
        {
            try
            {
                Permission entity = _mapper.Map<Permission>(input);
                await _permissionRepository.AddAsync(entity);
                await _permissionRepository.SaveChangesAsync();

                PermissionOutputDto result = await GetByIdAsync(entity.Id);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<PermissionOutputDto> UpdateAsync(PermissionUpdateInputDto input)
        {
            try
            {
                Permission entity = await _permissionRepository.GetByIdAsync(input.Id);
                entity = _mapper.Map<PermissionUpdateInputDto,Permission>(input,entity);
                await _permissionRepository.SaveChangesAsync();
                PermissionOutputDto result = _mapper.Map<PermissionOutputDto>(entity);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task DeleteAsync(int id)
        {
            try
            {
                Permission entity = await _permissionRepository.GetByIdAsync(id);
                await _permissionRepository.RemoveAsync(entity);
                await _permissionRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
