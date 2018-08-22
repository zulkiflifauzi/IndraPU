using IndraPU.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IndraPU.Models;
using IndraPU.Context;

namespace IndraPU.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public UserRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public void Create(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser Edit(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        public List<ApplicationUser> GetAll()
        {
            return _db.Users.ToList();
        }

        public ApplicationUser GetById(int id)
        {
            return _db.Users.SingleOrDefault(c => c.Id == id);
        }

        public List<ApplicationUser> GetFreeUsers(List<int> exceptions)
        {
            return _db.Users.Where(c => !exceptions.Contains(c.Id)).ToList();
        }
    }
}