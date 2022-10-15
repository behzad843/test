using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review.Model.Models
{
    public class ReviewsResult
    {
        public int Score { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public bool Recommended { get; set; }
        public string ProductName { get; set; }
    }
}
