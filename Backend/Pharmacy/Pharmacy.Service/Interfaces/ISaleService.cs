using System.Threading.Tasks;
using Pharmacy.Service.Models.DTO;

namespace Pharmacy.Service.Interfaces
{
    public interface ISaleService
    {
        Task<RecipeDTO> GetRecipeById(int id);
        Task SaveSale(SaleDTO request);
        Task<SaleDTO> GetById(int id);
    }
}
