using System;
using System.Collections.Generic;

namespace Pharmacy.Data
{
    public class Sale
    {
        public Sale()
        {
            Recipe = new List<Recipe>();
        }

        public int SaleId { get; set; }
        public int AccountId { get; set; }
        public int RecipeId { get; set; }
        public DateTime SaleDate { get; set; }
        public double Price { get; set; }
        public List<Recipe> Recipe { get; set; }
    }
}
