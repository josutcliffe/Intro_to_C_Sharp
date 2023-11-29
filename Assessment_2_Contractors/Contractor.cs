using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

//=========================================
//Name: Joshua Sutcliffe
//Student ID: 20107131
//Email: 20107131@tafe.wa.edu.au
//Cluster - Introductory Programming - C#
//Date Submitted: 12/11/2023
//=========================================

namespace Assessment_2_Contractors
{
    public class Contractor
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartDate { get; set; }
        public double HourlyWage { get; set; }
        public ContractorAssignmentTypes ContractorAssignmentType { get; set; }
        public Job AssignedJob { get; set; }
        public string AssignedJobTitle { get; set; }
        public string FullName
        { 
            get  
            {   
                return FirstName + " " + LastName;
            }
        }

        public Contractor(int id, string firstName, string lastName, DateTime startDate, double hourlyWage, ContractorAssignmentTypes contractorAssignmentType, Job assignedJob, string assignedJobTitle)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            StartDate = startDate;
            HourlyWage = hourlyWage;
            ContractorAssignmentType = contractorAssignmentType;
            AssignedJob = assignedJob;
            AssignedJobTitle = assignedJobTitle;
        }

        public override string ToString()
        {
            return $"[{ID}] {FirstName} {LastName} ({StartDate}) {HourlyWage} {ContractorAssignmentType} {AssignedJobTitle}";
        }
    }

    public enum ContractorAssignmentTypes
    {
        Unavailable,
        Available
    }
}
