using IndraPU.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IndraPU.Domain;
using IndraPU.Context;

namespace IndraPU.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="CityRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public CityRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public void Create(City entity)
        {
            _db.Cities.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public City Edit(City entity)
        {
            throw new NotImplementedException();
        }

        public List<City> GetAll()
        {
            return _db.Cities.ToList();
        }

        public City GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsCityExist(string areaCode)
        {
            return _db.Cities.Any(c => c.AreaCode.Equals(areaCode));
        }
    }
}