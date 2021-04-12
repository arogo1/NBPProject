using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Service.Interfaces;
using Pharmacy.Service.Models.DTO;
using Pharmacy.Service.Models.Requests;

namespace Pharmacy.Controllers
{
    [ApiController]
    [Route("sale")]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;
        private readonly IMapper _mapper;
        private readonly IPharmacyService _pharmacyService;

        public SaleController(ISaleService saleService, IMapper mapper, IPharmacyService pharmacyService)
        {
            _saleService = saleService;
            _mapper = mapper;
            _pharmacyService = pharmacyService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder([FromBody] CreateSaleRequest request)
        {
            try
            {
                if (request == null) return BadRequest("Invalid reqeust");
                if (await _saleService.GetRecipeById(request.RecipeId) == null) return BadRequest("Recipe from request doesn't exist");
                var sale = new SaleDTO();
                _mapper.Map(request, sale);

                //communication with other microservice
                sale.AccountId = 2;

                await _saleService.SaveSale(sale);

                return Ok();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet]
        [Route("/id")]
        public async Task<ActionResult> GetSaleById(int id)
        {
            try
            {
                if (id < 0) return BadRequest("Invalid id");
                var sale = await _saleService.GetById(id);

                if (sale == null) return NotFound();

                return Ok(sale);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
