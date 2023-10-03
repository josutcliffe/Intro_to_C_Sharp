using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_2_Contractors
{
    internal class RecruitmentSystem
    {
        //Contractor[] contractors = new Contractor[20];
        //Using a list for the Contractors to allow the number of Contractors be dynamic e.g., not hard limited as an array
        List<Contractor> contractorList = new List<Contractor>();
        List<Job> jobList = new List<Job>();

        public RecruitmentSystem(int numOfPeople)
        {
            //contractorList = new Contractor[numOfContractors];
            //contractors[0] = new Contractor(0, "John", "Smith", new DateTime(2023, 01, 01), 35);
            //contractors[0] = new Contractor(0, "Jane", "Doe", new DateTime(2022, 06, 01), 50);
            contractorList.Add(new Contractor(0, "John", "Smith", new DateTime(2023, 01, 01), 35));
            contractorList.Add(new Contractor(1, "Jane", "Doe", new DateTime(2022, 06, 01), 50));
        }

        public void AddContractor(Contractor newContractor)
        {

        }

        //public void RemoveContractor(Contractor oldContractor)
        //{

        //}

        //public void AddJob(Job newJob)
        //{

        //}

        //public void AssignJob(Job assignJob)
        //{

        //}

        //public void CompleteJob(Job completedJob)
        //{

        //}

        //public List<Job> GetJobs()
        //{
        //    return jobs.ToList();
        //}

        public List<Contractor> GetContractors()
        {
            return contractorList.ToList();
        }

        //public List<Contractor> GetAvailableContractors()
        //{
        //    return contractors.ToList();
        //}

        //public List<Job> GetUnassignedJobs()
        //{
        //    return jobs.ToList();
        //}

        //public List<Job> GetJobByCost()
        //{
        //    return jobs.ToList();
        //}
    }
}
