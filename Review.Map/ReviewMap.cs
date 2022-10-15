using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Review.Map
{
    public class ReviewMap
    {
        public ReviewMap(EntityTypeBuilder<Review.Model.Entities.Review> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Title).HasMaxLength(50);
            entityBuilder.Property(t => t.Comment).HasMaxLength(250);
        }
    }
}
