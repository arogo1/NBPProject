using System;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Service.Models.Requests
{
    public class CreateSaleRequest
    {
        [Required]
        public int AccountId { get; set; }

        [Required]
        public int RecipeId { get; set; }

        [Required]
        public DateTime SaleDate { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
