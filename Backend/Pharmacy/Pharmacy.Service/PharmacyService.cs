using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Pharmacy.Data;
using Pharmacy.Data.Interfaces;
using Pharmacy.Service.Interfaces;
using Pharmacy.Service.Models.DTO;

namespace Pharmacy.Service
{
    public class PharmacyService : IPharmacyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PharmacyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddNewMedicine(MedicineDTO request)
        {
            await _unitOfWork.Pharmacy.SaveMedicine(_mapper.Map<Medicine>(request));
        }

        public async Task UpdateMedicine(MedicineDTO request)
        {
            await _unitOfWork.Pharmacy.UpdateMedicine(_mapper.Map<Medicine>(request));
        }

        public async Task<MedicineDTO> GetMedicineById(int id)
        {
            var result = await _unitOfWork.Pharmacy.GetMedicineById(id);
            return _mapper.Map<MedicineDTO>(result);
        }

        public async Task DeleteMedicine(MedicineDTO request)
        {
            await _unitOfWork.Pharmacy.DeleteMedicine(_mapper.Map<Medicine>(request));
        }

        public async Task AddMedicineToWarehouse(WarehouseDTO request)
        {
            await _unitOfWork.Pharmacy.Add(_mapper.Map<Warehouse>(request));
        }

        public async Task<WarehouseDTO> GetMedicineFromWarehouseByMedicineId(int id)
        {
            var result = await _unitOfWork.Pharmacy.GetWhere(x => x.MedicineId.Equals(id));
            return _mapper.Map<WarehouseDTO>(result.First());
        }

        public async Task UpdateWarehouse(WarehouseDTO request)
        {
            await _unitOfWork.Pharmacy.Update(_mapper.Map<Warehouse>(request));
        }

        public async Task DeleteMedicineFromWarehouse(WarehouseDTO request)
        {
            await _unitOfWork.Pharmacy.Remove(_mapper.Map<Warehouse>(request));
        }
    }
}
