using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
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
    public class RecruitmentSystem
    {
        //Using a list for the Contractors and Jobs to allow the number of Contractors/Jobs be dynamic e.g., not hard limited as an array
        List<Contractor> contractorList = new List<Contractor>();
        List<Job> jobList = new List<Job>();

        public RecruitmentSystem(int numOfPeople)
        {
            //Pre-populated list of contractors
            contractorList.Add(new Contractor(0, "John", "Smith", new DateTime(2023, 01, 01), 35, ContractorAssignmentTypes.Available, null, null));
            contractorList.Add(new Contractor(1, "Jane", "Doe", new DateTime(2022, 06, 01), 50, ContractorAssignmentTypes.Available, null, null));
            contractorList.Add(new Contractor(2, "Bill", "Jones", new DateTime(2021, 12, 06), 75, ContractorAssignmentTypes.Available, null, null));

            //Pre-populated list of jobs
            jobList.Add(new Job(0, "Kitchen", new DateTime(2023, 01, 01), 300.00, JobStatusTypes.Incomplete, JobAssignmentTypes.Unassigned, null, null));
            jobList.Add(new Job(1, "Garden", new DateTime(2023, 01, 01), 300.00, JobStatusTypes.Incomplete, JobAssignmentTypes.Unassigned, null, null));
            jobList.Add(new Job(2, "Roof", new DateTime(2022, 11, 01), 1000.00, JobStatusTypes.Incomplete, JobAssignmentTypes.Unassigned, null, null));
        }

        public void AddContractor(Contractor newContractor)
        {
            contractorList.Add(newContractor);
        }

        public void RemoveContractor(Contractor oldContractor)
        {
            contractorList.Remove(oldContractor);
        }

        public void AddJob(Job newJob)
        {
            jobList.Add(newJob);
        }

        //assigns available contractor to an unassigned job, and adds information into the contractor and job descriptions
        public void AssignJob(Contractor contractor, Job job)
        {
            if (contractor != null && job != null)
            {
                contractor.AssignedJob = job;
                contractor.ContractorAssignmentType = ContractorAssignmentTypes.Unavailable;  //make contractor unavailable
                contractor.AssignedJobTitle = job.Title;  //attach assigned job title to contractor
                job.AssignedContractor = contractor;
                job.AssignedContractorName = contractor.FirstName + " " + contractor.LastName;  //combine contractor first and last name and add to the job
                job.JobAssignmentType = JobAssignmentTypes.Assigned;
            }
        }

        //removes job from job list and returns contractor to Available, placing them back in the Available Contractor pool
        public void CompleteJob(Job completedJob)
        {
            if (completedJob.AssignedContractor != null && completedJob.AssignedContractor != null)
            {
                completedJob.AssignedContractor.ContractorAssignmentType = ContractorAssignmentTypes.Available;  //return contractor to available contractor pool
                completedJob.AssignedContractor.AssignedJobTitle = null;  //remove completed job title from contractor
            }
            jobList.Remove(completedJob);
        }

        public List<Contractor> GetContractors()
        {
            return contractorList.ToList();
        }

        //get number of contractors to ensure that new contractors get a unique ID
        public int GetContractorCount()
        {
            return contractorList.Count;
        }

        //get number of jobs to ensure that new jobs get a unique ID
        public List<Job> GetJobs()
        {
            return jobList.ToList();
        }

        public int GetJobCount()
        {
            return jobList.Count;
        }

        //loop through and create a list of all contractors that are Available
        public List<Contractor> GetAvailableContractors()
        {
            List<Contractor> unassignedContractors = new List<Contractor>();
            List<Contractor> allContractors = GetContractors();
            foreach (Contractor contractor in allContractors)
            {
                if (contractor.ContractorAssignmentType == ContractorAssignmentTypes.Available)
                {
                    unassignedContractors.Add(contractor);
                }
            }
            return unassignedContractors;
        }

        //loop through and create a list of all jobs that are Unassigned
        public List<Job> GetUnassignedJobs()
        {
            List<Job> unassignedJobs = new List<Job>();
            List<Job> allJobs = GetJobs();
            foreach (Job job in allJobs)
            {
                if (job.JobAssignmentType == JobAssignmentTypes.Unassigned)
                {
                    unassignedJobs.Add(job);
                }
            }
            return unassignedJobs;
        }

        //loop through and create a list of all jobs that fall within the minCost and maxCost range (input via user textboxes within MainWindow.xaml.cs)
        public List<Job> GetJobByCost(int minCost, int maxCost)
        {
            List<Job> filteredJobs = new List<Job>();
            foreach (Job job in jobList)
            {
                if (job.JobCost >= minCost && job.JobCost <= maxCost)
                {
                    filteredJobs.Add(job);
                }
            }
            return filteredJobs;
        }
    }
}
