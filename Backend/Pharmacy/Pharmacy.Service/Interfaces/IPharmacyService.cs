using System.Threading.Tasks;
using Pharmacy.Service.Models.DTO;

namespace Pharmacy.Service.Interfaces
{
    public interface IPharmacyService
    {
        Task AddNewMedicine(MedicineDTO request);
        Task UpdateMedicine(MedicineDTO request);
        Task<MedicineDTO> GetMedicineById(int id);
        Task DeleteMedicine(MedicineDTO request);
        Task AddMedicineToWarehouse(WarehouseDTO request);
        Task<WarehouseDTO> GetMedicineFromWarehouseByMedicineId(int id);
        Task UpdateWarehouse(WarehouseDTO request);
        Task DeleteMedicineFromWarehouse(WarehouseDTO request);
    }
}
