using IndraPU.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IndraPU.Domain;
using IndraPU.Context;

namespace IndraPU.Repositories
{
    public class StateRepository : IStateRepository
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="StateRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public StateRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public void Create(State entity)
        {
            _db.States.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public State Edit(State entity)
        {
            throw new NotImplementedException();
        }

        public List<State> GetAll()
        {
            return _db.States.ToList();
        }

        public State GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<State> GetStatesGraph(string id, int year)
        {
            List<State> resultsTemp = new List<State>();
            List<State> results = new List<State>();

            if (id == null)
            {
                resultsTemp = _db.States.ToList();
            }
            else
            {
                List<string> ids = id.Split(',').ToList();
                List<int> idInts = new List<int>();
                foreach (var item in ids)
                {
                    idInts.Add(Convert.ToInt32(item));
                }

                resultsTemp = _db.States.Where(c => idInts.Contains(c.Id)).ToList();
            }

            
            foreach (var state in resultsTemp)
            {
                var startDate = new DateTime(year, 1, 1);
                var endDate = new DateTime(year, 12, 31);
                var anu = _db.Programs.Where(c => c.StateId == state.Id && c.Date.Year == year).ToList();
                state.Programs.Clear();
                foreach (var item in anu)
                {
                    state.Programs.Add(item);
                }
                results.Add(state);
            }

            return results;
            
        }

        public bool IsStateExist(string areaCode)
        {
            return _db.States.Any(c => c.AreaCode.Equals(areaCode));
        }
    }
}