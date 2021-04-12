using Account.Data.Repositories;
using Pharmacy.Data.Interfaces;

namespace Pharmacy.Data.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(PharmacyContext context) : base(context) { }
    }
}
