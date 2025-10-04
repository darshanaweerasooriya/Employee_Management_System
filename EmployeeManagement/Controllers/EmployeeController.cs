using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeManagement.Models;
using EmployeeManagement.Services;
using EmployeeManagement.Services.Interfaces;


namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _service = new EmployeeService();
        // GET: Employee
        public ActionResult Index()
        {
            var list = _service.GetAll();
            return View(list);
        }

        //GET: Create

        public ActionResult Create() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(Employee model)
        {
            if(!ModelState.IsValid) return View(model);
            _service.Create(model);
            return RedirectToAction("Index");


        }
        // POST: /Employee/Add
        [HttpPost]
        public JsonResult Add(Employee employee)
        {
            _service.Create(employee);
            return Json(new { success = true, message = "Employee added successfully" });
        }


        //GET: Edit
        public ActionResult Edit(int id)
        {
            var e = _service.Get(id);
            if (e != null) return HttpNotFound();
            return View(e);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(Employee model)
        {
            if (!ModelState.IsValid) return View(model);
            _service.Update(model);
            return RedirectToAction("Index");
        }

        // GET: Delete
        public ActionResult DeleteConfirm(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
            
        }


        public ActionResult Delete(int id)
        {
            var e = _service.Get(id);
            if (e == null) return HttpNotFound();
            return View(e);
           
        }


    }
}