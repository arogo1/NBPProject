using System.Threading.Tasks;
using Account.Data.Repositories;
using Pharmacy.Data.Interfaces;

namespace Pharmacy.Data.Repositories
{
    public class PharmacyRepository : GenericRepository<Warehouse>, IPharmacyRepository
    {
        public PharmacyRepository(PharmacyContext context) : base(context) { }

        public async Task SaveMedicine(Medicine request)
        {
            await _context.Set<Medicine>().AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateMedicine(Medicine request)
        {
            _context.Set<Medicine>().Update(request);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteMedicine(Medicine request)
        {
            _context.Set<Medicine>().Remove(request);
            return await _context.SaveChangesAsync();
        }

        public async Task<Medicine> GetMedicineById(int id)
        {
            return await _context.Set<Medicine>().FindAsync(id);
        }

        //public async Task AddNewMedicineToWarehouse(Warehouse request)
        //{
        //    await _context.Warehouses.AddAsync(request);
        //}

        //public async Task UpdateWarehouse(Warehouse request)
        //{
        //    _context.Warehouses.Update(request);
        //}

        //public async Task DeleteMedicine(Warehouse request)
        //{
        //    _context.Warehouses.Remove(request);
        //}
    }
}
