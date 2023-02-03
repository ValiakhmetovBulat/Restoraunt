using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restoraunt.Models;
using Restoraunt.Models.Bases;
using RestorauntApi.Models.Entities;
using System.Net;
using System.Runtime.CompilerServices;

namespace Restoraunt.Controllers
{
    public class MenuController : Controller
    {
        public MenuController()
        {          
        }

        [HttpGet]
        [Route("/menu/{section}/{type}")]
        public async Task<ActionResult> Index(string section, string type)
        {
            List<MenuPosition> positions = new List<MenuPosition>();
            if (string.IsNullOrEmpty(section) && string.IsNullOrEmpty(type))
            {
                section = "main";
                type = "salads";                
            }

            positions = await BaseHttpService<MenuPosition>.SendAsync<MenuPosition>("menu/" + section, HttpMethod.Get);
            var sections = await BaseHttpService<Section>.SendAsync<Section>("section", HttpMethod.Get);
            var positionTypes = await BaseHttpService<PositionType>.SendAsync<PositionType>("PositionType", HttpMethod.Get);

            MenuModel mm = new MenuModel(positions, sections, positionTypes);

            positions = await BaseHttpService<MenuPosition>.SendAsync<MenuPosition>("menu/" + section + "/" + type, HttpMethod.Get);
            mm.menuPositions = positions;

            return View(mm);
        }
    }
}
