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
        private static MenuModel _menuModel;
        public MenuController()
        {          
        }

        [HttpGet]
        [Route("/menu/{section}/{type}")]
        public async Task<ActionResult> Index(string section, string type)
        {
            if (string.IsNullOrEmpty(section) && string.IsNullOrEmpty(type))
            {
                section = "main";
                type = "salads";
            }
            _menuModel.menuPositions = await BaseHttpService<MenuPosition>.SendAsync<MenuPosition>("menu/" + section + "/" + type, HttpMethod.Get);
            _menuModel.sections = await BaseHttpService<Section>.SendAsync<Section>("section", HttpMethod.Get);
            _menuModel.positionTypes = await BaseHttpService<PositionType>.SendAsync<PositionType>("positiontype", HttpMethod.Get);

            return View(_menuModel);
        }        
    }
}
