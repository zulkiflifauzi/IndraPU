using IndraPU.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IndraPU.Domain;
using IndraPU.Context;
using IndraPU.Base;

namespace IndraPU.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public ContactRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public void Create(Contact entity)
        {
            entity.Status = Constant.ContactStatus.NEW;
            entity.CreatedDate = DateTime.Now;
            _db.Contacts.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Contact Edit(Contact entity)
        {
            var contact = _db.Contacts.Find(entity.Id);
            _db.Entry(contact).CurrentValues.SetValues(entity);
            _db.SaveChanges();
            return contact;
        }

        public List<Contact> GetAll()
        {
            return _db.Contacts.ToList();
        }

        public Contact GetById(int id)
        {
            return _db.Contacts.SingleOrDefault(c=> c.Id == id);
        }
    }
}