using Pharmacy.Data.Interfaces;
using Pharmacy.Data.Repositories;

namespace Pharmacy.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PharmacyContext _context;
        public UnitOfWork(PharmacyContext context)
        {
            _context = context;
            Pharmacy = new PharmacyRepository(_context);
            Order = new OrderRepository(_context);
            Sale = new SaleRepository(_context);
        }
        public IPharmacyRepository Pharmacy { get; private set; }
        public IOrderRepository Order { get; private set; }
        public ISaleRepository Sale { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
