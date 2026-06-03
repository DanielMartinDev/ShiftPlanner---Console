using System;
using System.Collections.Generic;
using System.Text;

namespace Shift_Planner___Console.Objects
{
    public class Employee
    {
        public enum Role
        {
            Customer_Assistant,
            Team_Lead,
            Deputy_Manager,
            Store_Manager
        };

        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public DateTime EmployeeStartDate { get; set; }
        public Role EmployeeRole { get; set; }
    }
}