using IndraPU.Logic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IndraPU.Base;
using IndraPU.Domain;
using IndraPU.Repositories;
using IndraPU.Context;

namespace IndraPU.Logic
{
    public class ContactLogic : IContactLogic
    {
        private readonly ContactRepository _repository = new ContactRepository(new ApplicationDbContext());

        public ResponseMessage Create(Contact entity)
        {
            ResponseMessage response = new ResponseMessage();

            _repository.Create(entity);

            return response;
        }

        public ResponseMessage Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage Edit(Contact entity)
        {
            ResponseMessage response = new ResponseMessage();

            _repository.Edit(entity);

            return response;
        }

        public List<Contact> GetAll()
        {
            return _repository.GetAll();
        }

        public Contact GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}