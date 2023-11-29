using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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
    public class Job
    {
        public int JobID { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public double JobCost { get; set; }
        public JobStatusTypes JobStatusType { get; set; }
        public JobAssignmentTypes JobAssignmentType { get; set; }
        public Contractor AssignedContractor { get; set; }
        public string AssignedContractorName { get; set; }

        public Job(int jobID, string title, DateTime date, double jobCost, JobStatusTypes jobStatusType, JobAssignmentTypes jobAssignmentType, Contractor assignedContractor, string assignedContractorName)
        {
            JobID = jobID;
            Title = title;
            Date = date;
            JobCost = jobCost;
            JobStatusType = jobStatusType;
            JobAssignmentType = jobAssignmentType;
            AssignedContractor = assignedContractor;
            AssignedContractorName = assignedContractorName;
        }

        public override string ToString()
        {
            return $"[{JobID}] {Title} ({Date}) {JobCost} {JobStatusType} {JobAssignmentType} {AssignedContractorName}";
        }
    }

    public enum JobAssignmentTypes
    {
        Unassigned,
        Assigned
    }

    public enum JobStatusTypes
    {
        Incomplete,
        Completed
    }
}
