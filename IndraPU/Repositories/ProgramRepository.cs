using IndraPU.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IndraPU.Domain;
using IndraPU.Context;

namespace IndraPU.Repositories
{
    public class ProgramRepository : IProgramRepository
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgramRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public ProgramRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public void Create(Program entity)
        {
            _db.Programs.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var oldData = _db.Programs.SingleOrDefault(c => c.Id == id);

            _db.Programs.Remove(oldData);
            _db.SaveChanges();
        }

        public Program Edit(Program entity)
        {
            var program = _db.Programs.Find(entity.Id);
            _db.Entry(program).CurrentValues.SetValues(entity);
            _db.SaveChanges();
            return program;
        }

        public List<Program> GetAll()
        {
            return _db.Programs.ToList();
        }

        public Program GetById(int id)
        {
            return _db.Programs.SingleOrDefault(c => c.Id == id);
        }
    }
}