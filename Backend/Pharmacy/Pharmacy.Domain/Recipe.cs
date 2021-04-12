using System;
using System.Collections.Generic;

namespace Pharmacy.Data
{
    public class Recipe
    {
        public Recipe()
        {
            Medicine = new List<Medicine>();
        }

        public int RecipeId { get; set; }
        public int MedicineId { get; set; }
        public int PatientId { get; set; }
        public DateTime CreateDate { get; set; }
        public List<Medicine> Medicine { get; set; }
        public Patient Patient { get; set; }
    }
}
