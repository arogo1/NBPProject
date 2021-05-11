using System;
using System.Net.Http;
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
    [Route("sale")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;
        private readonly IMapper _mapper;
        private readonly IPharmacyService _pharmacyService;
        private readonly IHttpClientFactory _httpClientFactory;
 
        public SaleController(ISaleService saleService, IMapper mapper, IPharmacyService pharmacyService, IHttpClientFactory httpClientFactory)
        { 
            _saleService = saleService;
            _mapper = mapper;
            _pharmacyService = pharmacyService;
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateOrder([FromBody] CreateSaleRequest request)
        {
            try
            {
                if (request == null) return BadRequest("Invalid reqeust");
                if (request.MedicineId == 0 && request.RecipeId == 0) return BadRequest("Either MedicineId or RecipeId must be provided");

                if(request.RecipeId != 0)
                {
                    var recipe = await _saleService.GetRecipeById(request.RecipeId);
                    if (recipe == null) return BadRequest("Recipe from request doesn't exist");
                    if (request.MedicineId != 0 && recipe.MedicineId != request.MedicineId) return BadRequest("Medicine id doesn't match to recipe medicine id");
                    var _sale = new SaleDTO();
                    _mapper.Map(request, _sale);

                    var _httpClient = _httpClientFactory.CreateClient("Pharmacy");
                    //communication with other microservice
                    var response = await _httpClient.GetAsync("account/getAccountById?id=2");
                    if(response.IsSuccessStatusCode)
                    {
                        var account = response.Content.ReadAsStringAsync();
                    }
                    _sale.AccountId = 2;

                    await _saleService.SaveSale(_sale);

                    return Ok();
                }

                var medicine = await _pharmacyService.GetMedicineById(request.MedicineId);
                if (medicine == null) return BadRequest("Medicine with provided id doesn't exist");
                if (medicine.IsRecipeRequired) return BadRequest("This medicine cannot be order without recipe");

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
        [Route("id")]
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
