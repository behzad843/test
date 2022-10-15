using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Review.Model.Models;

namespace Review.Contract
{
    public interface IReviewService
    {
        Task<List<ReviewsResult>> GetByProductId(int productId);
        Task<long> Create(int productId, ReviewCreateRequest request);
        Task<ReviewSummaryResult> GetReviewSummary(int productId);
    }
}
