using System;
namespace Pharmacy.Service.Models.DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int MedicineId { get; set; }
        public int AccountId { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
