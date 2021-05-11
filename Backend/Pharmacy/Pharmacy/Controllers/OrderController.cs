using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Service.Interfaces;
using Pharmacy.Service.Models.DTO;
using Pharmacy.Service.Models.Requests;

namespace Pharmacy.Controllers
{
    [ApiController]
    [Route("order")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        private readonly IPharmacyService _pharmacyService;

        public OrderController(IOrderService orderService, IMapper mapper, IPharmacyService pharmacyService)
        {
            _orderService = orderService;
            _mapper = mapper;
            _pharmacyService = pharmacyService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateOrder([FromBody] CreateOrderRequest request)
        {
            try
            {
                if (request == null) return BadRequest("Invalid reqeust");
                if (await _pharmacyService.GetMedicineById(request.MedicineId) == null) return BadRequest("Medicine from request doesn't exist");
                var order = new OrderDTO();
                _mapper.Map(order, request);

                //communication with other microservice
                order.AccountId = 2;

                await _orderService.CreateOrder(order);

                return Ok();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [HttpGet]
        [Route("id")]
        public async Task<ActionResult> GetOrderById(int id)
        {
            try
            {
                if (id < 0) return BadRequest("Invalid id");
                var order = await _orderService.GetById(id);

                if (order == null) return NotFound();

                return Ok(order);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
