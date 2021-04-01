using CactusProject.DAL.Entities;
using System;
using CactusProject.DAL.Interfaces;

namespace CactusProject.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Cactus> Cactuses { get; }
        IRepository<Order> Orders { get; }
        void Save();
    }
}