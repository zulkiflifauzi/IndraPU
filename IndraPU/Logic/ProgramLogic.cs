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
    public class ProgramLogic : IProgramLogic
    {
        private readonly ProgramRepository _repository = new ProgramRepository(new ApplicationDbContext());

        public ResponseMessage Create(Program entity)
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

        public ResponseMessage Edit(Program entity)
        {
            ResponseMessage response = new ResponseMessage();

            _repository.Edit(entity);

            return response;
        }

        public List<Program> GetAll()
        {
            return _repository.GetAll();
        }

        public Program GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}