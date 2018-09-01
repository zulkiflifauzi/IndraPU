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
using System.Web.Script.Serialization;

namespace IndraPU.Controllers
{
    [Authorize]
    public class OPDController : Controller
    {
        private OPDLogic _opdLogic = new OPDLogic();
        // GET: OPD
        public ActionResult Index()
        {
            PrepareNodes();
            return View();
        }

        private void PrepareNodes()
        {

            var opds = _opdLogic.GetAll();

            var roots = opds.Where(c => !c.ParentId.HasValue).ToList();


            List<NodeViewModel> nodes = new List<NodeViewModel>();

            foreach (var item in roots)
            {
                CreateNodes(opds, nodes, item);
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ViewData["nodes"] = serializer.Serialize(nodes);
        }

        private static void CreateNodes(List<OPD> opds, List<NodeViewModel> nodes, OPD item)
        {
            NodeViewModel node = new NodeViewModel();

            node.text = item.Title;
            node.href = "/OPD/View/" + item.Id;
            nodes.Add(node);

            var childs = opds.Where(c => c.ParentId == item.Id).ToList();
            if (childs.Count > 0)
            {
                node.nodes = new List<NodeViewModel>();
                foreach (var child in childs)
                {
                    CreateNodes(opds, node.nodes, child);
                }
            }
        }

        // GET: OPD/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OPD/Create
        public ActionResult Create()
        {
            PrepareSelectList();
            return View();
        }

        private void PrepareSelectList()
        {
            var list = _opdLogic.GetAll();
            ViewData["OPDs"] = list;

            List<SelectListItem> odpTypeList = new List<SelectListItem>();
            odpTypeList.Add(new SelectListItem { Value = "BIDANG", Text = "BIDANG" });
            odpTypeList.Add(new SelectListItem { Value = "SEKSI", Text = "SEKSI" });

            ViewData["Types"] = odpTypeList;

            //List<SelectListItem> streetNumberList = new List<SelectListItem>();
            //foreach (var item in _streetNumberLogic.GetAll())
            //{
            //    streetNumberList.Add(new SelectListItem { Value = item.Number.ToString(), Text = item.Number });
            //}
            //ViewData["StreetNumbers"] = streetNumberList;

            //List<SelectListItem> freeUserList = new List<SelectListItem>();
            //foreach (var item in _userLogic.GetFreeUsers())
            //{
            //    freeUserList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.FirstName + " " + item.LastName });
            //}
            //ViewData["FreeUsers"] = freeUserList;
        }

        // POST: OPD/Create
        [HttpPost]
        public ActionResult Create(OPDViewModel model)
        {
            try
            {
                OPD opd = new OPD() { PIC = model.PIC, PhoneNumber = model.PhoneNumber, ParentId = model.ParentId, Title = model.Title, Type = model.Type, Structure = model.Structure };
                var response = _opdLogic.Create(opd);
                if (response.IsError == true)
                {
                    foreach (var item in response.ErrorCodes)
                    {
                        ModelState.AddModelError(string.Empty, item);
                    }
                    PrepareSelectList();
                    OPDFactory.InitializeContainers();
                    return View(model);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: OPD/View/5
        public ActionResult View(int id)
        {
            var opd = _opdLogic.GetById(id);
            OPDViewModel result = new OPDViewModel() { PhoneNumber = opd.PhoneNumber, PIC = opd.PIC, Id = opd.Id, Title = opd.Title, ParentId = opd.ParentId, Structure = opd.Structure, Type = opd.Type };

            var thisYearBudget = opd.OPDBudgets.SingleOrDefault(c => c.Year == DateTime.Now.Year);
            if (thisYearBudget != null)
            {
                result.ThisYearBudget = thisYearBudget.Budget;
            }

            result.Activities = new List<ActivityViewModel>();
            foreach (var item in opd.Activities)
            {
                ActivityViewModel activity = new ActivityViewModel();
                activity.Id = item.Id;
                activity.Budget = item.Budget;
                activity.Date = item.Date.ToString("mm-dd-yyyy");
                activity.Description = item.Description;
                activity.Title = item.Title;
                result.Activities.Add(activity);
            }

            result.OPDBudgets = new List<OPDBudgetViewModel>();
            opd.OPDBudgets = opd.OPDBudgets.OrderBy(c => c.Year).ToList();
            foreach (var item in opd.OPDBudgets)
            {
                OPDBudgetViewModel opdBudget = new OPDBudgetViewModel();
                opdBudget.Id = item.Id;
                opdBudget.Budget = item.Budget;
                opdBudget.Year = item.Year;
                result.OPDBudgets.Add(opdBudget);
            }

            return View(result);
        }

        // GET: OPD/Edit/5
        public ActionResult Edit(int id)
        {
            PrepareSelectList();
            var opd = _opdLogic.GetById(id);
            OPDViewModel result = new OPDViewModel() { PIC = opd.PIC, PhoneNumber = opd.PhoneNumber, Id = opd.Id, Title = opd.Title, ParentId = opd.ParentId, Structure = opd.Structure, Type = opd.Type };
            return View(result);
        }

        // POST: OPD/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, OPDViewModel model)
        {
            try
            {
                OPD opd = new OPD() { PhoneNumber = model.PhoneNumber, PIC = model.PIC, Id = model.Id, ParentId = model.ParentId, Title = model.Title, Type = model.Type, Structure = model.Structure };
                var response = _opdLogic.Edit(opd);
                if (response.IsError == true)
                {
                    foreach (var item in response.ErrorCodes)
                    {
                        ModelState.AddModelError(string.Empty, item);
                    }
                    PrepareSelectList();
                    OPDFactory.InitializeContainers();
                    return View(model);
                }
                return RedirectToAction("View", new { id = model.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: OPD/Delete/5
        public ActionResult Delete(int id)
        {
            var opd = _opdLogic.GetById(id);
            OPDViewModel result = new OPDViewModel() { PhoneNumber = opd.PhoneNumber, PIC = opd.PIC, Id = opd.Id, Title = opd.Title,  ParentId = opd.ParentId, Structure = opd.Structure, Type = opd.Type };
            return View(result);
        }

        // POST: OPD/Delete/5
        [HttpPost]
        public ActionResult Delete(OPDViewModel model)
        {
            try
            {
                var response = _opdLogic.Delete(model.Id); ;
                if (response.IsError == true)
                {
                    foreach (var item in response.ErrorCodes)
                    {
                        ModelState.AddModelError(string.Empty, item);
                    }

                    var opd = _opdLogic.GetById(model.Id);
                    OPDViewModel result = new OPDViewModel() { PhoneNumber = opd.PhoneNumber, PIC = opd.PIC, Id = opd.Id, Title = opd.Title, ParentId = opd.ParentId, Structure = opd.Structure, Type = opd.Type };
                    return View(result);
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
