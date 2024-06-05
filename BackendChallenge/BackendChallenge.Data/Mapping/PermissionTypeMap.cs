using BackendChallenge.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendChallenge.Data.Mapping
{
    public class PermissionTypeMap : IEntityTypeConfiguration<PermissionType>
    {
        public void Configure(EntityTypeBuilder<PermissionType> builder)
        {
            //Table
            builder.ToTable("PermissionType", "dbo");

            //PK
            builder.HasKey(x => x.Id);

            //Properties
            builder.Property(x => x.Description).HasMaxLength(300).IsRequired();
        }
    }
}
