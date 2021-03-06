﻿using IndraPU.Logic.Interface;
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
    public class StateLogic : IStateLogic
    {
        private readonly StateRepository _repository = new StateRepository(new ApplicationDbContext());

        public ResponseMessage Create(State entity)
        {
            ResponseMessage response = new ResponseMessage();

            if (_repository.IsStateExist(entity.AreaCode))
            {
                response.IsError = true;
                response.ErrorCodes.Add("State Already Exist");
                return response;
            }
            _repository.Create(entity);

            return response;
        }

        public ResponseMessage Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage Edit(State entity)
        {
            throw new NotImplementedException();
        }

        public List<State> GetAll()
        {
            return _repository.GetAll();
        }

        public List<State> GetBJKWIVStates()
        {
            var states = _repository.GetAll();
            var results = new List<State>();

            foreach (var item in states)
            {
                if (item.Title.Equals("Prov. Jawa Tengah") || item.Title.Equals("Prov. D.I. Yogyakarta")
                    || item.Title.Equals("Prov. Jawa Timur") || item.Title.Equals("Prov. Bali")
                    || item.Title.Equals("Prov. Nusa Tenggara Barat") || item.Title.Equals("Prov. Nusa Tenggara Timur"))
                {
                    results.Add(item);
                }
            }
            return results;
        }

        public State GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<State> GetStatesGraph(string id, int year)
        {
            return _repository.GetStatesGraph(id, year);
        }
    }
}