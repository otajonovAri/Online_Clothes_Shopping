using EducationApp.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EducationApp.DataAccess.Database.Persistence.Configuration;

public class StaffConfiguration : IEntityTypeConfiguration<Staff>
{
    public void Configure(EntityTypeBuilder<Staff> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.FullName).HasMaxLength(100);
        builder.Property(s => s.Position).HasMaxLength(100);

        builder.HasOne(s => s.User)
            .WithMany(u => u.Staffs)
            .HasForeignKey(s => s.UserId);
    }
}

