using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Models
{
    public class WorkingDaysResult
    {
        public int TotalDays { get; set; }
        public int ExcludedWeekends { get; set; }
        public int ExcludedHolidays { get; set; }
        public int WorkingDays { get; set; }
    }
}