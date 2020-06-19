using MongoDB_Kickoff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Driver.Linq;
using MongoDB.Bson;

namespace MongoDB_Kickoff.Controllers
{
    public class HomeController : Controller
    {
        DepartmentContext context = new DepartmentContext();

        public ActionResult Departmentlist()
        {
            var department = context.Departments.AsQueryable<Department>();
            return View(department);
        }

        public ActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDepartment(Department department)
        {
            if (ModelState.IsValid)
            {
                context.Departments.Save(department);
                return RedirectToAction("Departmentlist");
            }
            return View();
        }

        public ActionResult DeleteDepartment(string id)
        {
            var department = context.Departments.AsQueryable<Department>().Where(a => a.DeptId == id).Select(a => a);
            var mongoQuery = ((MongoQueryable<Department>)department).GetMongoQuery();
            context.Departments.Remove(mongoQuery);
            return RedirectToAction("Departmentlist");
        }

        public ActionResult EditDepartment(string id)
        {
            Department department = context.Departments.AsQueryable<Department>().Where(a => a.DeptId == id).Select(a => a).First();
            return View(department);
        }

        [HttpPost]
        public ActionResult EditDepartment(Department department)
        {
            if (ModelState.IsValid)
            {
                context.Departments.Save(department);
                return RedirectToAction("Departmentlist");
            }
            return View();
        }
    }
}