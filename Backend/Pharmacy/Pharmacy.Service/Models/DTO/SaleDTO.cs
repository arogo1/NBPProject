using System;
namespace Pharmacy.Service.Models.DTO
{
    public class SaleDTO
    {
        public int SaleId { get; set; }
        public int AccountId { get; set; }
        public int RecipeId { get; set; }
        public DateTime SaleDate { get; set; }
        public double Price { get; set; }
    }
}
