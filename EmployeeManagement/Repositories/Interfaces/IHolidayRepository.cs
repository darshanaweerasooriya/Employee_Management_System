using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeManagement.Models;

namespace EmployeeManagement.Repositories.Interfaces
{
    public interface IHolidayRepository
    {
        IEnumerable<Holiday> GetAll();
        IEnumerable<DateTime> GetHolidayDatesBetween(DateTime from, DateTime to);
        void Add(Holiday holiday);
        void Delete(int id);
    }
}