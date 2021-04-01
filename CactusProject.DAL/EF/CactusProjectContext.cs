using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using CactusProject.DAL.Entities;

namespace CactusProject.DAL.EF
{
    public class CactusProjectContext : DbContext
    {
        public DbSet<Cactus> Cactuses { get; set; }
        public DbSet<Order> Orders { get; set; }

        static CactusProjectContext()
        {
            Database.SetInitializer<CactusProjectContext>(new StoreDbInitializer());
        }
        public CactusProjectContext(string connectionString)
            : base(connectionString)
        {
        }
    }
    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<CactusProjectContext>
    {
        protected override void Seed(CactusProjectContext db)
        {
            db.Cactuses.Add(new Cactus { Name = "Опунция", Country = "Америка", Price = 800 });
            db.Cactuses.Add(new Cactus { Name = "Эхинокактус Грузона", Country = "Мексика", Price = 550 });
            db.Cactuses.Add(new Cactus { Name = "Апорокактус плетевидный", Country = "Мексика", Price = 1100 });
            db.SaveChanges();
        }
    }
}