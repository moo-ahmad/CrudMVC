using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrudMVC.Models;

namespace CrudMVC.Controllers
{
    public class StudentController : Controller
    {
        db_testEntities dbobj = new db_testEntities();

        // GET: Student
        public ActionResult Student()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(tbl_Student model)
        {
            if (ModelState.IsValid)
            {

                tbl_Student obj = new tbl_Student();
                obj.Name = model.Name;
                obj.Fname = model.Fname;
                obj.Email = model.Email;
                obj.Mobile = model.Mobile;
                obj.Description = model.Description;

                dbobj.tbl_Student.Add(obj);

                dbobj.SaveChanges();
            }
            ModelState.Clear();
            return View("Student");
        }

        public ActionResult StudentList(tbl_Student model)
        {
            var res = dbobj.tbl_Student.ToList();
            return View(res);
        }

        public ActionResult Delete(int id)
        {
            var res = dbobj.tbl_Student.Where(x => x.ID == id).First();
            dbobj.tbl_Student.Remove(res);
            dbobj.SaveChanges();
            var list = dbobj.tbl_Student.ToList();

            return View("StudentList", list);
        }


    }
}