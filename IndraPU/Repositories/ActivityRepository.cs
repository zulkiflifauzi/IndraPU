using IndraPU.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IndraPU.Domain;
using IndraPU.Context;

namespace IndraPU.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActivityRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public ActivityRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public void Create(Activity entity)
        {
            _db.Activities.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var oldData = _db.Activities.SingleOrDefault(c => c.Id == id);
            _db.Activities.Remove(oldData);
            _db.SaveChanges();
        }

        public Activity Edit(Activity entity)
        {
            var activity = _db.Activities.Find(entity.Id);
            _db.Entry(activity).CurrentValues.SetValues(entity);
            _db.SaveChanges();
            return activity;
        }

        public List<Activity> GetActivitiesByOPDId(int opdId)
        {
            return _db.Activities.Where(c => c.OPDId == opdId).ToList();
        }

        public List<Program> GetActivitiesByYear(string id, int year)
        {
            if (id == null)
            {
                return _db.Programs.Where(c => c.Date.Year == year).ToList();
            }
            else
            {
                List<string> ids = id.Split(',').ToList();
                List<int> idInts = new List<int>();
                foreach (var item in ids)
                {
                    idInts.Add(Convert.ToInt32(item));
                }
                return _db.Programs.Where(c => c.Date.Year == year && idInts.Contains(c.StateId)).ToList();
            }
            
        }

        public List<Activity> GetAll()
        {
            return _db.Activities.ToList();
        }

        public List<string> GetBudgetYears()
        {
            return _db.Programs.Select(c => c.Date.Year.ToString()).Distinct().ToList();
        }

        public Activity GetById(int id)
        {
            return _db.Activities.SingleOrDefault(c => c.Id == id);
        }
    }
}