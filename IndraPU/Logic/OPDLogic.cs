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
    public class OPDLogic : IOPDLogic
    {
        private readonly OPDRepository _repository = new OPDRepository(new ApplicationDbContext());

        public ResponseMessage Create(OPD entity)
        {
            ResponseMessage response = new ResponseMessage();

            if (_repository.IsOPDExist(entity.Title))
            {
                response.IsError = true;
                response.ErrorCodes.Add("OPD Already Exist");
                return response;
            }
            _repository.Create(entity);

            return response;
        }

        public ResponseMessage Delete(int id)
        {
            ResponseMessage response = new ResponseMessage();

            _repository.Delete(id);

            return response;
        }

        public ResponseMessage Edit(OPD entity)
        {
            ResponseMessage response = new ResponseMessage();

            if (_repository.IsOPDExist(entity.Title, entity.Id))
            {
                response.IsError = true;
                response.ErrorCodes.Add("OPD Already Exist");
                return response;
            }

            _repository.Edit(entity);

            return response;
        }

        public List<OPD> GetAll()
        {
            return _repository.GetAll();
        }

        public OPD GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}