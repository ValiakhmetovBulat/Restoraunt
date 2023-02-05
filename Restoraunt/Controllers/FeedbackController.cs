using Microsoft.AspNetCore.Mvc;
using Restoraunt.Models.Bases;
using RestorauntApi.Models.Entities;

namespace Restoraunt.Controllers
{
    public class FeedbackController : Controller
    {
        [Route("/feedback")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/feedback/sent")]
        public async Task<ActionResult> Create(Review review)
        {
            review.IsAccepted = false;
            var res = await BaseHttpService<Review>.SendAsync<Review>("review", HttpMethod.Post, review);

            return View();
        }
    }
}
