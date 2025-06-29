using EducationApp.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EducationApp.DataAccess.Database.Persistence.Configuration;

public class GroupSubjectConfiguration : IEntityTypeConfiguration<GroupSubject>
{
    public void Configure(EntityTypeBuilder<GroupSubject> builder)
    {
        builder.HasKey(gs => new { gs.GroupId, gs.SubjectId });

        builder.HasOne(gs => gs.Group)
            .WithMany(g => g.GroupSubjects)
            .HasForeignKey(gs => gs.GroupId);

        builder.HasOne(gs => gs.Subject)
            .WithMany()
            .HasForeignKey(gs => gs.SubjectId);
    }
}
