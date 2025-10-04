using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeManagement.Models;

namespace EmployeeManagement.Delegates
{
    public class CalculationDelegates
    {
        public delegate WorkingDaysResult CalculateWorkingDaysDelegate(DateTime start, DateTime end);
    }
}