using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(product => product.Id);
        
        builder.Property(product => product.Name)
            .IsRequired()
            .HasMaxLength(100); 
        
        builder.HasIndex(product => product.Name);

        builder.Property(product => product.SellPrice)
            .IsRequired()
            .HasColumnType("decimal(18,2)"); 

        builder.Property(product => product.PurchasePrice)
            .IsRequired()
            .HasColumnType("decimal(18,2)"); 

        builder.Property(product => product.Stock)
            .IsRequired();
        
        builder.HasOne(navigationExpression: product => product.Category) // ReferenceNavigationBuilder<Product, Category> 
            .WithMany(navigationExpression: category => category.Products)
            .HasForeignKey(product => product.CategoryId);
    }
}