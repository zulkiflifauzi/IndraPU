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
    public class OPDBudgetController : Controller
    {
        private OPDBudgetLogic _opdBudgetLogic = new OPDBudgetLogic();

        // GET: Activity
        public ActionResult Index(int id)
        {
            var opdBudgets = _opdBudgetLogic.GetBudgetsByOPDId(id);
            List<OPDBudgetViewModel> results = new List<OPDBudgetViewModel>();
            foreach (var item in opdBudgets)
            {
                OPDBudgetViewModel result = new OPDBudgetViewModel();
                result.Id = item.Id;
                result.Budget = item.Budget;
                result.Year = item.Year;
                result.OPDId = item.OPDId;
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
        public ActionResult Create(OPDBudgetViewModel model)
        {
            try
            {
                OPDBudget opdBudget = new OPDBudget() { Budget = model.Budget, Year = model.Year, OPDId = model.OPDId  };

                var response = _opdBudgetLogic.Create(opdBudget);
                if (response.IsError == true)
                {
                    foreach (var item in response.ErrorCodes)
                    {
                        ModelState.AddModelError(string.Empty, item);
                    }
                    ViewData["OPDId"] = model.OPDId;
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
            var result = _opdBudgetLogic.GetById(id);
            OPDBudgetViewModel act = new OPDBudgetViewModel() { Id = result.Id, Year = result.Year, Budget = result.Budget, OPDId = result.OPDId };
            return View(act);
        }

        // POST: Activity/Edit/5
        [HttpPost]
        public ActionResult Edit(OPDBudgetViewModel model)
        {
            try
            {
                OPDBudget activity = new OPDBudget() { Id = model.Id, Budget = model.Budget, OPDId = model.OPDId, Year = model.Year };

                var response = _opdBudgetLogic.Edit(activity);
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
            var result = _opdBudgetLogic.GetById(id);
            OPDBudgetViewModel act = new OPDBudgetViewModel() { Id = result.Id, Year = result.Year, Budget = result.Budget, OPDId = result.OPDId };
            return View(act);
        }

        // POST: Activity/Delete/5
        [HttpPost]
        public ActionResult Delete(ActivityViewModel model)
        {
            try
            {
                var oldData = _opdBudgetLogic.GetById(model.Id);
                var response = _opdBudgetLogic.Delete(model.Id); ;
                if (response.IsError == true)
                {
                    foreach (var item in response.ErrorCodes)
                    {
                        ModelState.AddModelError(string.Empty, item);
                    }

                    var result = _opdBudgetLogic.GetById(model.Id);
                    OPDBudgetViewModel act = new OPDBudgetViewModel() { Id = result.Id, Year = result.Year, Budget = result.Budget, OPDId = result.OPDId };
                    return View(act);
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
