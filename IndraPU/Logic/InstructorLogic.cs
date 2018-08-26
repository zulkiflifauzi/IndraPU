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
    public class InstructorLogic : IInstructorLogic
    {
        private readonly InstructorRepository _repository = new InstructorRepository(new ApplicationDbContext());

        public ResponseMessage Create(Instructor entity)
        {
            ResponseMessage response = new ResponseMessage();
            
            _repository.Create(entity);

            return response;
        }

        public ResponseMessage Delete(int id)
        {
            ResponseMessage response = new ResponseMessage();

            _repository.Delete(id);

            return response;
        }

        public ResponseMessage Edit(Instructor entity)
        {
            ResponseMessage response = new ResponseMessage();

            _repository.Edit(entity);

            return response;
        }

        public List<Instructor> GetAll()
        {
            return _repository.GetAll();
        }

        public Instructor GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}