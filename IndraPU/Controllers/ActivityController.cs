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
    public class ActivityController : Controller
    {
        private ActivityLogic _actLogic = new ActivityLogic();

        // GET: Activity
        public ActionResult Index(int id)
        {
            var activities = _actLogic.GetActivitiesByOPDId(id);
            List<ActivityViewModel> results = new List<ActivityViewModel>();
            foreach (var item in activities)
            {
                ActivityViewModel result = new ActivityViewModel();
                result.Id = item.Id;
                result.Budget = item.Budget;
                result.Date = item.Date.ToString("mm-dd-yyyy");
                result.Description = item.Description;
                result.Title = item.Title;
                results.Add(result);
            }
            return View(results);
        }

        // GET: Activity/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Activity/Create
        public ActionResult Create(int id)
        {
            ViewData["OPDId"] = id;
            return View();
        }

        // POST: Activity/Create
        [HttpPost]
        public ActionResult Create(ActivityViewModel model)
        {
            try
            {
                Activity activity = new Activity() { Budget = model.Budget, Date = DateTime.ParseExact(model.Date, "mm-dd-yyyy", System.Globalization.CultureInfo.InvariantCulture), Description = model.Description, OPDId = model.OPDId, Title = model.Title };

                var response = _actLogic.Create(activity);
                if (response.IsError == true)
                {
                    foreach (var item in response.ErrorCodes)
                    {
                        ModelState.AddModelError(string.Empty, item);
                    }
                    return View(model);
                }

                return RedirectToAction("View", "OPD", new { id = model.OPDId });
            }
            catch
            {
                return View();
            }
        }

        // GET: Activity/Edit/5
        public ActionResult Edit(int id)
        {
            var result = _actLogic.GetById(id);
            ActivityViewModel act = new ActivityViewModel() { Id = result.Id, Title = result.Title, Budget = result.Budget, Date = result.Date.ToString("mm-dd-yyyy"), Description = result.Description, OPDId = result.OPDId };
            return View(act);
        }

        // POST: Activity/Edit/5
        [HttpPost]
        public ActionResult Edit(ActivityViewModel model)
        {
            try
            {
                Activity activity = new Activity() { Id = model.Id, Budget = model.Budget, Date = DateTime.ParseExact(model.Date, "mm-dd-yyyy", System.Globalization.CultureInfo.InvariantCulture), Description = model.Description, OPDId = model.OPDId, Title = model.Title };

                var response = _actLogic.Edit(activity);
                if (response.IsError == true)
                {
                    foreach (var item in response.ErrorCodes)
                    {
                        ModelState.AddModelError(string.Empty, item);
                    }
                    return View(model);
                }

                return RedirectToAction("View", "OPD", new { id = model.OPDId });
            }
            catch
            {
                return View();
            }
        }

        // GET: Activity/Delete/5
        public ActionResult Delete(int id)
        {
            var result = _actLogic.GetById(id);
            ActivityViewModel act = new ActivityViewModel() { Id = result.Id, Title = result.Title, Budget = result.Budget, Date = result.Date.ToString("mm-dd-yyyy"), Description = result.Description, OPDId = result.OPDId };
            return View(act);
        }

        // POST: Activity/Delete/5
        [HttpPost]
        public ActionResult Delete(ActivityViewModel model)
        {
            try
            {
                var oldData = _actLogic.GetById(model.Id);
                var response = _actLogic.Delete(model.Id); ;
                if (response.IsError == true)
                {
                    foreach (var item in response.ErrorCodes)
                    {
                        ModelState.AddModelError(string.Empty, item);
                    }

                    var result = _actLogic.GetById(model.Id);
                    ActivityViewModel act = new ActivityViewModel() { Id = result.Id, Title = result.Title, Budget = result.Budget, Date = result.Date.ToString("mm-dd-yyyy"), Description = result.Description, OPDId = result.OPDId };
                    return View(result);
                }
                return RedirectToAction("View", "OPD", new { id = oldData.OPDId });
            }
            catch
            {
                return View();
            }
        }
    }
}
