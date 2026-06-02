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
            Console.WriteLine("3. View Current Schedule");
            Console.WriteLine("4. Delete Employee");
            Console.WriteLine("5. Delete Shifts");
            Console.WriteLine("6. Exit");
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
                    AddShift();
                    break;
                case 2:
                    ListEmployees();
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 3:
                    ListShifts();

                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 4:
                    Console.Write("Choose Task to delete: ");
                    string taskID = Console.ReadLine() ?? string.Empty;
                    if (int.TryParse(taskID, out int option))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                    break;
                case 5:
                    Console.WriteLine("Saving to file...");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 6:
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
            employee.EmployeeID = 43359150;
            employee.EmployeeName = "Daniel";
            employee.EmployeeRole = "Manager";
            employee.EmployeeStartDate = DateTime.Parse("27/04/2026");
            _manager.AddEmployee(employee);
        }

        public void AddShift()
        {
            Shift shift = new Shift();
            shift.ShiftID = 1;
            shift.EmployeeID = 43359150;
            shift.StartTime = DateTime.Parse("09:00");
            shift.EndTime = DateTime.Parse("17:00");
            shift.BreakDuration = TimeSpan.FromMinutes(15);

            _manager.CreateShift(shift);
        }

        private void ListEmployees()
        { 
            _manager.ListEmployees();
        }

        private void ListShifts()
        {
            _manager.ListShifts();
        }
    }
}