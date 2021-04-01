using System;
using CactusProject.DAL.EF;
using CactusProject.DAL.Interfaces;
using CactusProject.DAL.Entities;
using CactusProject.DAL.Repositories;

namespace NLayerApp.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private CactusProjectContext db;
        private CactusRepository phoneRepository;
        private OrderRepository orderRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new CactusProjectContext(connectionString);
        }
        public IRepository<Cactus> Cactuses
        {
            get
            {
                if (phoneRepository == null)
                    phoneRepository = new CactusRepository(db);
                return phoneRepository;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}