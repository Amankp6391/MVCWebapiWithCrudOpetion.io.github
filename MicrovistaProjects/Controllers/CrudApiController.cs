using MicrovistaProjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MicrovistaProjects.Controllers
{
    public class CrudApiController : ApiController
    {
        MicrovistaEntities db = new MicrovistaEntities();
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetEmployee()
        {
            List<Student> list = db.Students.ToList();
            return Ok(list);
        }
        //
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetEmployeeById(int id)
        {
            var emp = db.Students.Where(model => model.id == id).FirstOrDefault();
            return Ok(emp);

        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult EmpInsert(Student e)
        {
            db.Students.Add(e);
            db.SaveChanges();
            return Ok();
        }
        [System.Web.Http.HttpPut]
        public IHttpActionResult EmpUpdate(Student e)
        {
            db.Entry(e).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            //var emp = db.Employees.Where(model => model.id == e.id).FirstOrDefault();
            //if (emp!=null)
            //{
            //    emp.id = e.id;
            //    emp.name = e.name;
            //    emp.gender = e.gender;
            //    emp.age = e.age;
            //    emp.designation = e.designation;
            //    emp.salary = e.salary;
            //    db.SaveChanges();
            //}
            //else
            //{
            //    return NotFound();
            //}
            return Ok();
        }
        //

        [System.Web.Http.HttpDelete]
        public IHttpActionResult EmpDelete(int id)
        {
            var emp = db.Students.Where(model => model.id == id).FirstOrDefault();
            db.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }

    
    }
}
