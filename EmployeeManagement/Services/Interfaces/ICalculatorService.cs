using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Services.Interfaces
{
    public interface ICalculatorService
    {
        WorkingDaysResult CalculateWorkingDays(DateTime startDate, DateTime endDate);
    }
}