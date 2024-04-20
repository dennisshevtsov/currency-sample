// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoneyType.Sample;

public sealed class MoneyTypeSampleDbContext : DbContext
{
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=money-type-sample-db;Username=dev;Password=dev");
    optionsBuilder.LogTo(Console.WriteLine);
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    EntityTypeBuilder<ProductEntity> entityTypeBuilder = modelBuilder.Entity<ProductEntity>();

    entityTypeBuilder.HasKey(entity => entity.ProductId);
    entityTypeBuilder.ToTable("product");

    entityTypeBuilder.Property(entity => entity.ProductId).IsRequired().HasColumnName("product_id");
    entityTypeBuilder.Property(entity => entity.Name     ).IsRequired().HasColumnName("name"      );

    entityTypeBuilder.Property(entity => entity.Price)
                     .IsRequired()
                     .HasColumnName("price")
                     .HasConversion(price => price.ToString(), price => Money.Parce(price));
  }
}
