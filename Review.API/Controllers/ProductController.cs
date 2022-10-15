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

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            return Json(await ProductService.GetAll());
        }

        [HttpGet]
        [Route("{id}/review")]
        public async Task<IActionResult> GetReviews([FromRoute] int id)
        {
            return Json(await ReviewService.GetByProductId(id));
        }

        [HttpGet]
        [Route("{id}/review-summary")]
        public async Task<IActionResult> GetReviewSummary([FromRoute] int id)
        {
            return Json(await ReviewService.GetReviewSummary(id));
        }

        [HttpPost]
        [Route("{id}/review")]
        public async Task<IActionResult> Create([FromRoute] int id, [FromBody] ReviewCreateRequest request)
        {
            return Json(await ReviewService.Create(id, request));
        }
    }
}
