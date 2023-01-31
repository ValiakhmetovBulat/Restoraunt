using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restoraunt.Data.Entities;
using Restoraunt.Data.EntititesRepositories;
using Restoraunt.Interfaces;
using Restoraunt.Models;

namespace Restoraunt.Controllers
{
    public class MenuController : Controller
    {
        IRepository<MenuPosition> _db;

        public MenuController(RestorauntDbContext context)
        {
            _db = new MenuPositionsRepository(context);
        }

        public ActionResult Index()
        {
            var positions = new List<MenuPosition>();

            return View();
        }

    }
}
