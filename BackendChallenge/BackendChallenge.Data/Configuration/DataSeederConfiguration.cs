using BackendChallenge.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendChallenge.Data.Configuration
{
    /// <summary>
    /// Class that contains all the SEED configuration (initial data insertion) for the database tables.
    /// </summary>
    public class DataSeederConfiguration
    {
        /// <summary>
        /// Initializes the data insertion for all entities that require default data.
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void InitializeSeed(ModelBuilder modelBuilder)
        {
            SeedPermissionType(modelBuilder);
        }

        /// <summary>
        /// Populates the <see cref="PermissionType"/> table in the database with the default data.
        /// </summary>
        /// <param name="modelBuilder"></param>
        private static void SeedPermissionType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PermissionType>().HasData(
               new PermissionType { Id = 1, Description = "Enfermedad" },
               new PermissionType { Id = 2, Description = "Diligencias" },
               new PermissionType { Id = 3, Description = "Otros" }
            );
        }
    }
}
