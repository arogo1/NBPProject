using System;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Service.Models.Requests
{
    public class CreateSaleRequest
    {
        [Required]
        public int AccountId { get; set; }

        public int RecipeId { get; set; }

        public int MedicineId { get; set; }

        [Required]
        public DateTime SaleDate { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
