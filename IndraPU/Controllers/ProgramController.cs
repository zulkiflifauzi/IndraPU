using IndraPU.Component;
using IndraPU.Domain;
using IndraPU.Logic;
using IndraPU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IndraPU.Controllers
{
    [Authorize]
    public class ProgramController : Controller
    {
        private ProgramLogic _programLogic = new ProgramLogic();

        // GET: Instructor
        public ActionResult Index()
        {
            var programs = _programLogic.GetAll();
            List<ProgramViewModel> results = new List<ProgramViewModel>();
            foreach (var item in programs)
            {
                ProgramViewModel program = new ProgramViewModel() { Id = item.Id, Address = item.Address, Budget = item.Budget, CityId = item.CityId, CityName = item.City.Title, Date = item.Date.ToString("mm-dd-yyyy"), EmploymentDept = item.EmploymentDept, Title = item.Title, Method = item.Method, Participants = item.Participants, SourceOfFunds = item.SourceOfFunds, StateId = item.StateId, StateName = item.State.Title, Type = item.Type };
                results.Add(program);
            }
            return View(results);
        }

        // GET: Instructor/Details/5
        public ActionResult Details(int id)
        {
            var item = _programLogic.GetById(id);
            ProgramViewModel instructor = new ProgramViewModel() { Id = item.Id, Address = item.Address, Budget = item.Budget, CityId = item.CityId, CityName = item.City.Title, Date = item.Date.ToString("mm-dd-yyyy"), EmploymentDept = item.EmploymentDept, Title = item.Title, Method = item.Method, Participants = item.Participants, SourceOfFunds = item.SourceOfFunds, StateId = item.StateId, StateName = item.State.Title, Type = item.Type };
            return View(instructor);
        }

        // GET: Instructor/Create
        public ActionResult Create()
        {
            PrepareSelectList();
            return View();
        }

        private void PrepareSelectList(int? stateId = null, int? cityId = null)
        {
            var states = StateFactory.GetAllStates();

            List<SelectListItem> stateList = new List<SelectListItem>();
            foreach (var item in states)
            {
                if (stateId.HasValue)
                {
                    if (stateId == item.Id)
                        stateList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Title, Selected = true });
                    else
                        stateList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Title });
                }
                else
                    stateList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Title });
            }
            ViewData["States"] = stateList;

            if (cityId.HasValue)
            {
                var cities = StateFactory.GetCitiesByStateId(stateId.Value);

                List<SelectListItem> cityList = new List<SelectListItem>();
                foreach (var item in cities)
                {
                    if (cityId.HasValue)
                    {
                        if (cityId == item.Id)
                            stateList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Title, Selected = true });
                        else
                            stateList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Title });
                    }
                    else
                        stateList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Title });
                }
                ViewData["Cities"] = cityList;
            }

        }

        // POST: Instructor/Create
        [HttpPost]
        public ActionResult Create(ProgramViewModel model)
        {
            try
            {
                Program program = new Program() { Address = model.Address, Budget = model.Budget, CityId = model.CityId, Date = DateTime.ParseExact(model.Date, "mm-dd-yyyy", System.Globalization.CultureInfo.InvariantCulture), EmploymentDept = model.EmploymentDept, Title = model.Title, Method = model.Method, Participants = model.Participants, SourceOfFunds = model.SourceOfFunds, StateId = model.StateId, Type = model.Type };
                var response = _programLogic.Create(program);
                if (response.IsError == true)
                {
                    foreach (var item in response.ErrorCodes)
                    {
                        ModelState.AddModelError(string.Empty, item);
                    }
                    PrepareSelectList();
                    return View(model);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Instructor/Edit/5
        public ActionResult Edit(int id)
        {
            var item = _programLogic.GetById(id);
            PrepareSelectList(item.StateId, item.CityId);
            ProgramViewModel program = new ProgramViewModel() { Id = item.Id, Address = item.Address, Budget = item.Budget, CityId = item.CityId, CityName = item.City.Title, Date = item.Date.ToString("mm-dd-yyyy"), EmploymentDept = item.EmploymentDept, Title = item.Title, Method = item.Method, Participants = item.Participants, SourceOfFunds = item.SourceOfFunds, StateId = item.StateId, StateName = item.State.Title, Type = item.Type };
            return View(program);
        }

        // POST: Instructor/Edit/5
        [HttpPost]
        public ActionResult Edit(ProgramViewModel model)
        {
            try
            {
                Program program = new Program() { Id = model.Id, Address = model.Address, Budget = model.Budget, CityId = model.CityId, Date = DateTime.ParseExact(model.Date, "mm-dd-yyyy", System.Globalization.CultureInfo.InvariantCulture), EmploymentDept = model.EmploymentDept, Title = model.Title, Method = model.Method, Participants = model.Participants, SourceOfFunds = model.SourceOfFunds, StateId = model.StateId, Type = model.Type };
                var response = _programLogic.Edit(program);
                if (response.IsError == true)
                {
                    foreach (var item in response.ErrorCodes)
                    {
                        ModelState.AddModelError(string.Empty, item);
                    }
                    PrepareSelectList(model.StateId, model.CityId);
                    return View(model);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Instructor/Delete/5
        public ActionResult Delete(int id)
        {
            var item = _programLogic.GetById(id);
            ProgramViewModel program = new ProgramViewModel() { Id = item.Id, Address = item.Address, Budget = item.Budget, CityId = item.CityId, CityName = item.City.Title, Date = item.Date.ToString("mm-dd-yyyy"), EmploymentDept = item.EmploymentDept, Title = item.Title, Method = item.Method, Participants = item.Participants, SourceOfFunds = item.SourceOfFunds, StateId = item.StateId, StateName = item.State.Title, Type = item.Type };
            return View(program);
        }

        // POST: Instructor/Delete/5
        [HttpPost]
        public ActionResult Delete(ProgramViewModel model)
        {
            try
            {
                var response = _programLogic.Delete(model.Id); ;
                if (response.IsError == true)
                {
                    foreach (var error in response.ErrorCodes)
                    {
                        ModelState.AddModelError(string.Empty, error);
                    }

                    var item = _programLogic.GetById(model.Id);
                    ProgramViewModel program = new ProgramViewModel() { Id = item.Id, Address = item.Address, Budget = item.Budget, CityId = item.CityId, CityName = item.City.Title, Date = item.Date.ToString("mm-dd-yyyy"), EmploymentDept = item.EmploymentDept, Title = item.Title, Method = item.Method, Participants = item.Participants, SourceOfFunds = item.SourceOfFunds, StateId = item.StateId, StateName = item.State.Title, Type = item.Type };
                    return View(program);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}