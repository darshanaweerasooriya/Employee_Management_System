using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeManagement.Models;
using EmployeeManagement.Services;

namespace EmployeeManagement.Controllers
{
    public class CalculatorController : Controller



    {
        private readonly CalculatorService _service = new CalculatorService();

        // GET: Calculator
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(DateTime startDate, DateTime endDate)
        {
            try
            {
                var result = _service.CalculateWorkingDays(startDate, endDate);
                return View("Result", result);
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // Provide Ajax enpoint to return JSON
        [HttpPost]
        public ActionResult CalculateJson(DateTime startDate, DateTime endDate)
        {
            try
            {
                var result = _service.CalculateWorkingDays(startDate, endDate);
                return Json(result);
            }
            catch (ArgumentException ex)
            {
                Response.StatusCode = 400;
                return Json(new { error = ex.Message });
            }
        }
    }
}