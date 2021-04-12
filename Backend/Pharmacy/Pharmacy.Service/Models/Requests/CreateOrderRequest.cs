using System;
namespace Pharmacy.Service.Models.Requests
{
    public class CreateOrderRequest
    {
        public int MedicineId { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
