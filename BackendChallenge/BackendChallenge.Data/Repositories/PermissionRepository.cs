using BackendChallenge.Core.Entities;
using BackendChallenge.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BackendChallenge.Data.Repositories
{
    /// <summary>
    /// A concrete implementation of the IPermissionRepository interface that provides
    /// specialized methods for interacting with the database for the <see cref="Permission"/> entity.
    /// This includes retrieving a list of permissions from the database.
    /// </summary>
    public class PermissionRepository : BaseRepository<int, Permission>, IPermissionRepository
    {
        public PermissionRepository(ChallengeVueNetContext context) : base(context)
        {

        }

        public async Task<List<Permission>> GetListAsync(bool? tracking = true)
        {
            try
            {
                IQueryable<Permission> query = _dbContext.Permission;

                if (tracking == false)
                    query.AsNoTracking();

                List<Permission> entity = await query.Include(x => x.PermissionType)
                                                     .ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override async Task<Permission> GetByIdAsync(int id, bool? tracking)
        {
            try
            {
                IQueryable<Permission> query = _dbContext.Permission;

                if (tracking == false)
                    query.AsNoTracking();

                Permission entity = await query.Include(x => x.PermissionType)
                                               .FirstOrDefaultAsync(x => x.Id == id);
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
