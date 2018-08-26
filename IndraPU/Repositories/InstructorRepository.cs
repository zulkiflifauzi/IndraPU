using IndraPU.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IndraPU.Domain;
using IndraPU.Context;

namespace IndraPU.Repositories
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="InstructorRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public InstructorRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public void Create(Instructor entity)
        {
            _db.Instructors.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var oldData = _db.Instructors.SingleOrDefault(c => c.Id == id);
            
            _db.Instructors.Remove(oldData);
            _db.SaveChanges();
        }

        public Instructor Edit(Instructor entity)
        {
            var Instructor = _db.Instructors.Find(entity.Id);
            _db.Entry(Instructor).CurrentValues.SetValues(entity);
            _db.SaveChanges();
            return Instructor;
        }

        public List<Instructor> GetAll()
        {
            return _db.Instructors.ToList();
        }

        public Instructor GetById(int id)
        {
            return _db.Instructors.SingleOrDefault(c => c.Id == id);
        }
    }
}