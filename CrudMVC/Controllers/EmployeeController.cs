using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

using System.Web;
using System.Web.Mvc;
using CrudMVC.Models;
using System.Diagnostics;
using PagedList.Mvc;
using PagedList;

namespace CrudMVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee

        EmployeeEntities2 dbobj2 = new EmployeeEntities2();

        [HttpGet]
        public ActionResult Employee(int? page, string sortOrder,string searchString)
        {
            int pageSize = 10;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            var res = dbobj2.employees.ToList();
            switch (sortOrder)
            {
                case "name_desc":
                    res = res.OrderByDescending(s => s.FullName).ToList();
                    break;
                
                default:
                    res = res.OrderBy(s => s.FullName).ToList();
                    break;
            }
            
            IPagedList<employee> emp = res.ToPagedList(pageIndex, pageSize);

            return View(emp);
        }
      

        [HttpPost]
        public ActionResult AddEmployee(employee model)
        {
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
            var res = dbobj2.employees.ToList();

            return View("Employee", res);
        }
        
       
        
    }
}