using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Trendit_ProjectAPI.Data;
using Trendit_ProjectAPI.Models;
using Trendit_ProjectAPI.Repository.IRepository;

namespace Trendit_ProjectAPI.Repository
{
    public class VillaNumberRepository : Repository<VillaNumber> , IVillaNumberRepository
    {
        private readonly ApplicationDbContext _db;

        public VillaNumberRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<VillaNumber> UpdateAsync(VillaNumber entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.VillaNumbers.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
