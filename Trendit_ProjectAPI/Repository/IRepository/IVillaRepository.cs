using System.Linq.Expressions;
using Trendit_ProjectAPI.Models;

namespace Trendit_ProjectAPI.Repository.IRepository
{
    public interface IVillaRepository : IRepository<Villa>
    {
        Task<Villa> UpdateAsync(Villa entity);
    }
}
