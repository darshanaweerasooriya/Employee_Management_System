using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeManagement.Models;
namespace EmployeeManagement.Services.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        Employee Get(int id);
        void Create(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
    }
}