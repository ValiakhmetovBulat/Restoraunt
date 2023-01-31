using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restoraunt.Data.Entities;
using Restoraunt.Models;
using System.Diagnostics;

namespace Restoraunt.Controllers
{

    public class HomeController : Controller
    {
        private readonly RestorauntDbContext _context;

        public HomeController(RestorauntDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //var positions = _context.Sections.Include(m => m.PositionTypes).Select(m => new MenuPositionsViewModel
            //{
            //    SectionName = m.Name,
            //    TypeName = m.PositionTypes,
            //    PositionName = m.PositionTypes.Select(s => s.MenuPositions)
            //});

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}