using System.Collections.Generic;

namespace CactusProject.DAL.Entities
{
    public class Cactus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public decimal Price { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}