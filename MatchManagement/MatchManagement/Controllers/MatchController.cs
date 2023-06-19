using MatchManagement.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MatchManagement.Controllers
{
    public class MatchController : Controller
    {
        private static readonly HttpClient client;
        private JavaScriptSerializer jss = new JavaScriptSerializer();

        static MatchController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44397/api/matchdata/");
        }
        // GET: Match/List
        public ActionResult List()
        {

            string url = "listmatches";
            HttpResponseMessage response = client.GetAsync(url).Result;

            Debug.WriteLine("The Response is ");
            Debug.WriteLine(response.StatusCode);

            IEnumerable<MatchDto> matches = response.Content.ReadAsAsync<IEnumerable<MatchDto>>().Result;
            Debug.WriteLine("Number of Matches received: ");
            Debug.WriteLine(matches.Count());

            return View(matches);
        }

        // GET: Match/Details/5
        public ActionResult Details(int id)
        {

            string url = "findmatch/"+id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            Debug.WriteLine("the respone code is ");
            Debug.WriteLine(response.StatusCode);

            MatchDto selectedMatch = response.Content.ReadAsAsync<MatchDto>().Result;
            Debug.WriteLine("matches : ");
            Debug.WriteLine(selectedMatch.MatchId);

            return View(selectedMatch);
        }
        public ActionResult Error()
        {

            return View();
        }
        // GET: Match/New
        public ActionResult New()
        {
            return View();
        }

        // POST: Match/Create
        [HttpPost]
        public ActionResult Create(Match match)
        {
            string url = "addmatch";

            string jsonpayload = jss.Serialize(match);
            Debug.WriteLine(jsonpayload);

            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";

            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Error");
            }


        }

        // GET: Match/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Match/Edit/5
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

        // GET: Match/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Match/Delete/5
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
