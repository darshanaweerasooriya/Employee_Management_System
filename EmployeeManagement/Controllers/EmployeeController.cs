using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeManagement.Models;
using EmployeeManagement.Services;


namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _service = new EmployeeService();
        // GET: Employee
        public ActionResult Index()
        {
            var list = _service.G
        }
    }
}