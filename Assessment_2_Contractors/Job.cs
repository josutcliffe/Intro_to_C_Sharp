using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_2_Contractors
{
    internal class Job
    {
        public int JobID { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public double Cost { get; set; }
        public string Completed { get; set; }
        public string ContractorAssigned { get; set; }

        public Job(int jobID, string title, DateTime date, double cost, string completed, string contractorAssigned)
        {
            JobID = jobID;
            Title = title;
            Date = date;
            Cost = cost;
            Completed = completed;
            ContractorAssigned = contractorAssigned;
        }
    }
}
