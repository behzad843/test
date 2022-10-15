using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Review.Contract;
using Review.Model;
using Review.Model.Models;
using Review.Repository.GenericRepository;
using Review.Repository.UnitOfWork;

namespace Review.Service
{
    public class ReviewService : IReviewService
    {
        public IUnitOfWork UnitOfWork { get; set; }
        public IGenericRepository<Model.Entities.Review> ReviewRepository { get; set; }
        public ReviewService(IUnitOfWork unitOfWork, IGenericRepository<Model.Entities.Review> reviewRepository)
        {
            UnitOfWork = unitOfWork;
            ReviewRepository = reviewRepository;
        }

        public IQueryable<Model.Entities.Review> GetAll()
        {
            return ReviewRepository.GetQuery().Include(c => c.Product);
        }

        public async Task<List<ReviewsResult>> GetByProductId(int productId)
        {
            var result = await GetAll().Where(c => c.ProductId == productId).ToListAsync();
            return  result.Select(c => c.ToReviewsResult()).ToList();
        }

        public async Task<long> Create(int productId, ReviewCreateRequest request)
        {
            var result = await ReviewRepository.Create(new Model.Entities.Review()
            {
                Comment = request.Comment,
                ProductId = productId,
                Recommended = request.Recommended,
                Score = request.Score,
                Title = request.Title
            });

            await UnitOfWork.SaveChanges();

            return result.Id;
        }

        public async Task<ReviewSummaryResult> GetReviewSummary(int productId)
        {
            var reviews = await ReviewRepository.GetQuery().Where(c => c.ProductId == productId).ToListAsync();
            return new ReviewSummaryResult()
            {
                AverageScore = reviews.Sum(c => c.Score)/reviews.Count(),
                RecommendationPercentage = reviews.Count(c => c.Recommended)*100/reviews.Count()
            };
        }
    }
}
