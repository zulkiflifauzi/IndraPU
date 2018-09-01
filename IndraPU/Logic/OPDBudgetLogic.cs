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
    public class OPDBudgetLogic : IOPDBudgetLogic
    {
        private readonly OPDBudgetRepository _repository = new OPDBudgetRepository(new ApplicationDbContext());

        public ResponseMessage Create(OPDBudget entity)
        {
            ResponseMessage response = new ResponseMessage();
            if (_repository.IsOPDBudgetExist(entity.Year, entity.OPDId))
            {
                response.IsError = true;
                response.ErrorCodes.Add("Budget for this year already exist");
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

        public ResponseMessage Edit(OPDBudget entity)
        {
            ResponseMessage response = new ResponseMessage();

            if (_repository.IsOPDBudgetExist(entity.Year, entity.OPDId, entity.Id))
            {
                response.IsError = true;
                response.ErrorCodes.Add("Budget for this year already exist");
                return response;
            }

            _repository.Edit(entity);

            return response;
        }

        public List<OPDBudget> GetBudgetsByOPDId(int opdId)
        {
            return _repository.GetBudgetsByOPDId(opdId);
        }

        public List<OPDBudget> GetAll()
        {
            return _repository.GetAll();
        }

        public OPDBudget GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}