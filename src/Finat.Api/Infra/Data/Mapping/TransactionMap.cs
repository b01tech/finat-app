using Finat.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finat.Api.Infra.Data.Mapping;

public class TransactionMap : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("Transaction");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Title)
            .IsRequired(true)
            .HasMaxLength(80);
        builder.Property(t => t.Amount)
            .IsRequired(true);
        builder.Property(t => t.Type)
            .IsRequired(true);
        builder.Property(t => t.PaidOrReceivedAt)
            .IsRequired(false);
        builder.Property(t => t.UserId)
            .IsRequired(true);
    }
}
