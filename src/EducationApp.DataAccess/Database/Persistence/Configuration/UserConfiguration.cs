using EducationApp.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EducationApp.DataAccess.Database.Persistence.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Email).HasMaxLength(150);
        builder.Property(u => u.Password).HasMaxLength(200);
        builder.Property(u => u.PhoneNumber).HasMaxLength(20);

        
    }
}
