using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Service.Models.Requests
{
    public class CreateMedicineRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Manufacturer { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
