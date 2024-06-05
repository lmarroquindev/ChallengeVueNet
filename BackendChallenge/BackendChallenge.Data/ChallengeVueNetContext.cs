using BackendChallenge.Core.Entities;
using BackendChallenge.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BackendChallenge.Data
{
    /// <summary>
    /// This DbContext is the primary data access point for interacting with the database. 
    /// It includes DbSets for each entity or table, and uses Entity Framework to query and manipulate data. Update this context when entities are added or modified.
    /// </summary>
    public class ChallengeVueNetContext : DbContext
    {
        public ChallengeVueNetContext(DbContextOptions<ChallengeVueNetContext> options)
           : base(options)
        {
        }

        /// <inheritdoc cref="BackendChallenge.Core.Entities.Permission"/>
        public DbSet<Permission> Permission { get; set; }

        /// <inheritdoc cref="BackendChallenge.Core.Entities.PermissionType"/>
        public DbSet<PermissionType> PermissionType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            DataSeederConfiguration.InitializeSeed(modelBuilder);
        }
    }
}
