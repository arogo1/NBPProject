using System.Threading.Tasks;
using AutoMapper;
using Pharmacy.Data;
using Pharmacy.Data.Interfaces;
using Pharmacy.Service.Interfaces;
using Pharmacy.Service.Models.DTO;

namespace Pharmacy.Service
{
    public class SaleService : ISaleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SaleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<RecipeDTO> GetRecipeById(int id)
        {
            var result = await _unitOfWork.Sale.GetRecipeById(id);
            return _mapper.Map<RecipeDTO>(result);
        }

        public async Task SaveSale(SaleDTO request)
        {
            await _unitOfWork.Sale.Add(_mapper.Map<Sale>(request));
        }

        public async Task<SaleDTO> GetById(int id)
        {
            var result = await _unitOfWork.Sale.GetByIdAsync(id);
            return _mapper.Map<SaleDTO>(result);
        }
    }
}
