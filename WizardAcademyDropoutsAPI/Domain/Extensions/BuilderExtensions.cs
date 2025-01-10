namespace WizardAcademyDropouts.Domain.Extensions;

using Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public static class BuilderExtensions
{
    public static EntityTypeBuilder<T> BuildSelectEntity<T>(
            this ModelBuilder modelBuilder,
            string? tableName = default,
            bool isIndexUnique = true)
            where T : SelectEntity
    {
        var entity = modelBuilder.Entity<T>();
        entity.ToTable(string.IsNullOrEmpty(tableName) ? nameof(T) : tableName);
        entity.HasKey(e => e.Id);
        entity.Property(entity => entity.Name).IsRequired();
        entity.HasIndex(e => e.Name).IsUnique(isIndexUnique);
        entity.HasData(SelectEntity.GetOptions<T>());
        return entity;
    }
}