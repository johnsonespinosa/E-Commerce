using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(category => category.Id);

        builder.Property(category => category.Name)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.HasMany(navigationExpression: category => category.SubCategories) // CollectionNavigationBuilder<Category, Category>
            .WithOne(navigationExpression: category => category.ParentCategory)
            .HasForeignKey(category => category.ParentId)
            .OnDelete(DeleteBehavior.Restrict);  // Evitar eliminación en cascada
    }
}