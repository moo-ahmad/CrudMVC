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

        public ActionResult Employee(employee model)
        {

            var res = dbobj2.employees.ToList();

            return View(res);
        }
        [HttpPost]
        public void AddEmployee(employee model)
        {
            Debug.Write("We are in.....");

            EmployeeEntities2 dbobj = new EmployeeEntities2();

            try
            {

                employee obj = new employee();
                obj.FullName = model.FullName;
                obj.Age = model.Age;
                obj.StartDate = model.StartDate;
                obj.Salary = model.Salary;

                dbobj.employees.Add(obj);

                dbobj.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

    }
}