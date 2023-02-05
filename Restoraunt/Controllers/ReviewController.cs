using Microsoft.AspNetCore.Mvc;
using Restoraunt.Models.Bases;
using RestorauntApi.Models.Entities;
using static System.Collections.Specialized.BitVector32;

namespace Restoraunt.Controllers
{
    public class ReviewController : Controller
    {
        [HttpGet]
        [Route("/reviews")]
        public async Task<ActionResult> Index()
        {
            List<Review> reviews = await BaseHttpService<Review>.SendAsync<Review>("review", HttpMethod.Get);
            return View(reviews);
        }
    }
}
