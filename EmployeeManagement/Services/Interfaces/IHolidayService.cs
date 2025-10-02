using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeManagement.Models;
namespace EmployeeManagement.Services.Interfaces
{
    public interface IHolidayService
    {
        IEnumerable<Holiday> GetAll();
        void Create(Holiday holiday);
        void Delete(int id);
        IEnumerable<DateTime> GetHolidayDatesBetween(DateTime from, DateTime to);
    }
}