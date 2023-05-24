using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes.Application.Entities.Task.Domain;

namespace Notes.Persistence.EntityTypeConfigurations;

/// <summary>
/// Class TaskConfiguration.
/// Implements the <see cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Notes.Application.Entities.Task.Domain.Task}" />
/// </summary>
/// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Notes.Application.Entities.Task.Domain.Task}" />
public class TaskConfiguration : IEntityTypeConfiguration<CatalogTask>
{
    /// <summary>
    /// Configures the entity of type <typeparamref name="TEntity" />.
    /// </summary>
    /// <param name="builder">The builder to be used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<CatalogTask> builder)
    {
        builder.HasKey(note => note.Id);
        builder.HasIndex(note => note.Id).IsUnique();
        builder.Property(note => note.Name).HasMaxLength(500);

        builder
            .HasOne(x => x.TaskAuthor)
            .WithMany(x => x.AssignedTasks)
            .HasForeignKey(x => x.TaskAuthorId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.TaskExecutor)
            .WithMany(x => x.ExecutableTasks)
            .HasForeignKey(x => x.TaskExecutorId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
    }
}