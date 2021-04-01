using System;
using System.Collections.Generic;
using System.Linq;
using CactusProject.DAL.Entities;
using CactusProject.DAL.EF;
using CactusProject.DAL.Interfaces;
using System.Data.Entity;

namespace CactusProject.DAL.Repositories
{
    public class CactusRepository : IRepository<Cactus>
    {
        private CactusProjectContext db;

        public CactusRepository(CactusProjectContext context)
        {
            this.db = context;
        }

        public IEnumerable<Cactus> GetAll()
        {
            return db.Cactuses;
        }

        public Cactus Get(int id)
        {
            return db.Cactuses.Find(id);
        }

        public void Create(Cactus cactus)
        {
            db.Cactuses.Add(cactus);
        }

        public void Update(Cactus cactus)
        {
            db.Entry(cactus).State = EntityState.Modified;
        }

        public IEnumerable<Cactus> Find(Func<Cactus, Boolean> predicate)
        {
            return db.Cactuses.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Cactus cactus = db.Cactuses.Find(id);
            if (cactus != null)
                db.Cactuses.Remove(cactus);
        }
    }
}