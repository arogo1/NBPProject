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
    [Route("pharmacy")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin, Worker")]
    public class PharmacyController : ControllerBase
    {
        private readonly IPharmacyService _pharmacyService;
        private readonly IMapper _mapper;

        public PharmacyController(IPharmacyService pharmacyService, IMapper mapper)
        {
            _pharmacyService = pharmacyService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("create/medcine")]
        public async Task<ActionResult> CreateNewMedcine([FromBody] CreateMedicineRequest request)
        {
            try
            {
                if (request == null) return BadRequest("Invalid request");
                await _pharmacyService.AddNewMedicine(_mapper.Map<MedicineDTO>(request));

                return Ok(request);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [HttpPut]
        [Route("update/medcine")]
        public async Task<ActionResult> UpdateMedcine(int id, [FromBody] UpdateMedicineRequest request)
        {
            try
            {
                if (id < 0) return BadRequest("Invalid id");
                if (request == null) return BadRequest("Invalid request");

                var medicine = await _pharmacyService.GetMedicineById(id);
                if (medicine == null) return NotFound();

                _mapper.Map(request, medicine);

                await _pharmacyService.UpdateMedicine(medicine);

                return Ok(request);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpDelete]
        [Route("delete/medcine")]
        public async Task<ActionResult> DeleteMedcine(int id)
        {
            try
            {
                if (id < 0) return BadRequest("Invalid id");
                var medicine = await _pharmacyService.GetMedicineById(id);
                if (medicine == null) return NotFound();

                await _pharmacyService.DeleteMedicine(medicine);

                return NoContent();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        [Route("add/towarehouse")]
        public async Task<ActionResult> AddNewMedcineToWarehoues([FromBody] AddNewMedicineToWarehouseRequest request)
        {
            try
            {
                if (request == null) return BadRequest("Invalid request");

                var medicine = await _pharmacyService.GetMedicineById(request.MedicineId);
                if (medicine == null) return BadRequest("Medicine with provided id doesn't exist");

                await _pharmacyService.AddMedicineToWarehouse(_mapper.Map<WarehouseDTO>(request));

                return Ok(request);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPut]
        [Route("update/warehouse")]
        public async Task<ActionResult> UpdateWarehouse([FromBody] UpdateWarehouseRequest request)
        {
            try
            {
                if (request == null) return BadRequest("Ivalid request");
                var medicine = await _pharmacyService.GetMedicineFromWarehouseByMedicineId(request.MedicineId);
                if (medicine == null) return BadRequest("Medicine with provided id doesn't exist");

                _mapper.Map(request, medicine);

                await _pharmacyService.UpdateWarehouse(medicine);

                return Ok(request);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpDelete]
        [Route("delete/warehouse")]
        public async Task<ActionResult> DeleteFromWarehouse(int id)
        {
            try
            {
                if (id < 0) return BadRequest("Invalid Id");
                var medicine = await _pharmacyService.GetMedicineFromWarehouseByMedicineId(id);
                if (medicine == null) return BadRequest("Medicine with provided id doesn't exist");

                await _pharmacyService.DeleteMedicineFromWarehouse(medicine);

                return NoContent();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
