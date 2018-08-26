using IndraPU.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IndraPU.Domain;
using IndraPU.Context;

namespace IndraPU.Repositories
{
    public class OPDRepository : IOPDRepository
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="OPDRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public OPDRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public void Create(OPD entity)
        {
            _db.OPDs.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var oldData = _db.OPDs.SingleOrDefault(c => c.Id == id);

            foreach (var item in oldData.Activities.ToList())
            {
                _db.Activities.Remove(item);
            }

            _db.OPDs.Remove(oldData);
            _db.SaveChanges();
        }

        public OPD Edit(OPD entity)
        {
            var opd = _db.OPDs.Find(entity.Id);
            _db.Entry(opd).CurrentValues.SetValues(entity);
            _db.SaveChanges();
            return opd;
        }

        public List<OPD> GetAll()
        {
            return _db.OPDs.ToList();
        }

        public OPD GetById(int id)
        {
            return _db.OPDs.SingleOrDefault(c => c.Id == id);
        }

        public bool IsOPDExist(string Title, int? exludeId = null)
        {
            if (exludeId != null)
                return _db.OPDs.Any(c => c.Title.Equals(Title) && c.Id != exludeId);
            else
                return _db.OPDs.Any(c => c.Title.Equals(Title));
        }
    }
}