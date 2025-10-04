using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeManagement.Models;
using EmployeeManagement.Services.Interfaces;

namespace EmployeeManagement.Services
{
    public class CalculatorService : ICalculatorService
    {
        private readonly IHolidayService _holidayService;

        public CalculatorService()
        {
            _holidayService = new HolidayService();
        }

        public WorkingDaysResult CalculateWorkingDays(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate) throw new ArgumentException("Start date should be before the end date.");
            if (startDate.DayOfWeek == DayOfWeek.Saturday || startDate.DayOfWeek == DayOfWeek.Sunday)
                throw new ArgumentException("Start date must be a weekday and not a weekend(Saturday or Sunday).");

            var holidayDates = _holidayService.GetHolidayDatesBetween(startDate, endDate).Select(d => d.Date).ToHashSet();

            int totalDays = (endDate.Date - startDate.Date).Days + 1;
            int excludeWeekends = 0;
            int excludedHolidays = 0;
            int workingDays = 0;

            for (var d = startDate.Date; d <= endDate.Date; d = d.AddDays(1))
            {
                if (d.DayOfWeek == DayOfWeek.Saturday || d.DayOfWeek == DayOfWeek.Sunday)
                {
                    excludeWeekends++;
                    continue;
                }
                if (holidayDates.Contains(d))
                {
                    excludedHolidays++;
                    continue;
                }
                workingDays++;
            }

            return new WorkingDaysResult
            {
                TotalDays = totalDays,
                ExcludedWeekends = excludeWeekends,
                ExcludedHolidays = excludedHolidays,
                WorkingDays = workingDays
            };

        }

    }
}