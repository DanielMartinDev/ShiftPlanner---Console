using System;
using System.Collections.Generic;
using System.Text;

namespace Shift_Planner___Console.Objects
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeRole { get; set; } = string.Empty;
        public string EmployeeName { get; set; } = string.Empty;
        public DateTime EmployeeStartDate { get; set; }
    }
}