using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Review.Model.Entities;

namespace Review.Map
{
    public class ProductMap
    {
        public ProductMap(EntityTypeBuilder<Product> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Name).HasMaxLength(25).IsRequired();
            entityBuilder.Property(t => t.Description).HasMaxLength(250);
        }
    }
}
