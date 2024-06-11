using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Trendit_ProjectAPI.Data;
using Trendit_ProjectAPI.Models;
using Trendit_ProjectAPI.Repository.IRepository;

namespace Trendit_ProjectAPI.Repository
{
    public class VillaRepository : Repository<Villa> , IVillaRepository
    {
        private readonly ApplicationDbContext _db;

        public VillaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Villa> UpdateAsync(Villa entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.Villas.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
