using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Repositories.Interfaces
{
    public interface IHolidayRepository
    {
        IEnumerable<Models.Holiday> GetAll();
        IEnumerable<DateTime> GetHolidatDateBetween(DateTime from, DateTime to);
        void Add(Models.Holiday holiday);
        void Delete(int id);
    }
}