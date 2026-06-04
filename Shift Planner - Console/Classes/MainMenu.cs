using Microsoft.VisualBasic.FileIO;
using Shift_Planner___Console.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shift_Planner___Console.Classes
{
    public class MainMenu
    {
        private readonly ShiftManager _manager;
        private int _option;

        public MainMenu()
        {
            _manager = new ShiftManager();
            _manager.LoadData("employees.txt", "shifts.txt");
        }

        public void DisplayMenu()
        {
            Console.Clear();

            Console.WriteLine("=================================");
            Console.WriteLine("         SHIFT PLANNER");
            Console.WriteLine("=================================");
            Console.WriteLine();
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. View Employees");
            Console.WriteLine("3. Add Shift");
            Console.WriteLine("4. View Current Schedule");
            Console.WriteLine("5. Delete Employee");
            Console.WriteLine("6. Delete Shifts");
            Console.WriteLine("7. Exit");
            Console.WriteLine();
        }

        public string GetUserInput()
        {
            Console.Write("Select an option: ");
            string input = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(input, out int option))
            {
                _option = option;
                HandleUserInput();
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

            return _option.ToString();
        }

        public void HandleUserInput()
        {
            switch (_option)
            {
                case 1:
                    AddEmployee();
                    break;
                case 2:
                    ListEmployees();
                    WaitForKeyPress();
                    break;
                case 3:
                    AddShift();
                    WaitForKeyPress();
                    break;
                case 4:
                    ViewEmployeeSchedule();
                    break;
                case 5:
                    Console.Write("Choose Employee to delete: ");
                    string employeeID = Console.ReadLine() ?? string.Empty;
                    if (int.TryParse(employeeID, out int ID))
                    {
                        _manager.DeleteEmployee(ID);
                        WaitForKeyPress();
                    }
                    break;
                case 6:
                    _manager.ListShifts();

                    Console.Write("Choose Shift to delete: ");
                    string shiftID = Console.ReadLine() ?? string.Empty;
                    if (int.TryParse(shiftID, out int shiftToDelete))
                    {
                        _manager.DeleteShift(shiftToDelete);
                        WaitForKeyPress();
                    }
                    Console.WriteLine();
                    break;
                case 7:
                    Console.WriteLine("Saving Data...");
                    _manager.SaveData("employees.txt", "shifts.txt");
                    Console.WriteLine("Exiting...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please select a valid option.");
                    break;
            }
        }

        private void AddEmployee()
        {
            Employee employee = new Employee();
            string input;

            Console.WriteLine("Enter employee name: ");
            input = Console.ReadLine() ?? "Unknown";
            employee.EmployeeName = input;

            employee.EmployeeRole = Employee.Role.Customer_Assistant;

            Console.WriteLine("Enter employee Start Date: ");
            input = Console.ReadLine() ?? "Unknown";
            employee.EmployeeStartDate = DateTime.Parse(input);
            _manager.AddEmployee(employee);

            Console.WriteLine($"Employee: {employee.EmployeeName} added to store with following details - \n{employee.EmployeeID}\n{employee.EmployeeRole.ToString()}\n{employee.EmployeeStartDate}");

            WaitForKeyPress();
        }

        public void AddShift()
        {
            string input;
            Console.WriteLine("Choose employee to give shift: ");
            ListEmployees();
            input = Console.ReadLine() ?? "0";

            if (int.TryParse(input, out int id))
            {
                if (_manager.GetEmployee(id) == null)
                {
                    Console.WriteLine("Employee with ID: " + input + " doesn't exist");
                    return;
                }
            }

            if (int.TryParse(input, out int option))
            {
                Shift shift = new Shift();
                shift.EmployeeID = option;

                Console.WriteLine("Enter start time: ");
                string startTime = Console.ReadLine() ?? "0";
                shift.StartTime = DateTime.Parse(startTime);

                Console.WriteLine("Enter finish time: ");
                string finishTime = Console.ReadLine() ?? "0";
                shift.EndTime = DateTime.Parse(finishTime);

                Console.WriteLine("Enter total break: ");
                string breakInput = Console.ReadLine() ?? "0";

                if (int.TryParse(breakInput, out int breakTime))
                    shift.BreakDuration = TimeSpan.FromMinutes(breakTime);

                Console.WriteLine("Choose day to schedule shift for: ");
                Console.WriteLine("1. Monday \n2. Tuesday \n3. Wednesday \n4. Thursday \n5. Friday \n6. Saturday \n7. Sunday");
                string day = Console.ReadLine() ?? "0";

                if(int.TryParse(day, out int chosenDay))
                {
                    switch (chosenDay) {
                        case 1:
                            shift.WorkingDay = Shift.DayOfTheWeek.Monday;
                            break;
                        case 2:
                            shift.WorkingDay = Shift.DayOfTheWeek.Tuesday;
                            break;
                        case 3:
                            shift.WorkingDay = Shift.DayOfTheWeek.Wednesday;
                            break;
                        case 4:
                            shift.WorkingDay = Shift.DayOfTheWeek.Thursday;
                            break;
                        case 5:
                            shift.WorkingDay = Shift.DayOfTheWeek.Friday;
                            break;
                        case 6:
                            shift.WorkingDay = Shift.DayOfTheWeek.Saturday;
                            break;
                        case 7:
                            shift.WorkingDay = Shift.DayOfTheWeek.Sunday;
                            break;
                        default:
                            shift.WorkingDay = Shift.DayOfTheWeek.Monday;
                            break;
                    }
                }

                _manager.CreateShift(shift);
            }
        }

        private void ListEmployees()
        { 
            _manager.ListEmployees();
        }

        private void ViewEmployeeSchedule()
        {
            ListEmployees();

            Console.WriteLine("Enter employee ID you would like to view shifts for: ");
            string input = Console.ReadLine() ?? "0";
            
            if (int.TryParse(input, out int option))
            {
                _manager.ViewEmployeeSchedule(option);
            }

            WaitForKeyPress();
        }

        /*  Utilities */
        private void WaitForKeyPress()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}