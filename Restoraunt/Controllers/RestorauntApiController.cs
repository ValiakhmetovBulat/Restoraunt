using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Restoraunt.Data.Entities;
using Restoraunt.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restoraunt.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RestorauntApiController : Controller
    {
        private readonly RestorauntDbContext _context;

        public RestorauntApiController(RestorauntDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all the menu positions
        /// </summary>
        /// <returns></returns>        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuPosition>>> Get()
        {
            return await _context.MenuPositions.ToListAsync();
        }

        /// <summary>
        /// Gets positions in the section
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        [HttpGet("{section}")]
        public IEnumerable<MenuPosition> Get(string section)
        {
            var positions = from pos in _context.MenuPositions
                            join posSection in _context.Sections
                            on pos.Section.Id equals posSection.Id
                            where posSection.Name.ToLower() == section.ToLower()
                            select pos;
            
            return positions;
        }

        /// <summary>
        /// Gets positions in the type of the section
        /// </summary>
        /// <param name="section"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpGet("{section}/{type}")]
        public IEnumerable<MenuPosition> Get(string section, string type)
        {
            var positions = from pos in _context.MenuPositions
                            join posSection in _context.Sections
                            on pos.Section.Id equals posSection.Id
                            join posType in _context.PositionTypes
                            on pos.PositionType.Id equals posType.Id
                            where posSection.Name.ToLower() == section.ToLower()
                            where posType.Name.ToLower() == type.ToLower()
                            select pos;

            return positions;
        }

        /// <summary>
        /// Creates new menu position
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<MenuPosition>> Post(MenuPosition position)
        {
            if (position == null)
                return BadRequest();

            _context.MenuPositions.Add(position);
            await _context.SaveChangesAsync();
            return Ok();
        }

        /// <summary>
        /// Updates position
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<MenuPosition>> Put(MenuPosition position)
        {
            if (position == null)
                return BadRequest();
            if (!_context.MenuPositions.Any(x => x.Id == position.Id))
                return NotFound();

            _context.Update(position);
            await _context.SaveChangesAsync();
            return Ok(position);
        }
        

        /// <summary>
        /// Deletes position with passed ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<MenuPosition>> Delete(int id)
        {
            MenuPosition pos = _context.MenuPositions.FirstOrDefault(x => x.Id == id);

            if (pos == null)
            {
                return NotFound();
            }

            _context.MenuPositions.Remove(pos);
            await _context.SaveChangesAsync();
            return Ok(pos);
        }
    }
}
