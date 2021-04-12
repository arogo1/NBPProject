using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Service.Models.Requests
{
    public class AddNewMedicineToWarehouseRequest
    {
        [Required]
        public int MedicineId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
