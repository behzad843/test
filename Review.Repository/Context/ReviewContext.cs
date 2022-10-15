using Microsoft.EntityFrameworkCore;
using Review.Model.Entities;

namespace Review.Repository.Context
{
    public class ReviewContext : DbContext
    {

        public ReviewContext(DbContextOptions<ReviewContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Model.Entities.Review> Reviews { get; set; }
    }
}
