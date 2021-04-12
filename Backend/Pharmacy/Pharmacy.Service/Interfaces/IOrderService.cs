using System.Threading.Tasks;
using Pharmacy.Service.Models.DTO;

namespace Pharmacy.Service.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrder(OrderDTO request);
        Task<OrderDTO> GetById(int id);
    }
}
