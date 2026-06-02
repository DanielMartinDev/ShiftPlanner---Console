using Shift_Planner___Console.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shift_Planner___Console.Classes
{
    public class ShiftManager
    {
        private readonly List<Employee> employees;
        private readonly List<Shift> shifts;

        public ShiftManager()
        {
            employees = new List<Employee>();
            shifts = new List<Shift>();
        }

        /* Employee Functions */

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public void ListEmployees()
        {
            foreach (var employee in employees)
            {
                Console.WriteLine($"ID: {employee.EmployeeID}\nName: {employee.EmployeeName}\nRole: {employee.EmployeeRole}\nStart Date: {employee.EmployeeStartDate.ToShortDateString()}");
            }
        }

        public void DeleteEmployee(int employeeID)
        {
            employees.RemoveAll(e => e.EmployeeID == employeeID);
            shifts.RemoveAll(s => s.EmployeeID == employeeID);
        }

        public Employee? GetEmployee(int employeeID)
        {
            return employees.FirstOrDefault(e => e.EmployeeID == employeeID);
        }

        /* Shift functions */
        public void CreateShift(Shift shift)
        {
            shifts.Add(shift);
        }

        public void ListShifts()
        {
            foreach(var shift in shifts)
            {
                var employeeName = employees?.FirstOrDefault(e => e.EmployeeID == shift.EmployeeID)?.EmployeeName;
                Console.WriteLine($"ShiftID: {shift.ShiftID}\nEmployee Name: {employeeName}\nShift Time: {shift.StartTime} - {shift.EndTime}\nBreak: {shift.BreakDuration}");
            }
        }

        public void ViewEmployeeSchedule(int employeeID)
        {
            var employee = GetEmployee(employeeID);

            if (employee == null)
            {
                Console.WriteLine("Employee not found!");
                return;
            }

            Console.WriteLine($"Schedule for {employee?.EmployeeName}");

            foreach(var shift in shifts.Where(s => s.EmployeeID == employee?.EmployeeID))
            {
                Console.WriteLine($"{shift.StartTime} - {shift.EndTime}");
            }
        }

        public void DeleteShift(int shiftID)
        {
            shifts.RemoveAll(s => s.ShiftID == shiftID);
        }

        public Shift? GetShift(int shiftID)
        {
            return shifts.FirstOrDefault(s => s.ShiftID == shiftID);
        }
    }
}