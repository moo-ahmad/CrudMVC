using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrudMVC.Models;
using System.Diagnostics;
namespace CrudMVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee

        EmployeeEntities2 dbobj2 = new EmployeeEntities2();

        public ActionResult Employee()
        {

            var res = dbobj2.employees.ToList();
            
            return View(res);
        }

        //[HttpGet]
        //public PartialViewResult Create()
        //{
        //    var res = dbobj2.employees;
        //    return PartialView("_DataList", res);
        //}

        [HttpPost]
        public ActionResult AddEmployee(employee model)
        {
            Debug.Write("We are in.....");

            

            try
            {

                employee obj = new employee();
                obj.FullName = model.FullName;
                obj.Age = model.Age;
                obj.StartDate = model.StartDate;
                obj.Salary = model.Salary;

                dbobj2.employees.Add(obj);

                dbobj2.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View("Employee");
        }

    }
}