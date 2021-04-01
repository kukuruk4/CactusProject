using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CactusProject.DAL.Entities;
using CactusProject.DAL.Interfaces;
using CactusProject.DAL.EF;


namespace NLayerApp.DAL.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private CactusProjectContext db;

        public OrderRepository(CactusProjectContext context)
        {
            this.db = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return db.Orders.Include(o => o.Cactus);
        }

        public Order Get(int id)
        {
            return db.Orders.Find(id);
        }

        public void Create(Order order)
        {
            db.Orders.Add(order);
        }

        public void Update(Order order)
        {
            db.Entry(order).State = EntityState.Modified;
        }
        public IEnumerable<Order> Find(Func<Order, Boolean> predicate)
        {
            return db.Orders.Include(o => o.Cactus).Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Order order = db.Orders.Find(id);
            if (order != null)
                db.Orders.Remove(order);
        }
    }
}