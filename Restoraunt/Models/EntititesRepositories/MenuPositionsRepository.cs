using Restoraunt.Data.Entities;
using Restoraunt.Interfaces;
using Restoraunt.Models;

namespace Restoraunt.Data.EntititesRepositories
{
    public class MenuPositionsRepository : IRepository<MenuPosition>
    {
        private RestorauntDbContext _context;
        public MenuPositionsRepository(RestorauntDbContext context)
        {
            this._context = context;
        }
        public void Create(MenuPosition item)
        {
            _context.MenuPositions.Add(item);
        }

        public void Delete(int id)
        {
            _context.MenuPositions.Remove(Get(id));
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public MenuPosition Get(int id)
        {
            return _context.MenuPositions.Find(id);
        }

        public IEnumerable<MenuPosition> GetAll()
        {
            return _context.MenuPositions.ToList();            
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(MenuPosition item)
        {
            _context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
