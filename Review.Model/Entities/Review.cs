namespace Review.Model.Entities
{
    public class Review
    {
        public long Id { get; set; }
        public int Score { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public bool Recommended { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
