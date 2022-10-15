using System.Collections.Generic;

namespace Review.Model.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public List<Review> Reviews {get; set;}
    }
}
