using System.Threading.Tasks;
using Account.Data.Interfaces;

namespace Pharmacy.Data.Interfaces
{
    public interface IPharmacyRepository : IGenericRepository<Warehouse>
    {
        Task SaveMedicine(Medicine request);
        Task<int> UpdateMedicine(Medicine request);
        Task<int> DeleteMedicine(Medicine request);
        Task<Medicine> GetMedicineById(int id);
        //Task AddNewMedicineToWarehouse(Warehouse request);
        //Task UpdateWarehouse(Warehouse request);
        //Task DeleteMedicine(Warehouse request);
    }
}
