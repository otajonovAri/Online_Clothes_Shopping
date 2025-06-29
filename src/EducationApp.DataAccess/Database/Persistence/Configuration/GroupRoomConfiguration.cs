using EducationApp.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EducationApp.DataAccess.Database.Persistence.Configuration;

public class GroupRoomConfiguration : IEntityTypeConfiguration<GroupRoom>
{
    public void Configure(EntityTypeBuilder<GroupRoom> builder)
    {
        builder.HasKey(gr => new { gr.GroupId, gr.RoomId });

        builder.HasOne(gr => gr.Group)
            .WithMany(g => g.GroupRooms)
            .HasForeignKey(gr => gr.GroupId);

        builder.HasOne(gr => gr.Room)
            .WithMany()
            .HasForeignKey(gr => gr.RoomId);
    }
}