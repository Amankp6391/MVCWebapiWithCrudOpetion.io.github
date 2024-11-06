using MicrovistaProjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MicrovistaProjects.Controllers
{
    public class CrudMVCController : Controller
    {
        HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            List<Student> emp_list = new List<Student>();
            client.BaseAddress = new Uri("https://localhost:44302/api/CrudApi");
            var response = client.GetAsync("CrudApi");
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Student>>();
                display.Wait();
                emp_list = display.Result;
            }
            return View(emp_list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student emp)
        {
            client.BaseAddress = new Uri("https://localhost:44302/api/CrudApi");
            var response = client.PostAsJsonAsync<Student>("CrudApi", emp);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create");
        }
        public ActionResult Details(int id)
        {
            Student e = null;
            client.BaseAddress = new Uri("https://localhost:44302/api/CrudApi");
            var response = client.GetAsync("CrudApi?id=" + id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Student>();
                display.Wait();
                e = display.Result;
            }
            return View(e);
        }

        public ActionResult Edit(int id)
        {
            Student e = null;
            client.BaseAddress = new Uri("https://localhost:44302/api/CrudApi");
            var response = client.GetAsync("CrudApi?id=" + id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Student>();
                display.Wait();
                e = display.Result;
            }
            return View(e);
        }
        [HttpPost]
        public ActionResult Edit(Student e)
        {
            client.BaseAddress = new Uri("https://localhost:44302/api/CrudApi");
            var response = client.PutAsJsonAsync<Student>("CrudApi", e);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Edit");
        }
        public ActionResult Delete(int id)
        {
            Student e = null;
            client.BaseAddress = new Uri("https://localhost:44302/api/CrudApi");
            var response = client.GetAsync("CrudApi?id=" + id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Student>();
                display.Wait();
                e = display.Result;
            }
            return View(e);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            client.BaseAddress = new Uri("https://localhost:44302/api/CrudApi");
            var response = client.DeleteAsync("CrudApi/" + id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Delete");
        }
    }
}