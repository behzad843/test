using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Review.Contract;
using Review.Model.Entities;
using Review.Model.Models;

namespace Review.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        public IProductService ProductService { get; set; }
        public IReviewService ReviewService { get; set; }
        public ProductController(IProductService productService, IReviewService reviewService)
        {
            ProductService = productService;
            ReviewService = reviewService;
        }

        /// <summary>
        /// Get Products from cache
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     GET api/product
        /// </remarks>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            return Json(await ProductService.GetAll());
        }

        /// <summary>
        /// Get Reviews by productId
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     GET api/product/{id}/review
        /// </remarks>
        /// <param name="id"></param> 
        [HttpGet]
        [Route("{id}/review")]
        public async Task<IActionResult> GetReviews([FromRoute] int id)
        {
            return Json(await ReviewService.GetByProductId(id));
        }

        /// <summary>
        /// Get Review summary by productId
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     GET api/product/{id}/review-summary
        /// </remarks>
        /// <param name="id"></param> 
        [HttpGet]
        [Route("{id}/review-summary")]
        public async Task<IActionResult> GetReviewSummary([FromRoute] int id)
        {
            return Json(await ReviewService.GetReviewSummary(id));
        }

        /// <summary>
        /// create Review per productId
        /// </summary>
        /// <example>
        ///   api/product/1/review
        ///   POST 
        ///   {
        ///     "score" = 4, //1 to 5
        ///     "title" = "for test",
        ///     "comment" = "for test",
        ///     "recommended" = true,
        ///   }
        /// <example>
        /// <param name="id"></param> 
        [HttpPost]
        [Route("{id}/review")]
        public async Task<IActionResult> Create([FromRoute] int id, [FromBody] ReviewCreateRequest request)
        {
            return Json(await ReviewService.Create(id, request));
        }
    }
}
