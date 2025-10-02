using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using EmployeeManagement.Models;
using EmployeeManagement.Repositories.Interfaces;

namespace EmployeeManagement.Repositories
{
    public class HolidayRepository : IHolidayRepository
    {
        public IEnumerable<Holiday> GetAll()
        {
            using (var db = new employeeDBEntities())
            {
                return db.Holidays.AsNoTracking().OrderBy(h => h.HolidayDate).ToList();
            }
        }

        public IEnumerable<DateTime> GetHolidayDatesBetween(DateTime from, DateTime to)
        {
            using (var db = new employeeDBEntities())
            {
                // Use DbFunctions.TruncateTime if comparing DateTime in EF query
                return db.Holidays
                         .Where(h => DbFunctions.TruncateTime(h.HolidayDate) >= DbFunctions.TruncateTime(from)
                                  && DbFunctions.TruncateTime(h.HolidayDate) <= DbFunctions.TruncateTime(to))
                         .Select(h => DbFunctions.TruncateTime(h.HolidayDate).Value)
                         .ToList();
            }
        }

        public void Add(Holiday holiday)
        {
            using (var db = new employeeDBEntities())
            {
                db.Holidays.Add(holiday);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new EmployeeDbContext())
            {
                var h = db.Holidays.Find(id);
                if (h != null)
                {
                    db.Holidays.Remove(h);
                    db.SaveChanges();
                }
            }
        }
    }
}