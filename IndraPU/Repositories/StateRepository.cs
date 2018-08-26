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

        public bool IsStateExist(string areaCode)
        {
            return _db.States.Any(c => c.AreaCode.Equals(areaCode));
        }
    }
}