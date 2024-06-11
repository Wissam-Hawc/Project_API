using System.Linq.Expressions;
using Trendit_ProjectAPI.Models;

namespace Trendit_ProjectAPI.Repository.IRepository
{
    public interface IVillaNumberRepository : IRepository<VillaNumber>
    {
        Task<VillaNumber> UpdateAsync(VillaNumber entity);
    }
}
