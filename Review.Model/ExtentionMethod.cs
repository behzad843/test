using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Review.Model.Models;

namespace Review.Model
{
    public static class ExtentionMethod
    {
        public static ReviewsResult ToReviewsResult(this Model.Entities.Review entity)
        {
            return new ReviewsResult
            {
                Comment = entity.Comment,
                Recommended = entity.Recommended,
                Score = entity.Score,
                Title = entity.Title,
                ProductName = entity.Product.Name
            };
        }
    }
}
