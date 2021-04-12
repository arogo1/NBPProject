using System.Collections.Generic;

namespace Pharmacy.Data
{
    public class Warehouse
    {

        public Warehouse()
        {
            Medicine = new List<Medicine>();
        }

        public int Id { get; set; }
        public int MedicineId { get; set; }
        public int Quantity { get; set; }
        public List<Medicine> Medicine { get; set; }
    }
}
