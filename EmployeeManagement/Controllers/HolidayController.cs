using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeManagement.Models;
using EmployeeManagement.Services;

namespace EmployeeManagement.Controllers
{
    public class HolidayController : Controller
    {
        private readonly HolidayService _service = new HolidayService();
        // GET: Holiday
        public ActionResult Index()
        {
            var list = _service.GetAll();
            return View(list);
        }

        //GET : Create
        public ActionResult Create() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(Holiday model)
        {
            if (!ModelState.IsValid) return View(model);
            _service.Create(model);
            return RedirectToAction("Index");
        }

        //GET DELETE
        public ActionResult Delete(int id)
        {
            var h = _service.GetAll().FirstOrDefault(x => x.Id == id);
            if (h == null) return HttpNotFound();
            return View(h);
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}