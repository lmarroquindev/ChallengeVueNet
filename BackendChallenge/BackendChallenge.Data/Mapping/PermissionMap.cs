using BackendChallenge.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendChallenge.Data.Mapping
{
    public class PermissionMap : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            //Table
            builder.ToTable("Permission", "dbo");

            //PK
            builder.HasKey(x => x.Id);

            //Properties
            builder.Property(x => x.FirstName).HasMaxLength(200).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(200).IsRequired();
            builder.Property(x => x.PermissionTypeId).IsRequired();
            builder.Property(x => x.PermissionDate).IsRequired();

            //Relationships
            builder.HasOne(x => x.PermissionType).WithOne().HasForeignKey<Permission>(y => y.PermissionTypeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
