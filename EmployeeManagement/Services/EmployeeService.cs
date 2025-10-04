using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using EmployeeManagement.Models;
using EmployeeManagement.Repositories;
using EmployeeManagement.Repositories.Interfaces;
using EmployeeManagement.Services.Interfaces;

namespace EmployeeManagement.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;

        public EmployeeService()
        {
            _repo = new EmployeeRepository();
        }

        public IEnumerable<Employee> GetAll() => _repo.GetAll();
        public Employee Get(int id) => _repo.GetById(id);
        public void Create(Employee employee) => _repo.Add(employee);
        public void Update(Employee employee) => _repo.Update(employee);
        public void Delete(int id) => _repo.Delete(id);
    }
}