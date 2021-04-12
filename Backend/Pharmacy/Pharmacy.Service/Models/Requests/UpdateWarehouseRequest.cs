using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Service.Models.Requests
{
    public class UpdateWarehouseRequest
    {
        [Required]
        public int MedicineId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
