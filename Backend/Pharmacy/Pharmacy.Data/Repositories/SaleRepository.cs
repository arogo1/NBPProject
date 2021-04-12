using System.Threading.Tasks;
using Account.Data.Repositories;
using Pharmacy.Data.Interfaces;

namespace Pharmacy.Data.Repositories
{
    public class SaleRepository : GenericRepository<Sale>, ISaleRepository
    {
        public SaleRepository(PharmacyContext context) : base(context) { }

        public async Task<Recipe> GetRecipeById(int id)
        {
            return await _context.Set<Recipe>().FindAsync(id);
        }
    }
}
