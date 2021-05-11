namespace Pharmacy.Service.Models.DTO
{
    public class MedicineDTO
    {
        public int MedicineId { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool IsRecipeRequired { get; set; }
    }
}
