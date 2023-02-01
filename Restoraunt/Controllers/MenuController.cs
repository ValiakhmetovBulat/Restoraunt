using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restoraunt.Models;

namespace Restoraunt.Controllers
{
    public class MenuController : Controller
    {

        public MenuController()
        {
            
        }

        public ActionResult Index()
        {

            return View();
        }

    }
}
