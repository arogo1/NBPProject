using System.Threading.Tasks;
using AutoMapper;
using Pharmacy.Data;
using Pharmacy.Data.Interfaces;
using Pharmacy.Service.Interfaces;
using Pharmacy.Service.Models.DTO;

namespace Pharmacy.Service
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateOrder(OrderDTO request)
        {
            await _unitOfWork.Order.Add(_mapper.Map<Order>(request));
        }

        public async Task<OrderDTO> GetById(int id)
        {
            var result = await _unitOfWork.Order.GetByIdAsync(id);
            return _mapper.Map<OrderDTO>(result);
        }
    }
}
