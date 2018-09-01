using IndraPU.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IndraPU.Domain;
using IndraPU.Context;

namespace IndraPU.Repositories
{
    public class OPDBudgetRepository : IOPDBudgetRepository
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="OPDBudgetRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public OPDBudgetRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public void Create(OPDBudget entity)
        {
            _db.OPDBudgets.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var oldData = _db.OPDBudgets.SingleOrDefault(c => c.Id == id);
            _db.OPDBudgets.Remove(oldData);
            _db.SaveChanges();
        }

        public OPDBudget Edit(OPDBudget entity)
        {
            var opdBudget = _db.OPDBudgets.Find(entity.Id);
            _db.Entry(opdBudget).CurrentValues.SetValues(entity);
            _db.SaveChanges();
            return opdBudget;
        }

        public List<OPDBudget> GetBudgetsByOPDId(int opdId)
        {
            return _db.OPDBudgets.Where(c => c.OPDId == opdId).ToList();
        }

        public List<OPDBudget> GetAll()
        {
            return _db.OPDBudgets.ToList();
        }

        public OPDBudget GetById(int id)
        {
            return _db.OPDBudgets.SingleOrDefault(c => c.Id == id);
        }

        public bool IsOPDBudgetExist(int year, int opdId,  int? excludeId = null)
        {
            if (excludeId != null)
                return _db.OPDBudgets.Any(c => c.OPDId == opdId && c.Year == year && c.Id != excludeId);
            else
                return _db.OPDBudgets.Any(c => c.OPDId == opdId && c.Year == year);
        }
    }
}