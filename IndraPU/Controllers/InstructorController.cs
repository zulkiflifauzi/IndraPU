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
    public class InstructorController : Controller
    {
        private InstructorLogic _instructorLogic = new InstructorLogic();

        // GET: Instructor
        public ActionResult Index()
        {
            var instructors = _instructorLogic.GetAll();
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
            return View();
        }

        // GET: Instructor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Instructor/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

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
            return View();
        }

        // POST: Instructor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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
            return View();
        }

        // POST: Instructor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
