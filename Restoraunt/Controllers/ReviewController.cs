using Microsoft.AspNetCore.Mvc;
using Restoraunt.Models.Bases;
using Restoraunt.Models.Entities;
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
            reviews = reviews.Where(x => x.IsAccepted == true).ToList();
            return View(reviews);
        }
    }
}
