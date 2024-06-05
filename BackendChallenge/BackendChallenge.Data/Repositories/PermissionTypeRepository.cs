using BackendChallenge.Core.Entities;
using BackendChallenge.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BackendChallenge.Data.Repositories
{
    /// <summary>
    /// A concrete implementation of the IPermissionTypeRepository interface that provides
    /// specialized methods for interacting with the database for the <see cref="PermissionType"/> entity.
    /// This includes retrieving a list of permissions from the database.
    /// </summary>
    public class PermissionTypeRepository : BaseRepository<int, PermissionType>, IPermissionTypeRepository
    {
        public PermissionTypeRepository(ChallengeVueNetContext context) : base(context)
        {

        }

        public async Task<List<PermissionType>> GetListAsync(bool? tracking = true)
        {
            try
            {
                IQueryable<PermissionType> query = _dbContext.PermissionType;

                if (tracking == false)
                    query.AsNoTracking();

                List<PermissionType> entity = await query.ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override async Task<PermissionType> GetByIdAsync(int id, bool? tracking)
        {
            try
            {
                IQueryable<PermissionType> query = _dbContext.PermissionType;

                if (tracking == false)
                    query.AsNoTracking();

                PermissionType entity = await query.FirstOrDefaultAsync(x => x.Id == id);
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
