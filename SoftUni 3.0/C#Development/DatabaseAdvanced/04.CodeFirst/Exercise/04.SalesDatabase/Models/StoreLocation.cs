using System.Collections.Generic;

namespace _04.SalesDatabase.Models
{
    public class StoreLocation
    {
        public StoreLocation()
        {
            this.SalesInStore = new HashSet<Sale>();
        }
        public  int Id { get; set; }

        public string LocationName { get; set; }

        public ICollection<Sale> SalesInStore { get; set; }
    }
}