using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeManagement.Models;
using EmployeeManagement.Repositories;
using EmployeeManagement.Repositories.Interfaces;
using EmployeeManagement.Services.Interfaces;

namespace EmployeeManagement.Services
{
    public class HolidayService : IHolidayService
    {
        private readonly IHolidayRepository _repo;

        public HolidayService()
        {
            _repo = new HolidayRepository();
        }

        public IEnumerable<Holiday> GetAll() => _repo.GetAll();
        public void Create(Holiday holiday) => _repo.Add(holiday);
        public void Delete(int id) => _repo.Delete(id);
        public IEnumerable<DateTime> GetHolidayDatesBetween(DateTime from, DateTime to) => _repo.GetHolidayDatesBetween(from, to);
    }
}