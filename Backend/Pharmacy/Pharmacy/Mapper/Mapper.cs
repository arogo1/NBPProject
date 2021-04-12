using AutoMapper;
using Pharmacy.Data;
using Pharmacy.Service.Models.DTO;
using Pharmacy.Service.Models.Requests;

namespace Pharmacy.WebApi.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<CreateMedicineRequest, MedicineDTO>();

            CreateMap<MedicineDTO, CreateMedicineRequest>();

            CreateMap<MedicineDTO, Medicine>();

            CreateMap<Medicine, MedicineDTO>();

            CreateMap<UpdateMedicineRequest, MedicineDTO>();

            CreateMap<WarehouseDTO, Warehouse>();

            CreateMap<Warehouse, WarehouseDTO>();

            CreateMap<AddNewMedicineToWarehouseRequest, WarehouseDTO>();

            CreateMap<UpdateWarehouseRequest, WarehouseDTO>();

            CreateMap<CreateOrderRequest, OrderDTO>();

            CreateMap<OrderDTO, Order>();

            CreateMap<Order, OrderDTO>();

            CreateMap<Recipe, RecipeDTO>();

            CreateMap<CreateSaleRequest, SaleDTO>();

            CreateMap<Sale, SaleDTO>();

            CreateMap<SaleDTO, Sale>();
        }
    }
}
