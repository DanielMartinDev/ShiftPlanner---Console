using System;
using System.Collections.Generic;
using System.Text;

namespace Shift_Planner___Console.Objects
{
    public class Shift
    {
        public enum DayOfTheWeek
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }

        public int ShiftID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan BreakDuration { get; set; }
        public DateTime EndTime { get; set; }
        public DayOfTheWeek WorkingDay { get; set; }

        public double HoursWorked
        {
            get {
                return (EndTime - StartTime).TotalHours
                    - BreakDuration.TotalHours;
            }
        }
    }
}
