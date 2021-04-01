using System;

namespace CactusProject.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public int CactusID { get; set; }
        public Cactus Cactus { get; set; }

        public DateTime Date { get; set; }
    }
}