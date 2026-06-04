using Shift_Planner___Console.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Shift_Planner___Console.Classes
{
    public class ShiftManager
    {
        private readonly List<Employee> employees;
        private readonly List<Shift> shifts;
        private int _nextEmployeeID;
        private int _nextShiftID = 1;
        
        public ShiftManager()
        {
            employees = new List<Employee>();
            shifts = new List<Shift>();
        }

        /* Employee Functions */

        public void AddEmployee(Employee employee)
        {
            employee.EmployeeID = _nextEmployeeID++;
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
            shift.ShiftID = _nextShiftID++;
            shifts.Add(shift);
        }

        public void ListShifts()
        { 
            foreach (var shift in shifts)
            {
                var employeeName = employees?.FirstOrDefault(e => e.EmployeeID == shift.EmployeeID)?.EmployeeName;

                Console.WriteLine($"\nShiftID: {shift.ShiftID}\nEmployee Name: {employeeName}\nShift Time: {shift.StartTime} - {shift.EndTime}\nBreak: {shift.BreakDuration}");
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

            foreach(var shift in shifts.Where(s => s.EmployeeID == employee?.EmployeeID))
            {
                if(shift == null)
                {
                    Console.WriteLine($"No Schedule Shifts for - {employee.EmployeeName}");
                    return;
                }

                Console.WriteLine($"Schedule for {employee?.EmployeeName}");
                Console.WriteLine($"{shift.WorkingDay} - {shift.StartTime.ToString("HH:mm")} - {shift.EndTime.ToString("HH:mm")}");
                Console.WriteLine($"Break: {shift.BreakDuration.ToString("mm")} mins");
            }
        }

        public void DeleteShift(int shiftID)
        {
            shifts.RemoveAll(s => s.ShiftID == shiftID);
            Console.WriteLine($"Shift with ID: {shiftID} has been deleted from schedule");
        }

        public Shift? GetShift(int shiftID)
        {
            return shifts.FirstOrDefault(s => s.ShiftID == shiftID);
        }

        public void SaveData(string employeeFile, string shiftFile)
        {
            using (FileStream fs = new FileStream(employeeFile, FileMode.Create, FileAccess.Write))
            {
                foreach (var employee in employees)
                {
                    string line = $"ID = {employee.EmployeeID}, Name = {employee.EmployeeName}, StartDate = {employee.EmployeeStartDate}, Role = {employee.EmployeeRole}\n";
                    byte[] data = Encoding.UTF8.GetBytes(line);
                    fs.Write(data, 0, data.Length);
                }
            }

            using (FileStream fs = new FileStream(shiftFile, FileMode.Create, FileAccess.Write))
            {
                foreach (var shift in shifts)
                {
                    string line = $"ID = {shift.ShiftID}, EmployeeID = {shift.EmployeeID}, StartTime = {shift.StartTime}, EndTime = {shift.EndTime}, BreakDuration = {shift.BreakDuration}\n";
                    byte[] data = Encoding.UTF8.GetBytes(line);
                    fs.Write(data, 0, data.Length);
                }
            }
        }

        public void LoadData(string employeeFile, string shiftFile)
        {
            Console.WriteLine("Loading Employee Data...");
            if (File.Exists(employeeFile))
            {
                string[] lines = File.ReadAllLines(employeeFile);

                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] parts = line.Split(", ");

                    if (parts.Length >= 4)
                    {
                        int id = int.Parse(parts[0].Split(" = ")[1]);
                        string name = parts[1].Split(" = ")[1];
                        DateTime startDate = DateTime.Parse(parts[2].Split(" = ")[1]);
                        string role = parts[3].Split(" = ")[1];

                        Employee e = new Employee();
                        e.EmployeeID = id;
                        e.EmployeeName = name;
                        e.EmployeeStartDate = startDate;
                        e.EmployeeRole = Employee.Role.Customer_Assistant;
                        AddEmployee(e);
                    }
                }
            }

            Console.WriteLine("Loading Shift Data...");
            if (File.Exists(shiftFile))
            {
                string[] lines = File.ReadAllLines(shiftFile);

                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] parts = line.Split(", ");

                    if (parts.Length >= 5)
                    {
                        int id = int.Parse(parts[0].Split(" = ")[1]);
                        int employeeID = int.Parse(parts[1].Split(" = ")[1]);
                        DateTime startTime = DateTime.Parse(parts[2].Split(" = ")[1]);
                        DateTime endTime = DateTime.Parse(parts[3].Split(" = ")[1]);
                        TimeSpan breakDuration = TimeSpan.Parse(parts[4].Split(" = ")[1]);

                        Shift s = new Shift();
                        s.ShiftID = id;
                        s.EmployeeID = employeeID;
                        s.StartTime = startTime;
                        s.EndTime = endTime;
                        s.BreakDuration = breakDuration;
                        CreateShift(s);
                    }
                }
            }
        }
    }
}