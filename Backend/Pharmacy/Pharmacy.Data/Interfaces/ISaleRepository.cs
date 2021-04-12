using System.Threading.Tasks;
using Account.Data.Interfaces;

namespace Pharmacy.Data.Interfaces
{
    public interface ISaleRepository : IGenericRepository<Sale>
    {
        Task<Recipe> GetRecipeById(int id);
    }
}
