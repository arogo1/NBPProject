using System;
namespace Pharmacy.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPharmacyRepository Pharmacy { get; }
        IOrderRepository Order { get; }
        ISaleRepository Sale { get; }
        int Complete();
    }
}
