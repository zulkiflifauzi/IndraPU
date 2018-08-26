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
    public class ActivityLogic : IActivityLogic
    {
        private readonly ActivityRepository _repository = new ActivityRepository(new ApplicationDbContext());

        public ResponseMessage Create(Activity entity)
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

        public ResponseMessage Edit(Activity entity)
        {
            ResponseMessage response = new ResponseMessage();

            _repository.Edit(entity);

            return response;
        }

        public List<Activity> GetActivitiesByOPDId(int opdId)
        {
            return _repository.GetActivitiesByOPDId(opdId);
        }

        public List<Activity> GetAll()
        {
            return _repository.GetAll();
        }

        public Activity GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}