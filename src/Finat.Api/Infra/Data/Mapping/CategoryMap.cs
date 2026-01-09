using Finat.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finat.Api.Infra.Data.Mapping;

public class CategoryMap: IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Category");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Title)
            .IsRequired(true)
            .HasMaxLength(80);
        builder.Property(c => c.Description)
            .HasMaxLength(200);
        builder.Property(c => c.UserId)
            .IsRequired(true);
    }
}
