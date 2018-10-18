using IndraPU.Base;
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
    public class AssesorController : Controller
    {
        private InstructorLogic _instructorLogic = new InstructorLogic();

        // GET: Instructor
        public ActionResult Index()
        {
            var instructors = _instructorLogic.GetInstructorByType(Constant.InstructorType.ASSESOR);
            List<InstructorViewModel> results = new List<InstructorViewModel>();
            foreach (var item in instructors)
            {
                InstructorViewModel instructor = new InstructorViewModel() { Id = item.Id, Address = item.Address, Area = item.Area, CityId = item.CityId, CityName = item.City.Title, DateOfBirth = item.DateOfBirth.ToString("dd-mm-yyyy"), Email = item.Email, Name = item.Name, PhoneNumber = item.PhoneNumber, PlaceOfBirth = item.PlaceOfBirth, StateId = item.StateId, StateName = item.State.Title };

                results.Add(instructor);
            }
            return View(results);
        }

        // GET: Instructor/Details/5
        public ActionResult Details(int id)
        {
            var item = _instructorLogic.GetById(id);
            InstructorViewModel instructor = new InstructorViewModel() { Id = item.Id, Address = item.Address, Area = item.Area, CityId = item.CityId, CityName = item.City.Title, DateOfBirth = item.DateOfBirth.ToString("dd-mm-yyyy"), Email = item.Email, Name = item.Name, PhoneNumber = item.PhoneNumber, PlaceOfBirth = item.PlaceOfBirth, StateId = item.StateId, StateName = item.State.Title };
            return View(instructor);
        }

        [Authorize]
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

        [Authorize]
        [HttpPost]
        public ActionResult Create(InstructorViewModel model)
        {
            try
            {
                Instructor instructor = new Instructor() { Address = model.Address, Area = model.Area, CityId = model.CityId, DateOfBirth = DateTime.ParseExact(model.DateOfBirth, "mm-dd-yyyy", System.Globalization.CultureInfo.InvariantCulture), Email = model.Email, Name = model.Name, PhoneNumber = model.PhoneNumber, PlaceOfBirth = model.PlaceOfBirth, StateId = model.StateId, Type = Constant.InstructorType.ASSESOR };
                var response = _instructorLogic.Create(instructor);
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

        [Authorize]
        public ActionResult Edit(int id)
        {
            var item = _instructorLogic.GetById(id);
            PrepareSelectList(item.StateId, item.CityId);
            InstructorViewModel instructor = new InstructorViewModel() { Id = item.Id, Address = item.Address, Area = item.Area, CityId = item.CityId, CityName = item.City.Title, DateOfBirth = item.DateOfBirth.ToString("dd-mm-yyyy"), Email = item.Email, Name = item.Name, PhoneNumber = item.PhoneNumber, PlaceOfBirth = item.PlaceOfBirth, StateId = item.StateId, StateName = item.State.Title };
            return View(instructor);
        }

        // POST: Instructor/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(InstructorViewModel model)
        {
            try
            {
                Instructor instructor = new Instructor() { Id = model.Id, Address = model.Address, Area = model.Area, CityId = model.CityId, DateOfBirth = DateTime.ParseExact(model.DateOfBirth, "mm-dd-yyyy", System.Globalization.CultureInfo.InvariantCulture), Email = model.Email, Name = model.Name, PhoneNumber = model.PhoneNumber, PlaceOfBirth = model.PlaceOfBirth, StateId = model.StateId };
                var response = _instructorLogic.Edit(instructor);
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
        [Authorize]
        public ActionResult Delete(int id)
        {
            var item = _instructorLogic.GetById(id);
            InstructorViewModel instructor = new InstructorViewModel() { Id = item.Id, Address = item.Address, Area = item.Area, CityId = item.CityId, CityName = item.City.Title, DateOfBirth = item.DateOfBirth.ToString("dd-mm-yyyy"), Email = item.Email, Name = item.Name, PhoneNumber = item.PhoneNumber, PlaceOfBirth = item.PlaceOfBirth, StateId = item.StateId, StateName = item.State.Title };
            return View(instructor);
        }

        // POST: Instructor/Delete/5
        [Authorize]
        [HttpPost]
        public ActionResult Delete(InstructorViewModel model)
        {
            try
            {
                var response = _instructorLogic.Delete(model.Id); ;
                if (response.IsError == true)
                {
                    foreach (var error in response.ErrorCodes)
                    {
                        ModelState.AddModelError(string.Empty, error);
                    }

                    var item = _instructorLogic.GetById(model.Id);
                    InstructorViewModel instructor = new InstructorViewModel() { Id = item.Id, Address = item.Address, Area = item.Area, CityId = item.CityId, CityName = item.City.Title, DateOfBirth = item.DateOfBirth.ToString("dd-mm-yyyy"), Email = item.Email, Name = item.Name, PhoneNumber = item.PhoneNumber, PlaceOfBirth = item.PlaceOfBirth, StateId = item.StateId, StateName = item.State.Title };
                    return View(instructor);
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