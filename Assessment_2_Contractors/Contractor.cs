using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_2_Contractors
{
    internal class Contractor
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartDate { get; set; }
        public double HourlyWage { get; set; }

        public Contractor(int id, string firstName, string lastName, DateTime startDate, double hourlyWage)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            StartDate = startDate;
            HourlyWage = hourlyWage;
        }

        public override string ToString()
        {
            return $"[{ID}] {FirstName} {LastName} ({StartDate}) {HourlyWage})";
        }
    }
}
