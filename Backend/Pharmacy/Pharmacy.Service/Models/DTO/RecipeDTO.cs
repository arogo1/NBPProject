using System;
namespace Pharmacy.Service.Models.DTO
{
    public class RecipeDTO
    {
        public int RecipeId { get; set; }
        public int MedicineId { get; set; }
        public int PatientId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
