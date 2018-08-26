using IndraPU.Domain;
using IndraPU.Logic;
using IndraPU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IndraPU.Controllers
{
    public class StateController : Controller
    {
        private StateLogic _stateLogic = new StateLogic();
        private CityLogic _cityLogic = new CityLogic();
        // GET: State
        public ActionResult Index()
        {
            return View();
        }

        // GET: State
        public async Task<ActionResult> ImportData(string id)
        {
            string apiUrl = "http://jendela.data.kemdikbud.go.id/api/index.php/CWilayah/wilayahGET";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            DikbudViewModel results = new DikbudViewModel(); 
            if (response.IsSuccessStatusCode)
            {
                results = await response.Content.ReadAsAsync<DikbudViewModel>();

                foreach (var item in results.data)
                {
                    State state = new State();
                    state.AreaCode = item.kode_wilayah;
                    state.Title = item.nama;
                    _stateLogic.Create(state);
                }
            }

            return null;
        }

        // GET: State
        public async Task<ActionResult> ImportDataCity()
        {
            var states = _stateLogic.GetAll();

            foreach (var state in states)
            {
                string apiUrl = "http://jendela.data.kemdikbud.go.id/api/index.php/CWilayah/wilayahGET?mst_kode_wilayah=" + state.AreaCode;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                DikbudViewModel results = new DikbudViewModel();
                if (response.IsSuccessStatusCode)
                {
                    results = await response.Content.ReadAsAsync<DikbudViewModel>();

                    foreach (var item in results.data)
                    {
                        City city = new City();
                        city.AreaCode = item.kode_wilayah;
                        city.Title = item.nama;
                        city.StateId = state.Id;
                        _cityLogic.Create(city);
                    }
                }
            }           

            return null;
        }


        // GET: State/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: State/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: State/Create
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

        // GET: State/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: State/Edit/5
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

        // GET: State/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: State/Delete/5
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
