using EducationApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationApp.DataAccess.Database.Persistence.Configuration;

public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasKey(g => g.Id);

        builder.Property(g => g.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(g => g.Schedule)
            .HasMaxLength(200);

        builder.HasOne(g => g.Room)
            .WithMany()
            .HasForeignKey(g => g.RoomId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(g => g.Staff)
            .WithMany()
            .HasForeignKey(g => g.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(g => g.GroupRooms)
            .WithOne(gr => gr.Group)
            .HasForeignKey(gr => gr.GroupId);

        builder.HasMany(g => g.GroupSubjects)
            .WithOne(gs => gs.Group)
            .HasForeignKey(gs => gs.GroupId);
    }
}
