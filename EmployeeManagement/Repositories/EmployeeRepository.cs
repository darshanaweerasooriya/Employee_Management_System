using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using EmployeeManagement.Models;
using EmployeeManagement.Repositories.Interfaces;

namespace EmployeeManagement.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public IEnumerable<Employee> GetAll()
        {
            using (var db = new employeeDBEntities())
            {
                return db.Employees.AsNoTracking().ToList();
            }
        }

        public Employee GetById(int id)
        {
            using (var db = new employeeDBEntities())
            {
                return db.Employees.Find(id);
            }
        }

        public void Add(Employee employee)
        {
            using (var db = new employeeDBEntities())
            {
                db.Employees.Add(employee);
                db.SaveChanges();
            }
        }

        public void Update(Employee employee)
        {
            using (var db = new employeeDBEntities())
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new employeeDBEntities())
            {
                var e = db.Employees.Find(id);
                if (e != null)
                {
                    db.Employees.Remove(e);
                    db.SaveChanges();
                }
            }
        }
    }
}