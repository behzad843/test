using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Review.Contract;
using Review.Model.Models;

namespace Review.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : Controller
    {
        public IReviewService ReviewService { get; set; }
        public ReviewController(IReviewService reviewService)
        {
            ReviewService = reviewService;
        }
    }
}